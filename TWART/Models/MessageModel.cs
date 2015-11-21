using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class MessageModel
    {
         private MySqlConnection connect;
        private string _connectionString;

        public MessageModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateMessage(Message message)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewMessage";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("mText", message.MessageBody);
                        cmd.Parameters.AddWithValue("mEmail", message.Email);
                        cmd.Parameters.AddWithValue("mName", message.Name);



                        ret = int.Parse(cmd.ExecuteScalar().ToString());

                        transaction.Commit();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
            return ret;
        }

       

        public void DeleteMessage(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteMessage";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("MID", ID);

                        cmd.ExecuteNonQuery();

                        transaction.Commit();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
        }

        // The main method to get a user account.
        public Message SearchMessage(int ID)
        {
            var message = new Message();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetMessage";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        message.MessageID = int.Parse(reader["MID"].ToString());
                        message.MessageBody = reader["mText"].ToString();
                        message.Email = reader["mEmail"].ToString();
                        message.Name = reader["mName"].ToString();

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return message;
            }
        }

        public Message SearchMessage(Message message)
        {
            return SearchMessage(message.MessageID);
        }
        public List<Message> ListMessages()
        {
            var messageList = new List<Message>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListMessage";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var message = new Message();
                        message.MessageID = int.Parse(reader["MID "].ToString());
                        message.MessageBody = reader["mText"].ToString();
                        message.Name = reader["mEmail"].ToString();
                        message.Email = reader["mName"].ToString();

                        messageList.Add(message);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return messageList;
            }
        }

    }
}