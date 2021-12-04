using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BienEstar.Modelo
{
    internal class MDatos
    {
        Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable MostrarProductos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarDatos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void Insertar(string nombre, double peso, double altura, string estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@peso", peso);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Eliminar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }
        public void UpdateMercancia(int id, string descripcion, double existencia, string comentario, string status, int noEliminable)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarMercancia";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@existencia", existencia);
            comando.Parameters.AddWithValue("@comentario", comentario);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@noeliminable ", noEliminable);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }




    }
}
