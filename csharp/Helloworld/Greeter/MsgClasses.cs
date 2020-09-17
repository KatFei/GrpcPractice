//using System;
//using System.Collections.Generic;
//using System.Text;
//using Grpc.Core;


//namespace GrpcRssReader
//{
//    namespace MsgClasses
//    {
//        static class AuthRequest      //sealed
//        {
//            //Google.Protobuf.JsonFormatter;
                
//            static byte[] username;
//            static byte[] password;
//        }

//        static class AuthReply
//        {
//            static byte[] checkresult;
//            static byte[] authtoken;
//        }

//        static class SettingsRequest
//        {
//            static byte[] userid;
//            static byte[] authtoken;
//        }

//        static class Settings
//        {
//            static byte[] userid;
//            static byte[] field;
//        }

//        static class SettingsSavedReply
//        {
//            static byte[] count;
//        }

//        static class NewsRequest
//        {
//            static byte[] userid;
//            static byte[] authtoken; //url
//        }

//        static class NewsReply
//        {
//            static byte[] subject;
//            static byte[] summary;
//            static byte[] url;
//            static byte[] topic;
//            static byte[] site;
//            static byte[] date;
//            static byte[] id; 
//        }

//        static class DeleteRequest
//        {
//            static byte[] checkresult;
//            static byte[] authtoken;
//        }

//    }
//}
