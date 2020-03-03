using System;
namespace Trabajo_Práctico_Final_AyP_2C
{
    class Transaccion
    {
        private Excursion _excursion;
        private Empleado _empleado;
        private Cliente _cliente;

        public Excursion Excursion
        {
            get
            {
                return _excursion;
            }
        }

        public Empleado Empleado
        {
            get
            {
                return _empleado;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
        }

        public Transaccion (Excursion ex, Empleado em, Cliente cl)
        {
            this._excursion = ex;
            this._empleado = em;
            this._cliente = cl;
        }
    }
}