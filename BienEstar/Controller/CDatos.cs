using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BienEstar.Modelo;
namespace BienEstar.Controller
{
    internal class CDatos
    {


        MDatos productos = new MDatos();
        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = productos.MostrarProductos();
            return tabla;
        }


        public void InsertarDatos(string nombre, string peso, string altura, string estado)
        {
            productos.Insertar( nombre, Convert.ToDouble(peso), Convert.ToDouble(altura), estado);
        }

        public void Eliminar(string id)
        {
            productos.Eliminar(Convert.ToInt32(id));
        }

        public void EditarMercancia(string id, string descripcion, string existencia, string comentario, string status, string noEliminable)
        {
            productos.UpdateMercancia(Convert.ToInt32(id), descripcion, Convert.ToDouble(existencia), comentario, status, Convert.ToInt32(noEliminable));
        }

    }
}
