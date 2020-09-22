using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

using Grpc.Core;
using Helloworld;
using System.ServiceModel.Syndication;
using System.Security.Policy;

namespace RssClient
{
    public class ClientMain
    {
        Channel channel;
        GrpcRssReader.GrpcRssReaderClient client;
        private String userid = null;
        private String username = " ";
        private String authtoken;
        public bool loggedin = false;
        private List<String> sites = null, tags = null;
        private List<NewsReply> news = null;//private List<SyndicationItem> news = null;

        public List<string> Sites { get => sites; }

        //public event EventHandler<string> NewsRecieved;
        public event EventHandler<NewsReply> NewsRecieved;

        public event EventHandler<int> SettingsSaved;
        public ClientMain()
        {
            channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            client = new GrpcRssReader.GrpcRssReaderClient(channel);
            sites = new List<string>();
            tags = new List<string>();
            news = new List<NewsReply>();
            //var newsReply = client.FindNews(new NewsRequest { Username = user, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
            //Console.WriteLine("\n" + newsReply.Summary);

        }

        internal string CreateUser(string user, string pwd)
        {
            var authReply = client.AddUser(new AuthRequest { Username = user, Password = pwd });
            //string userid = null;
            if (authReply.Checkresult == "true")
            {
                this.username = user;
                //loggedin = true;
                userid = authtoken = authReply.Authtoken;
            }
            return userid;
        }

        public void Check()
        {
            var reply = client.SayHello(new HelloRequest { Name = username });
            Console.WriteLine("Greeting: " + reply.Message);

            var secondReply = client.SayHelloAgain(new HelloRequest { Name = username });
            Console.WriteLine("Greeting: " + secondReply.Message);

            //var newsReply = client.FindNews2(new NewsRequest { Userid = userid, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
            //Console.WriteLine("\n" + newsReply.Summary);
        }
        public bool Authenticate(string user, string password)
        {
            var authReply = client.AuthenticateUser(new AuthRequest { Username = user, Password = password });
            if (authReply.Checkresult == "true")
            {
                this.username = user;
                loggedin = true;
                userid = authtoken = authReply.Authtoken;
                return true;
            }
            return false;
        }
        //public async void GetNews()
        //{
        //      if (userid == null)
        //          userid = "00000";
        //  var newsReply = client.FindNews(new NewsRequest { Userid = userid, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
        //  NewsRecieved(this, newsReply);
        //}

        public async void GetNews()
        {
            if (true) //(loggedin)
            {
                //tmp
                if (userid == null)
                    userid = "00000";
                //List<String> sites = new List<string>();//, tags = new List<string>();
                using (var call = client.FindNews(new NewsRequest { Userid = userid, Url = "" }))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        news.Add(call.ResponseStream.Current);
                        NewsRecieved(this, news.Last<NewsReply>());
                    }
                }
                // загружать в xml-документ

                // из xml-  уже в форму

                //settings up to date !!! (check from server & update xml)
            }
            //return sites;
        }
        public void CloseClient()
        {

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        public static SyndicationItem FromGrpcNewsItem(NewsReply newsReply)
        {
            return new SyndicationItem(newsReply.Subject, newsReply.Summary, new Uri(newsReply.Url), newsReply.Id, DateTime.Parse(newsReply.Date));
        }
        public async void SaveSettings(List<String> sites, List<String> tags)
        {
            //try{ }catch { }
            if (true) //(loggedin)
            {                
                //tmp
                if (userid == null)
                    userid = "00000";
                SettingsSavedReply sitesSaved = null, tagsSaved = null;
                using (var call = client.SaveSites())
                {
                    foreach (String site in sites)
                    {
                        Settings set = new Settings { Field = site, Userid = userid };
                        await call.RequestStream.WriteAsync(set);
                        //client.SaveSites(new SettingsRequest { Userid = })
                    }
                    await call.RequestStream.CompleteAsync();
                    sitesSaved = await call.ResponseAsync;
                }
                //using (var call = client.SaveTags())
                //{
                //    foreach (String tag in tags)
                //    {
                //        Settings set = new Settings { Field = tag, Userid = userid };
                //        await call.RequestStream.WriteAsync(set);
                //        //client.SaveSites(new SettingsRequest { Userid = })
                //    }
                //    await call.RequestStream.CompleteAsync();
                //    tagsSaved = await call.ResponseAsync;
                //}
                //if((sitesSaved!=null)||tagsSaved!=null)
                //SettingsSaved(this, sitesSaved.Count + tagsSaved.Count);
            }

        }
        public async void GetSettings()
        {
            if (loggedin)
            {
                //List<String> sites = new List<string>();//, tags = new List<string>();
                using (var call = client.LoadSitesList(new SettingsRequest { Userid = userid, Authtoken = authtoken }))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        Sites.Add(call.ResponseStream.Current.Field);
                    }
                }
                // загружать в xml-документ

                // из xml-  уже в форму

                //settings up to date !!! (check from server & update xml)
            }
            //return sites;
        }


    }


}
