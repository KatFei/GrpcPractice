using System;
using System.Collections.Generic;
using System.Text;
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
using Grpc.Core;
//using Grpc.Core.Utils;
////using NUnit.Framework;
//using Grpc.Core.Testing;
using System.IO;

namespace GrpcRssReaderZ
{
    namespace MsgClasses
    {
        class AuthRequest      //sealed
        {
            //Google.Protobuf.JsonFormatter;

            static byte[] username;
            static byte[] password;
        }

        static class AuthReply
        {
            static byte[] checkresult;
            static byte[] authtoken;
        }

        static class SettingsRequest
        {
            static byte[] userid;
            static byte[] authtoken;
        }

        static class Settings
        {
            static byte[] userid;
            static byte[] field;
        }

        static class SettingsSavedReply
        {
            static byte[] count;
        }

        static class NewsRequest
        {
            static byte[] userid;
            static byte[] authtoken; //url
        }

        static class NewsReply
        {
            static byte[] subject;
            static byte[] summary;
            static byte[] url;
            static byte[] topic;
            static byte[] site;
            static byte[] date;
            static byte[] id;
        }

        static class DeleteRequest
        {
            static byte[] checkresult;
            static byte[] authtoken;
        }

    }

    public class GenericService
    {
        readonly static Marshaller<byte[]> ByteArrayMarshaller = new Marshaller<byte[]>((b) => b, (b) => b);

        //static Marshaller<MsgClasses.AuthRequest> marshallerFor(MsgClasses.AuthRequest clz) {
        //return new Marshaller<MsgClasses.AuthRequest>();
        //}

        public readonly static Method<byte[], byte[]> StreamingCallMethod = new Method<byte[], byte[]>(
        MethodType.DuplexStreaming,
        "grpc.testing.BenchmarkService",
        "StreamingCall",
        ByteArrayMarshaller,
        ByteArrayMarshaller
        );
        public static ServerServiceDefinition BindHandler(DuplexStreamingServerMethod<byte[], byte[]> handler)
        {
            return ServerServiceDefinition.CreateBuilder()
                .AddMethod(StreamingCallMethod, handler).Build();
        }

        static void //Marshaller<MsgClasses.AuthRequest> 
            marshallerFor(MsgClasses.AuthRequest clz)
        {
            Stream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);

            //return new Marshaller<MsgClasses.AuthRequest>();
        }
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
        }
    }
//    //using System;
//    //using System.Collections.Generic;
//    //using System.Text;
//    //using System;
//    //using System.Collections.Generic;
//    //using System.Diagnostics;
//    //using System.IO;
//    //using System.Linq;
//    //using System.Text.RegularExpressions;
//    //using System.Threading.Tasks;
//    //using Google.Protobuf;
//    //using Grpc.Core;
//    //using Grpc.Core.Utils;
//    ////using NUnit.Framework;
//    //using Grpc.Core.Testing;

//    //namespace GrpcRssReader
//    //{
//    //    namespace JsonImplementation
//    //    {
//    //        public static class GenericService {
//    //            readonly static Marshaller<byte[]> ByteArrayMarshaller = new Marshaller<byte[]>((b) => b, (b) => b);
//    //            //public readonly <MsgClasses.NewsReply> static Marshaller<MsgClasses.NewsReply> marshallerFor(MsgClasses.NewsReply clz)
//    //            //{
//    //            //    //Gson gson = new Gson();

//    //            //    return new Marshaller<MsgClasses.NewsReply>()
//    //            //    {
//    //            //          //override public InputStream stream(T value)
//    //            //          //  {
//    //            //          //      return new ByteArrayInputStream(Google.Protobuf.JsonFormatter.ToDiagnosticString(value, clz).getBytes(StandardCharsets.UTF_8));
//    //            //          //  }

//    //            //            //    override
//    //            //            //  public T parse(InputStream stream)
//    //            //            //    {
//    //            //            //        return gson.fromJson(new InputStreamReader(stream, StandardCharsets.UTF_8), clz);
//    //            //            //    }
//    //            //    };
//    //            //}

//    //            public readonly static Method<byte[], byte[]> StreamingCallMethod = new Method<byte[], byte[]>(
//    //            MethodType.DuplexStreaming,
//    //            "grpc.testing.BenchmarkService",
//    //            "StreamingCall",
//    //            ByteArrayMarshaller,
//    //            ByteArrayMarshaller
//    //        );

//    //            public static ServerServiceDefinition BindHandler(DuplexStreamingServerMethod<byte[], byte[]> handler)
//    //            {
//    //                return ServerServiceDefinition.CreateBuilder()
//    //                    .AddMethod(StreamingCallMethod, handler).Build();
//    //            }
//    //        }
//    //    }
//    //}
//}
