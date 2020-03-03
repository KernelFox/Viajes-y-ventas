using System;
using System.Collections;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class Excursion
    {
        private int _numero;
        private string _nombre;
        private string _recorrido;
        private string _horarioSalida;
        private int _duracion;
        private string _diasDeSalida;
        private int _vecesSolicitada;
        private Omnibus _omnibus;
        private DateTime _fecha;
        private static int contador;

        public DateTime fecha
        {
            get
            {
                return this._fecha;
            }
        }
        
        
        public string nombre
        {
            get
            {
                return this._nombre;
            }
        }
        
        public string recorrido
        {
            get
            {
                return this._recorrido;
            }
        }

        public string horarioDeSalida
        {
            get
            {
                return this._horarioSalida;
            }
        }

        public int duracion
        {
            get
            {
                return this._duracion;
            }
        }

        public int vecesSolicitada
        {
            get
            {
                return this._vecesSolicitada;
            }
        }

        public string diasDeSalida
        {
            get
            {
                return this._diasDeSalida;
            }
        }

        public Omnibus omnibus
        {
            get
            {
                return this._omnibus;
            }
        }

        public int numeroExcursion
        {
            get
            {
                return this._numero;
            }
        }
        private static int contadorExcursiones(){
            contador++;
            return contador;
        }

        public void incrementarSolicitudes()
        {
            this._vecesSolicitada++;
        }

        public void decrementarSolicitudes()
        {
            this._vecesSolicitada--;
        }

        public Excursion(string nombre, string recorrido, string hsalida, int duracion, string diaSalida, Omnibus omnibus, DateTime fecha)
        {
            this._nombre = nombre;
            this._recorrido = recorrido;
            this._horarioSalida = hsalida;
            this._duracion = duracion;
            this._diasDeSalida = diaSalida;
            this._omnibus = omnibus;
            this._fecha = fecha;
            this._numero = contadorExcursiones();
            this._vecesSolicitada = 0;
        }


    }
}