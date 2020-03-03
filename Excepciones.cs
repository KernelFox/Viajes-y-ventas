using System;

namespace Trabajo_Práctico_Final_AyP_2C
{    
    public class OpcionNoValidaException:Exception{
        public OpcionNoValidaException(string mensaje): base(mensaje){

        }
    }
}