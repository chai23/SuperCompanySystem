using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超好企業系統
{
    public class MySqlHelper
    {
        private string connectionString;

        public MySqlHelper()
        {
            this.connectionString = "Server=192.168.1.127;Database=database;User ID=user;Password=chaaii23;";
            //192.168.1.127
            //122.117.156.246
        }

        // 讀取資料
        public DataTable ReadData(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception ex)
                    {
                        if (ex is MySqlException)
                        {
                            Console.WriteLine(ex.Message);
                            return null;
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                            return null;
                        }
                    }

                }

            }
        }

        // 修改資料
        public string ReviseData(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        return command.ExecuteNonQuery().ToString();
                    }
                    catch (Exception ex)
                    {
                        if (ex is MySqlException)
                        {
                            Console.WriteLine(ex.Message);
                            return "-1";
                        }
                        else
                        {
                            Console.WriteLine(ex.Message);
                            return ex.Message;
                        }
                    }
                }
            }
        }

        // 新增資料
        public string InsertData(string query)
        {
            return ReviseData(query);
        }

        public string RemoveData(string query)
        {
            return ReviseData(query);
        }

        public string TryConnect()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return "資料庫連接成功";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
