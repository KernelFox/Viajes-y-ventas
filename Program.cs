using System;
using System.Collections;
using System.Collections.Generic;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal.desplegarMenu();
            Console.WriteLine("El programa ha finalizado.");
            Console.ReadKey(true);
            /*
            //Pruebas realizadas durante el desarrollo de este software.


            Cliente test = new Cliente("Matías Salinas", 35189786);
            Console.WriteLine("Nombre:{0}\nDNI:{1}\nNúmero de cliente:{2}\nExcursiones compradas: {3}", test.nombreyApellido, test.dni, test.numeroDeCliente, test.excursionesCompradas);
            test.compradasExcursiones.Add("Test");
            foreach (string item in test.compradasExcursiones)
            {
                Console.WriteLine(item);
            }
            
            DateTime prueba = new DateTime(2019,11,11);
            Console.WriteLine(prueba.Year);

            DateTime test2 = DateTime.Now.Date;
            Console.WriteLine("{0}/{1}/{2}", test2.Day, test2.Month, test2.Year);

            Console.WriteLine((prueba - test2).TotalDays);

            Cliente customer = new Cliente("Alexander Liddington", 123456);
            Cliente customer2 = new Cliente("Jésica Guzmán", 456789);
            Cliente customer3 = new Cliente("Matías Salinas", 35189786);
            Cliente customer4 = new Cliente("Samantha Salinas", 38050402);
            customer.comprarExcursion();
            customer2.comprarExcursion();
            customer2.comprarExcursion();
            customer3.comprarExcursion();
            customer3.comprarExcursion();
            customer3.comprarExcursion();
            customer3.comprarExcursion();
            customer3.comprarExcursion();
            customer3.comprarExcursion();
            customer4.comprarExcursion();
            customer4.comprarExcursion();
            customer4.comprarExcursion();
            List<Cliente> lista = new List<Cliente>();
            lista.Add(customer);
            lista.Add(customer2);
            lista.Add(customer3);
            lista.Add(customer4);
            int indice = lista.Count;
            Program.ordenar(lista);
            Program.prueba(lista, indice-1);
            */
            
        }

        /*Estos métodos se desarrollaron y testearon en esta parte del programa para luego
        Para luego ser implementados en el Menú principal*/

        static void prueba (List<Cliente>customers, int index)
        {
            if(index <0 || index >= customers.Count)
            {
                return;
            }
            prueba(customers, index-1);
            Console.WriteLine("{0} ({1})",customers[index].nombreyApellido, customers[index].excursionesCompradas);
        }

        static void ordenar (List<Cliente> Customers)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (Customers[j - 1].excursionesCompradas < Customers[j].excursionesCompradas)
                    {
                        Cliente temp = Customers[j - 1];
                        Customers[j - 1] = Customers[j];
                        Customers[j] = temp;
                    }
                 }
            }
        }
    }
}
