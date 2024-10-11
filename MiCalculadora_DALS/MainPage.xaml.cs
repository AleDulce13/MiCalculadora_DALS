using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiCalculadora_DALS
{
    public partial class MainPage : ContentPage
    {
        string operacionActual;
        double valor1, valor2;
        bool esNuevoNumero;

        public MainPage()
        {
            InitializeComponent(); 
            LimpiarTodo();
        }
        void Numero_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string numero = button.Text;

            if (esNuevoNumero)
            {
                Pantalla.Text = numero;
                esNuevoNumero = false;
            }
            else
            {
                if (!(numero == "." && Pantalla.Text.Contains("."))) 
                {
                    Pantalla.Text += numero;
                }
            }
        }

        void Operacion_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            operacionActual = button.Text;
            valor1 = Convert.ToDouble(Pantalla.Text);
            esNuevoNumero = true;
        }

        void Igual_Clicked(object sender, EventArgs e)
        {
            valor2 = Convert.ToDouble(Pantalla.Text);
            double resultado = 0;

            switch (operacionActual)
            {
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
                case "x":
                    resultado = valor1 * valor2;
                    break;
                case "/":
                    if (valor2 != 0)
                        resultado = valor1 / valor2;
                    else
                        DisplayAlert("Error", "No se puede dividir entre cero", "OK");
                    break;
                case "%":
                    resultado = valor1 % valor2;
                    break;
            }

            Pantalla.Text = resultado.ToString();
            esNuevoNumero = true;
        }

        void LimpiarTodo_Clicked(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        void LimpiarTodo()
        {
            Pantalla.Text = "0";
            valor1 = valor2 = 0;
            operacionActual = string.Empty;
            esNuevoNumero = true;
        }

        void BorrarDigito_Clicked(object sender, EventArgs e)
        {
            if (Pantalla.Text.Length > 1)
                Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
            else
                Pantalla.Text = "0";
        }

        void Punto_Clicked(object sender, EventArgs e)
        {
            if (!Pantalla.Text.Contains("."))
                Pantalla.Text += ".";
        }
    }
}

