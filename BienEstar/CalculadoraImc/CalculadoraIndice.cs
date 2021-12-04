using BienEstar.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BienEstar.Calcular;
namespace BienEstar.CalculadoraImc
{
    public partial class CalculadoraIndice : Form
    {
        CDatos productos = new CDatos();
        private string id = null;
        private bool editar = false;
        public CalculadoraIndice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try { 
            double Peso = Convert.ToDouble(nombre.Text);
            double Altura = Convert.ToDouble(altura.Text);
            CalcularImc calculadora = new CalcularImc();
            int Resultado = calculadora.Calcular(Peso, Altura);
                resultado.Text =   Convert.ToString(Resultado);

            string Estado= calculadora.pesoIdeal(Resultado);
                estado.Text = Estado;
                if (Estado.Equals("Obesidad"))
                {

                    MessageBox.Show("Wow. Estas demasiado obeso, deberias tomar cartas en el asunto", "Obesidad",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void CalculadoraIndice_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CDatos refrescar = new CDatos();
            Tabla.DataSource = refrescar.MostrarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                double Peso = Convert.ToDouble(peso.Text);
                double Altura = Convert.ToDouble(altura.Text);
                CalcularImc calculadora = new CalcularImc();
                int Resultado = calculadora.Calcular(Peso, Altura);
                resultado.Text =   Convert.ToString(Resultado);

                string Estado = calculadora.pesoIdeal(Resultado);
                pesoestado.Text = Estado;
                if (Estado.Equals("Obesidad"))
                {

                    MessageBox.Show("Wow. Estas demasiado obeso, deberias tomar cartas en el asunto", "Obesidad",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                productos.InsertarDatos(nombre.Text, peso.Text,altura.Text, Estado);
                MessageBox.Show("Se inserto Correctamente");
               // Info.Text = "Haga doble click sobre la mercancia que desea editar";
                MostrarProductos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Limpiar()
        {

            nombre.Clear(); peso.Clear(); altura.Clear();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            string message = "¿Quieres borrar este registro?";
            string title = "Eliminar Registro";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                id = Tabla.CurrentRow.Cells["id"].Value.ToString();

                productos.Eliminar(id);
                MostrarProductos();
                Limpiar();
                MessageBox.Show("Registro eliminado con exito");
            }

        }

        private void Tabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Tabla.CurrentRow.Cells["id"].Value.ToString();
        }
    }
}
