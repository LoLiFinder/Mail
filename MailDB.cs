using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class Services
    {
        private int id;
        private string nameServices;
        private string description;
        private string price;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string NameServices
        {
            get => nameServices;
            set => nameServices = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Price
        {
            get => price;
            set => price = value;
        }

        public Services(int id, string nameServices, string description, string price)
        {
            this.id = id;
            this.nameServices = nameServices;
            this.description = description;
            this.price = price;
        }

        public Services()
        {
        }
    }

    public enum User
    {
    Admin = 0,
    Operator = 1,
    User = 2,
    NoUser = 3

    }
    class MailDB
    {
        
       private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
       private OleDbConnection connection;
       public MailDB()
       {
       connection = new OleDbConnection(connectionString);


       }


       public List<Services> LoadListService()
       {
           connection.Open();
           OleDbCommand comand = new OleDbCommand("SELECT * FROM services;", connection);
           OleDbDataReader reader = comand.ExecuteReader();
           List<Services> list = new List<Services>();
           while (reader.Read())
           {
              list.Add(new Services((int) reader[0],reader[1].ToString(),reader[2].ToString(),reader[3].ToString())); 
           }

           return list;
       }

       public User authUser(string login,string password)
       {
            
            connection.Open();
            OleDbCommand comand = new OleDbCommand(String.Format("SELECT * FROM users WHERE login='{0}' AND pass='{1}'", login,password),connection);
            OleDbDataReader reader = comand.ExecuteReader();
            if (!reader.HasRows)
            {
                connection.Close();
                return User.NoUser;
            }

            reader.Read();
            int type = (int) reader[3];
            switch ((User) type)
            {
                case User.Admin:
                    connection.Close();
                    reader.Close();
                    return User.Admin;
                
                case User.Operator:
                    connection.Close();
                    reader.Close();
                    return User.Operator;
               
                case User.User:
                    connection.Close();
                    reader.Close();
                    return User.User;
                
                default:
                    connection.Close();
                    reader.Close();
                    return User.NoUser;
                
            }
            

        }

        public void logAuthuser(string login) {
            connection.Open();
            OleDbCommand comand = new OleDbCommand(String.Format("SELECT id FROM users WHERE login='{0}';",login), connection);
            OleDbDataReader reader = comand.ExecuteReader();
            reader.Read();
            OleDbCommand writeData = new OleDbCommand(String.Format("INSERT INTO "),connection);
            connection.Close();
        }

    }
}
