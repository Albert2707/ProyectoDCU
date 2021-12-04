using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienEstar.Calcular
{
    class CalcularImc
    { 
        public int Calcular(double pesoKg, double altura)
        {
             double Altura = Math.Pow(altura, 2);
            double imc = (pesoKg/Altura);
            int IMC = Convert.ToInt32(imc);
            return IMC;
        }

        public string pesoIdeal(int imc)
        {
            string EstadoPeso = "";
            if (imc <18)
            {
                EstadoPeso = "Injerior a su peso ideal";

            }

            if (imc >=18 && imc <=24)
            {
                EstadoPeso = "Peso Ideal";

            }
            if (imc >= 25 && imc <30)
            {
                EstadoPeso = "Sobre Peso";
            }
           if(imc >30)
            {
                EstadoPeso = "Obesidad";

            }
           return EstadoPeso;
        }
    }
}
