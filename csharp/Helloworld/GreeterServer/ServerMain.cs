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

namespace GreeterServer
{
    class GreeterImpl : Greeter.GreeterBase
    {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
        public override Task<HelloReply> SayHelloAgain(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello again " + request.Name });
        }
    public override Task<NewsReply> FindNews(NewsRequest request, ServerCallContext context)
    {
      return Task.FromResult(new NewsReply { Subject = "Hello " + request.Username, Summary =  RSSReader.ReadFeed(request.Url)});
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
    }
    class ServerMain
    {
        const int Port = 50051;

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
