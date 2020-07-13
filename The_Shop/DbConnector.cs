using MySql.Data.MySqlClient;

namespace The_Shop
{
    static class DbConnector
    {
        public static string serverName = "sql12.freemysqlhosting.net";
        public static string userName = "sql12354600";
        public static string dbName = "sql12354600";
        public static string port = "3306";
        public static string password = "7bXjKQMwJ4";
        public static string connStr = "server=" + serverName +
            ";user=" + userName +
            ";database=" + dbName +
            ";port=" + port +
            ";password=" + password + ";";
        public static MySqlConnection conn = new MySqlConnection(connStr);
    }
}
