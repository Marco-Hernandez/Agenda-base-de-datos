using System;
using MySql.Data.MySqlClient;

namespace Programa
{
    public class Contacto : MySql
    {
        public Contacto()
        {
        }

        public void mostrarTodos()
        {
            this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(),
            myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            if (!myReader.HasRows)
                Console.WriteLine("La base de datos esta vacia");
            while (myReader.Read())
            {
                string Id = myReader["Id"].ToString();
                string Nombre = myReader["Nombre"].ToString();
                string Telefono = myReader["Telefono"].ToString();
                Console.WriteLine("\nId: " + Id +
                "\nNombre: " + Nombre +
                "\nTelefono: " + Telefono);
            }

            myReader.Close();
            myReader = null;
            myCommand.Dispose();
            myCommand = null;
            this.cerrarConexion();
        }

        public string consultaId(string Id)
        {
            string consulta = "";
            this.abrirConexion();
            string query = "Select * From contacto Where id = ?id";
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("?id", Id);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                consulta = myReader["Id"].ToString() +
                    myReader["Nombre"].ToString() +
                    myReader["Telefono"].ToString();
            }
            return consulta;
        }

        public void insertarRegistroNuevo(string Nombre, string Telefono)
        {
            this.abrirConexion();
            string sql = "INSERT INTO `contacto` (`nombre`, `telefono`) VALUES ('" + Nombre + "', '" + Telefono + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        public void editarRegistro(string Id, string Nombre, string Telefono)
        {
            this.abrirConexion();
            string sql = "UPDATE `contacto` SET `nombre`='" + Nombre + "',`telefono`='" + Telefono + "'  WHERE (`id`='" + Id + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        public void eliminarRegistroPorId(string Id)
        {
            this.abrirConexion();
            string sql = "DELETE FROM `contacto` WHERE (`id`='" + Id + "')";
            this.ejecutarComando(sql);
            this.cerrarConexion();
        }

        private int ejecutarComando(string sql)
        {
            MySqlCommand myCommand = new MySqlCommand(sql, this.myConnection);
            int afectadas = myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myCommand = null;
            return afectadas;
        }

        private string querySelect()
        {
            return "SELECT * " +
            "FROM contacto";
        }
    }
}