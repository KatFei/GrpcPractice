//using System;
//using System.Collections.Generic;
//using System.Text;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Google.Protobuf;
//using Grpc.Core;
//using Grpc.Core.Utils;
////using NUnit.Framework;
//using Grpc.Core.Testing;

//namespace GrpcRssReader
//{
//    namespace JsonImplementation
//    {
//        public static class GenericService {
//            readonly static Marshaller<byte[]> ByteArrayMarshaller = new Marshaller<byte[]>((b) => b, (b) => b);
//            //public readonly <MsgClasses.NewsReply> static Marshaller<MsgClasses.NewsReply> marshallerFor(MsgClasses.NewsReply clz)
//            //{
//            //    //Gson gson = new Gson();

//            //    return new Marshaller<MsgClasses.NewsReply>()
//            //    {
//            //          //override public InputStream stream(T value)
//            //          //  {
//            //          //      return new ByteArrayInputStream(Google.Protobuf.JsonFormatter.ToDiagnosticString(value, clz).getBytes(StandardCharsets.UTF_8));
//            //          //  }

//            //            //    override
//            //            //  public T parse(InputStream stream)
//            //            //    {
//            //            //        return gson.fromJson(new InputStreamReader(stream, StandardCharsets.UTF_8), clz);
//            //            //    }
//            //    };
//            //}

//            public readonly static Method<byte[], byte[]> StreamingCallMethod = new Method<byte[], byte[]>(
//            MethodType.DuplexStreaming,
//            "grpc.testing.BenchmarkService",
//            "StreamingCall",
//            ByteArrayMarshaller,
//            ByteArrayMarshaller
//        );

//            public static ServerServiceDefinition BindHandler(DuplexStreamingServerMethod<byte[], byte[]> handler)
//            {
//                return ServerServiceDefinition.CreateBuilder()
//                    .AddMethod(StreamingCallMethod, handler).Build();
//            }
//        }
//    }
//}
