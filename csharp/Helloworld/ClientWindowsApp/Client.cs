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

  using System;
  using Grpc.Core;
  using Helloworld;

  namespace RssClient
  {
    class ClientMain
    {
      Channel channel;
      Greeter.GreeterClient client;
      String user;
      public event EventHandler<string> NewsRecieved;

      public ClientMain()
      {
        channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

        client = new Greeter.GreeterClient(channel);
        user = "Kate";

        var reply = client.SayHello(new HelloRequest { Name = user });
        Console.WriteLine("Greeting: " + reply.Message);

        var secondReply = client.SayHelloAgain(new HelloRequest { Name = user });
        Console.WriteLine("Greeting: " + secondReply.Message);


        //var newsReply = client.FindNews(new NewsRequest { Username = user, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
        //Console.WriteLine("\n" + newsReply.Summary);

      }
      //public static void Main(string[] args)
      //    {
      //        channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

      //        client = new Greeter.GreeterClient(channel);
      //        user = "Kate";

      //        var reply = client.SayHello(new HelloRequest { Name = user });
      //        Console.WriteLine("Greeting: " + reply.Message);

      //        var secondReply = client.SayHelloAgain(new HelloRequest { Name = user });
      //        Console.WriteLine("Greeting: " + secondReply.Message);

      //  var newsReply = client.FindNews(new NewsRequest { Username = user, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
      //  Console.WriteLine("\n" + newsReply.Summary);

      //  channel.ShutdownAsync().Wait();
      //        Console.WriteLine("Press any key to exit...");
      //        Console.ReadKey();
      //    }
      public void GetNews()
      {
        var newsReply = client.FindNews(new NewsRequest { Username = user, Url = "http://domiksolnechnoykoshki.blogspot.com/rss.xml" });
        NewsRecieved(this, newsReply.Summary);
      }
      public void CloseClient()
      {

        channel.ShutdownAsync().Wait();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
      }
    }


}
