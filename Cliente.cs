using System;
using System.Collections;
using System.Collections.Generic;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class Cliente:Persona
    {
        private int _numeroCliente;
        private int _excursionesCompradas;
        private List<Excursion> _compradasExcursiones = new List<Excursion>();
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

        public int numeroDeCliente
        {
            get
            {
                return this._numeroCliente;
            }
        }

        public int excursionesCompradas
        {
            get
            {
                return this._excursionesCompradas;
            }
        }

        public List<Excursion> compradasExcursiones
        {
            get
            {
                return this._compradasExcursiones;
            }
        }

        public Cliente(string nombre, int dni)
        {
            this._nombreyApellido = nombre;
            this._dni = dni;
            this._excursionesCompradas = 0;
            this._compradasExcursiones = new List<Excursion>();
            this._numeroCliente = asignarNumeroCliente();
        }

        private static int asignarNumeroCliente()
        {
            contador++;
            return contador;
        }

        public void comprarExcursion()
        {
            this._excursionesCompradas++;
        }

        public void devolverExcursion()
        {
            this._excursionesCompradas--;
        }


    }
}