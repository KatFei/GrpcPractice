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

namespace GreeterServer
{
    class GreeterImpl : Greeter.GreeterBase
    {
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
            NewsReply newsReply = new NewsReply
            {
                Subject = item.Title.Text,
                Summary = item.Summary.Text,
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
            // . Connect
            // .DataTable è ò.ï.
            // DataBase. Authenticate
            return Task.FromResult(new AuthReply { Checkresult = "true",  Authtoken = "Authtoken" });// base.AuthenticateUser(request, context);
            }
        public override Task<NewsReply> FindNews(NewsRequest request, ServerCallContext context)
        {
            //streaming
            return Task.FromResult(ConvertToRssItem(RSSReader.ReadFeed2(request.Url)[0]));
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
      try {
        //summ = feed.Items.First().Summary.Text;

      
          foreach (SyndicationItem item in feed.Items)
          {
            String subject = item.Title.Text;
            Console.WriteLine(subject);
            String summary = item.Summary.Text;
            Console.WriteLine(summary + "\n");

          
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
                    Console.WriteLine(subject);
                    String summary = item.Summary.Text;
                    Console.WriteLine(summary + "\n");


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
    }
    class ServerMain
    {
        const int Port = 50051;
        static DataBase db;
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
      //RSSReader.ReadFeed("http://blogname.blogspot.com/rss.xml");
      Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");


            
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
