using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace RssServer
{
    class DataBase
    {
        SqlConnection connection;
        String connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\STUDY\\REPOS\\GrpcPractice\\csharp\\Helloworld\\GreeterServer\\RssDatabase.mdf;Integrated Security = True";
        
        //SqlConnectionStringBuilder connection;
        //какой модификатор лучше использовать для инкапсуляции
        public void Connect() {
            try
            {
                connection = new SqlConnection(connectionString);// new SqlConnectionStringBuilder();
            }
            catch { Console.WriteLine("Error when trying to connect to database"); }
        }
        public void AddUser() { }
        public bool Authenticate(string username, string password) {

            if (true)
            {
                //генерировать токен в базе?
                //this.username = this.user = username;
                //authtoken = authReply.Authtoken;
                return true;
            }
            return false;
        }
        public void ChangeUserSettings() { }
        public List<String> GetUserSettings()
        {
            return new List<string>();
        }
    }
}
