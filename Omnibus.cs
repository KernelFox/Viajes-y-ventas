using System;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class Omnibus
    {
        private string _marca;
        private string _modelo;
        private int _capacidad;
        private int _numeroDeUnidad;
        private string _tipo;

        public string marca
        {
            get
            {
                return _marca;
            }
        }

        public string modelo
        {
            get 
            {
                return _modelo;
            }
        }
        
        public int capacidad
        {
            get
            {
                return _capacidad;
            }
        }

        public int numeroDeUnidad 
        {
            get
            {
                return _numeroDeUnidad;
            }
        }

        public string tipo 
        {
            get
            {
                return _tipo;
            }
        }

        public Omnibus(string marca, string modelo, int capacidad, int unidad, string tipo)
        {
            this._marca = marca;
            this._modelo = modelo;
            this._capacidad = capacidad;
            this._numeroDeUnidad = unidad;
            this._tipo = tipo;
        }
    }
}