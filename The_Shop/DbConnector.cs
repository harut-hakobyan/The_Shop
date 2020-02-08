using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace The_Shop
{
    static class DbConnector
    {
        public static string serverName = "remotemysql.com";
        public static string userName = "KKiyor0a7V";
        public static string dbName = "KKiyor0a7V";
        public static string port = "3306";
        public static string password = "t6DnRniPl3";
        public static string connStr = "server=" + serverName +
            ";user=" + userName +
            ";database=" + dbName +
            ";port=" + port +
            ";password=" + password + ";";
        public static MySqlConnection conn = new MySqlConnection(connStr);
    }
}
