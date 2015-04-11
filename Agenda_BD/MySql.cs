using System;
using MySql.Data.MySqlClient;

namespace Programa
{
    public class MySql
    {
        protected MySqlConnection myConnection;

        public MySql()
        {
        }

        protected void abrirConexion()
        {
            string connectionString =
            "Server=localhost;" +
            "Database=Agenda;" +
            "User ID=root;" +
            "Password=caselogic;" +
            "Pooling=false;";
            this.myConnection = new MySqlConnection(connectionString);
            this.myConnection.Open();
        }
        protected void cerrarConexion()
        {
            this.myConnection.Close();
            this.myConnection = null;
        }
    }
}