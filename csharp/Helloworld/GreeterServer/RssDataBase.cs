using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace RssServer
{
    class RssDataBase:IDisposable
    {
        public enum SettingsType { site =  0, tag = 1}
        SqlConnection connection = null;
        String connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\STUDY\\REPOS\\GrpcPractice\\csharp\\Helloworld\\GreeterServer\\RssDatabase.mdf;Integrated Security = True";
        
        //SqlConnectionStringBuilder connection;
        //какой модификатор лучше использовать для инкапсуляции
        public bool Connect() {
            //bool переменная для возврата+ мб св-во в классе для того чтобы избежать постоянной проверки
            try
            {
                if (connection == null)
                    connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                    // new SqlConnectionStringBuilder();
                connection.Open();
                return true;
            }
            catch(SqlException e) { Console.WriteLine(e.Message); }
            catch { Console.WriteLine("Error when trying to connect to database"); }
            return false;
        }
        public string AddUser(string username, string password) {

            string userid = null;
            try
            {
                if (Connect())
                {
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand sqlCheck = new SqlCommand("SELECT COUNT(id) FROM users", connection, transaction);
                    String query = "SELECT MAX(id) FROM users";
                    SqlCommand sql = new SqlCommand(query, connection, transaction);
                    //берем максимальный userid +1 sequence trigger

                    string maxid = sqlCheck.ExecuteScalar().ToString() != "0" ? sql.ExecuteScalar().ToString() : "00000";
                    userid = (Int64.Parse(maxid) + 1).ToString();   //maxid ==""?"00000":
                    query = "INSERT INTO users VALUES (\'" + userid + "\', \'" + username + "\',\'" + password + "\'); COMMIT;";
                    sql.CommandText = query;
                    sql.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while adding user to DB.\n+" +
                            e.Message);
            }
            return userid;
        }
        public string Authenticate(string username, string password) {
            string userid = null;
            if (Connect()){
                String query = "SELECT id, password FROM users WHERE username = \'" + username+"\'";
                SqlCommand sql = new SqlCommand(query,connection);
                //брать 1 столбец и преобразовывать сразу в List
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                Console.WriteLine("Username  "+ username);
                if ((reader.HasRows)&&(
                reader[1].ToString().Contains(password))){
                    //генерировать токен в базе?
                    //this.username = this.user = username;
                    //authtoken = authReply.Authtoken;

                    Console.WriteLine("Password  " + reader[1].ToString());

                    Console.WriteLine("Userid  " + reader[0].ToString());
                    userid = reader[0].ToString();
                    //return true;
                }
                reader.Close();
            }
            return userid;
        }
        public void ChangeUserSettings() { }
        public List<String> GetUserSettings(string userid, string type = "site") //enum Settings.Type site|tag
        {
            List<string> settings = new List<String>();
            SqlCommand sql;
            SqlDataReader reader = null;
            try
            {
                if (Connect())
                {
                    String query = "SELECT id, " + type + " FROM " + type + "s WHERE id = \'" + userid + "\'";
                    sql = new SqlCommand(query, connection);
                    //брать 1 столбец и преобразовывать сразу в List
                    reader = sql.ExecuteReader();
                    while (reader.Read()) { settings.Add(reader[1].ToString()); }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading settings from DB.\n+" +
                            e.Message);
            }
            finally
            {
                if((reader !=null)&&!reader.IsClosed)
                        reader.Close();
            }
            return settings;
        }
        public int SetUserSettings(string userid, List<String> settings, string type = "site") //enum Settings.Type site|tag
        {
            int count = 0;

            try
            {
                if (Connect())
                {
                    SqlTransaction transaction = connection.BeginTransaction();
                    foreach (String setting in settings)
                    {
                            String query = "INSERT INTO " + type + "s VALUES (\'" + userid + "\', \'" + setting + "\',null,null);";  // COMMIT;
                            SqlCommand sql = new SqlCommand(query, connection, transaction);
                            //брать 1 столбец и преобразовывать сразу в List
                            count += sql.ExecuteNonQuery();
                            Console.WriteLine("Added");
                    }
                    SqlCommand sqlC = new SqlCommand("COMMIT;", connection, transaction);
                    //брать 1 столбец и преобразовывать сразу в List
                    sqlC.ExecuteNonQuery();
                    Console.WriteLine("Committed");
                }

            }
            catch(Exception e) { Console.WriteLine("\nError while adding settings to DB.\n+" +
                e.Message); }
            return count;
        }

        public void Dispose()
        {
            ((IDisposable)connection).Dispose();
        }
        //использовать using connection  dbcontext
    }
}
