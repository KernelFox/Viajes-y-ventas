using System;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class Empleado:Persona
    {
        private int _legajo;
        private int _ventas;
        private static int contador = 0;

        public string nombreyApellido
        {
            get
            {
                return this._nombreyApellido;
            }
        }

        public int dni
        {
            get
            {
                return this._dni;
            }
        }

        public int legajo
        {
            get
            {
                return this._legajo;
            }
        }

        public int ventas
        {
            get
            {
                return this._ventas;
            }
        }
        
        public Empleado(string nombre, int dni)
        {
            this._nombreyApellido = nombre;
            this._dni = dni;
            this._ventas = 0;
            this._legajo = contadorLegajos();
        }

        private static int contadorLegajos(){

            contador++;
            return contador;
        }

        public void realizarVenta()
        {
            this._ventas++;
        }

        public void cancelarVenta()
        {
            this._ventas--;
        }

    }
}