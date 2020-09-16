// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;
using System.Linq;
using RssServer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace GreeterServer
{
    class GrpcRssReaderImpl : GrpcRssReader.GrpcRssReaderBase
    {
        RssDataBase db = new RssDataBase();
        public NewsReply ConvertToRssItem(SyndicationItem item)
        {
            String url = " ";
            try
            {
                if (item.BaseUri == null)
                {
                    url = item.Links[0].Uri.ToString();
                }
                else { url = item.BaseUri.ToString(); }
            }
            catch { }
            String summary = null;
            if (item.Summary != null) summary = item.Summary.Text;
            else
            {
                foreach (SyndicationElementExtension ext in item.ElementExtensions)
                {
                    if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                        summary = ext.GetObject<XElement>().Value;
                }
            }
            NewsReply newsReply = new NewsReply
            {
                Subject = item.Title.Text,
                Summary = summary,
                Url = url,
                Date = item.PublishDate.DateTime.ToString(),
                Id = item.Id
            };

            return newsReply;
        }
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
        public override Task<HelloReply> SayHelloAgain(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello again " + request.Name });
        }
        public override Task<AuthReply> AuthenticateUser(AuthRequest request, ServerCallContext context)
        {
            //db.Connect();
            Console.WriteLine(request.Username);
            String userid = db.Authenticate(request.Username, request.Password);
            if (userid != null)
            {
                return Task.FromResult(new AuthReply { Checkresult = "true", Authtoken = userid });
            }
            return Task.FromResult(new AuthReply { Checkresult = "false", Authtoken = "null" });
        }
        public override Task<AuthReply> AddUser(AuthRequest request, ServerCallContext context)
        {
            db.Connect();
            String userid = db.AddUser(request.Username, request.Password);
            if (userid != null)
            {
                return Task.FromResult(new AuthReply { Checkresult = "true", Authtoken = userid });
            }
            return Task.FromResult(new AuthReply { Checkresult = "false", Authtoken = "null" });// base.AuthenticateUser(request, context);
        }

        //public override Task<NewsReply> FindNews(NewsRequest request, ServerCallContext context)
        //{
        //    //load settings drom db
        //    foreach(string site in db.GetUserSettings(request.Userid, "site")){

        //        RSSReader.ReadUserFeed(site, db.GetUserSettings(request.Userid, "tag"));
        //    }


        //    //streaming
        //    return Task.FromResult(ConvertToRssItem(RSSReader.ReadFeed2(request.Url)[0]));
        //}

        public override async Task FindNews(NewsRequest request, Grpc.Core.IServerStreamWriter<NewsReply> responseStream, ServerCallContext context)
        {
            //load settings drom db
            foreach (string site in db.GetUserSettings(request.Userid, "site"))
            {
                //streaming
                foreach (SyndicationItem item in RSSReader.ReadUserFeed(site, db.GetUserSettings(request.Userid, "tag")))
                {
                    await responseStream.WriteAsync(ConvertToRssItem(item));
                }
            }
            Console.WriteLine("\nNews sent to client. Userid: " + request.Userid);


            //return ;   <NewsReply>
        }

        public override async Task<SettingsSavedReply> SaveSites(Grpc.Core.IAsyncStreamReader<Settings> requestStream,
    Grpc.Core.ServerCallContext context)
        {
            int savedCount = 0;
            bool nextExist = await requestStream.MoveNext();
            String userid = requestStream.Current.Userid;
            List<String> settings = new List<String>();

            //settings.Add(requestStream.Current.Field);
            //var stopwatch = new System.Diagnostics.Stopwatch();
            //stopwatch.Start();

            do
            {
                settings.Add(requestStream.Current.Field);
                nextExist = await requestStream.MoveNext();
            } while (nextExist);

            //stopwatch.Stop();

            savedCount = db.SetUserSettings(userid, settings, "site");
            Console.WriteLine(savedCount);
            return new SettingsSavedReply { Count = savedCount };
        }
        public override async Task LoadSitesList(SettingsRequest request,
                            Grpc.Core.IServerStreamWriter<Settings> responseStream,
                            Grpc.Core.ServerCallContext context)
        {
            List<Settings> responses = null;

            string userid = request.Userid;
            List<String> settings = db.GetUserSettings(userid, "site");
            foreach (var setting in settings)
            {
                await responseStream.WriteAsync(new Settings { Userid = userid, Field = setting });
            }
            Console.WriteLine("\nSettings sent to client. Userid: " + userid);

            //responses.Add();
            //лямбдой 
            //responses = db.GetUserSettings(userid, "site").Cast<List<Settings>>(){ new Settings { }};
            //settings.FindAll((feature) => feature.Exists() && request.Contains(feature.Location));
            //получаем из бд настройки для конкретного пользователя
            //foreach (var response in responses)
            //{
            //    await responseStream.WriteAsync(response);
            //}
        }
    }

    class RSSReader
    {
        public static string ReadFeed(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            String summ = " ";
            try
            {
                //summ = feed.Items.First().Summary.Text;


                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    Console.WriteLine(subject);
                    String summary = item.Summary.Text;
                    //Console.WriteLine(summary + "\n");


                    if (summary != null)
                        summ = summary;
                }
            }
            catch
            {
                Console.WriteLine("Error while reading RSS-feed");
            }
            return summ;
        }
        public static List<SyndicationItem> ReadFeed2(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            List<SyndicationItem> customfeed = new List<SyndicationItem>();
            reader.Close();
            String summ = " ";
            try
            {
                //summ = feed.Items.First().Summary.Text;


                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    //Console.WriteLine(subject);
                    String summary = item.Summary.Text;
                    //Console.WriteLine(summary + "\n");


                    if (summary != null)
                        customfeed.Add(item);
                }
            }
            catch
            {
                Console.WriteLine("Error while reading RSS-feed");
            }
            return customfeed;
        }
        public static List<SyndicationItem> ReadUserFeed(string url, List<String> tags = null)
        {
            XmlReader reader = null;
            SyndicationFeed feed = null;
            List<SyndicationItem> customfeed = new List<SyndicationItem>();

            try
            {
                reader = XmlReader.Create(url);
                feed = SyndicationFeed.Load(reader);

                //выделить совпадающие тэги в отдельный список и передавать вместе с лентой

                //если лента совпадает по 1 или неск тэгам
                if (feed.Categories.Count > 0)
                {
                    if (ParseCategories(feed.Categories, tags).Count > 0)
                        return feed.Items.ToList();//item.Categories.ToList<SyndicationCategory>
                }
                else
                    Console.WriteLine("No categories");
                //feed.Categories;
                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    Console.WriteLine("SUBJECT: \n" + subject);
                    String summary = null;
                    if (item.Summary != null) summary = item.Summary.Text;
                    else
                    {
                        foreach (SyndicationElementExtension ext in item.ElementExtensions)
                        {
                            if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                                summary = ext.GetObject<XElement>().Value;
                        }
                    }
                    //summary = item.Content.ToString();

                    Console.WriteLine(summary.Length > 300 ? summary.Substring(0, 300) : summary + "\n");
                    Console.WriteLine("Published: "+item.PublishDate.DateTime.ToString());
                    if (summary != null)
                        if ((tags != null) && tags.Count > 0)
                        {
                            //если запись в ленте совпадает по 1 или неск тэгам
                            if (item.Categories.Count > 0)
                            {
                                if (ParseCategories(item.Categories, tags).Count > 0)
                                {
                                    customfeed.Add(item);
                                };//item.Categories.ToList<SyndicationCategory>
                            }
                            else
                                Console.WriteLine("No categories");
                        }
                        else
                            customfeed.Add(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError while reading RSS-feed " + url + ".\n+" + e.Message);
            }
            finally { reader.Close(); }
            return customfeed;
        }


        static List<String> ParseCategories(Collection<SyndicationCategory> categories, List<String> tags)
        {
            List<String> matches = new List<String>();
            if (categories.Count > 0)
            {

                foreach (SyndicationCategory category in categories)
                {

                    Console.WriteLine("Category Name: \n" + category.Name);
                    if (tags.Contains(category.Name) || tags.Any(s => category.Name.Contains(s)))
                        matches.Add(category.Name);

                    Console.WriteLine(category.ToString());

                }
            }
            else
                Console.WriteLine("No categories");
            return matches;

        }
    }
    class ServerMain
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { GrpcRssReader.BindService(new GrpcRssReaderImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");



            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
