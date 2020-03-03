using System;
using System.Collections;
using System.Collections.Generic;

namespace Trabajo_Práctico_Final_AyP_2C
{
    class MenuPrincipal
    {   
        public static void desplegarMenu()
        {
            int opcionSistema = 0;
            bool opcionIncorrecta = true;
            List<Excursion> lista_excursiones = new List<Excursion>();
            List<Omnibus> lista_omnibuses = new List<Omnibus>();
            List<Empleado> lista_empleados = new List<Empleado>();
            List<Cliente> lista_clientes = new List<Cliente>();
            List<Transaccion> lista_transacciones = new List<Transaccion>();
            while(opcionIncorrecta)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("*****                         MENÚ PRINCIPAL                        *****");
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Seleccione una opción del menú:\n");
                        Console.WriteLine("1- Armado de excursiones\n");
                        Console.WriteLine("2- Gestión de empleados\n");
                        Console.WriteLine("3- Venta de excursiones\n");
                        Console.WriteLine("4- Estadísticas\n");
                        Console.WriteLine("5- Salir del sistema\n");
                        opcionSistema = int.Parse(Console.ReadLine());

                        switch(opcionSistema)
                        {
                            case 1:
                            Console.Clear();
                            MenuPrincipal.moduloExcursiones(ref lista_excursiones, ref lista_omnibuses);
                            break;

                            case 2:
                            Console.Clear();
                            MenuPrincipal.moduloGestionEmpleados(ref lista_empleados);
                            break;

                            case 3:
                            Console.Clear();
                            MenuPrincipal.moduloVentaDeExcursiones(ref lista_empleados, ref lista_clientes, ref lista_excursiones, ref lista_transacciones);
                            break;

                            case 4:
                            Console.Clear();
                            MenuPrincipal.moduloEstadisticas(ref lista_transacciones, ref lista_clientes, ref lista_empleados, ref lista_excursiones);
                            break;

                            case 5:
                            opcionIncorrecta = false;
                            break;

                            default:
                            throw new OpcionNoValidaException("Opción Inválida");
                        }

                        Console.Clear();    
                    } while (opcionSistema !=5);   
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OpcionNoValidaException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }   
        }

        private static void moduloExcursiones(ref List<Excursion> pExcursiones, ref List<Omnibus> pOmnibuses)
        {
            int opcionSistema = 0;
            bool opcionIncorrecta = true;
            while(opcionIncorrecta)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("*****                      ARMADO DE EXCURSIONES                    *****");
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Seleccione una opción del menú:\n");
                        Console.WriteLine("1- Alta de excursión.\n");
                        Console.WriteLine("2- Baja de excursión.\n");
                        Console.WriteLine("3- Alta de omnibus.\n");
                        Console.WriteLine("4- Baja de omnibus.\n");
                        Console.WriteLine("5- Listado de excursiones disponibles.\n");
                        Console.WriteLine("6- Volver.");
                        opcionSistema = int.Parse(Console.ReadLine());
                        
                         switch(opcionSistema)
                        {
                            case 1:
                            Console.Clear();
                            if(pOmnibuses.Count>0)
                            {
                                Console.WriteLine("*************************************************************************");
                                Console.WriteLine("*****                  SUBMÓDULO ALTA DE EXCURSIONES                *****");
                                Console.WriteLine("*************************************************************************");
                                Console.WriteLine("Ingrese nombre de la excursión: ");
                                string nombre_excursion = Console.ReadLine();
                                if(nombre_excursion == "")
                                {
                                    throw new ArgumentNullException();
                                }
                                string recorrido = "";
                                string ciudad_recorrido = "";
                                string dia_de_excursion ="";
                                string dias_excursion = "";
                                do
                                {
                                    Console.WriteLine("Ingrese el nombre de la ciudad del recorrido. Enter para terminar: ");
                                    ciudad_recorrido = Console.ReadLine();
                                    if (ciudad_recorrido != "")
                                    {
                                        recorrido = recorrido + "("+ciudad_recorrido+")"+" ";
                                    }
                                } while (ciudad_recorrido!="");
                                Console.WriteLine("Ingrese horario de salida(hh:mm): ");
                                string hora_salida = Console.ReadLine();
                                if(hora_salida == "")
                                {
                                    throw new ArgumentNullException();
                                }
                                Console.WriteLine("Ingrese la duración en horas: ");
                                int duracion = int.Parse(Console.ReadLine());
                                do
                                {
                                    Console.WriteLine("Ingrese día de salida de la excursión. Enter para finalizar: ");
                                    dia_de_excursion = Console.ReadLine();
                                    if (dia_de_excursion !="")
                                    {
                                        dias_excursion = dias_excursion + "("+dia_de_excursion+")";
                                    }
                                } while (dia_de_excursion!="");
                                Console.WriteLine("Ingrese año de la excursión: ");
                                int anio_excursion = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese el mes de la excursión (Debe ser un número de 1 a 12): ");
                                int mes_excursion = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese el día de la excursión: ");
                                int dia_excursion = int.Parse(Console.ReadLine());
                                DateTime fechaSalidaExcursion = new DateTime (anio_excursion, mes_excursion, dia_excursion);
                                Console.WriteLine("Ingrese Número de omnibus asignado:\n");
                                foreach (Omnibus o in pOmnibuses)
                                {
                                    Console.WriteLine("Marca:{0} - Modelo:{1} - Capacidad:{2} - Unidad:{3} - Tipo:{4}\n", o.marca, o.modelo, o.capacidad, o.numeroDeUnidad, o.tipo);
                                }
                                int numero_omnibus = int.Parse(Console.ReadLine());
                                bool validar_omnibus = false;
                                foreach (Omnibus o in pOmnibuses)
                                {
                                    if(o.numeroDeUnidad == numero_omnibus)
                                    {
                                        validar_omnibus = true;
                                        Excursion nueva_excursion = new Excursion(nombre_excursion, recorrido, hora_salida, duracion, dias_excursion, o, fechaSalidaExcursion);
                                        pExcursiones.Add(nueva_excursion);

                                    }
                                }
                                if (validar_omnibus == true)
                                {
                                    Console.WriteLine("Se ha creado una excursión exitosamente. Presione una tecla para continuar.");
                                    Console.ReadKey(true);
                                }else
                                {
                                    Console.WriteLine("No existe omnibus con el número de unidad ingresado. Inténtelo nuevamente.");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                                validar_omnibus = false;
                            }else
                            {
                                Console.WriteLine("Error. Se requiere disponer de almenos un omnibus para poder dar de alta a una excursión.\n\nPresione una tecla para volver al menú anterior.");
                                Console.ReadKey(true);
                            }
                            
                            break;

                            case 2:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                  SUBMÓDULO BAJA DE EXCURSIONES                *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Listado de excursiones:\n");
                            foreach (Excursion item in pExcursiones)
                            {
                                Console.WriteLine("Excursión:{0}\nRecorrido:{1}\nHorario:{2}\nDuración:{3}\nDias de salida:{4}\nOmnibus asignado:{5}\nFecha:{6}/{7}/{8}\n", item.nombre, item.recorrido, item.horarioDeSalida, item.duracion, item.diasDeSalida, item.omnibus.numeroDeUnidad, item.fecha.Day, item.fecha.Month, item.fecha.Year);
                            }
                            Console.WriteLine("Ingrese el nombre de la excursión a borrar: ");
                            string del_excursion = Console.ReadLine();
                            bool validar_excursion = false;
                            foreach (Excursion item in pExcursiones)
                            {
                                if (item.nombre == del_excursion)
                                {
                                    
                                    Console.WriteLine("Se ha eliminado la excursión exitosamente.\n");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    validar_excursion = true;
                                    pExcursiones.Remove(item);
                                    break;
                                }
                            }
                            if (validar_excursion == false)
                                {
                                    Console.WriteLine("No existe excursión con el nombre ingresado. Inténtelo nuevamente. \n");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                            validar_excursion = false;
                            Console.WriteLine("Listado de excursiones disponibles:\n");
                            foreach (Excursion item in pExcursiones)
                            {
                                Console.WriteLine("Excursión:{0}\nRecorrido:{1}\nHorario:{2}\nDuración:{3}\nDias de salida:{4}\nOmnibus asignado:{5}\nFecha:{6}/{7}/{8}\n", item.nombre, item.recorrido, item.horarioDeSalida, item.duracion, item.diasDeSalida, item.omnibus.numeroDeUnidad, item.fecha.Day, item.fecha.Month, item.fecha.Year);
                            }
                            Console.WriteLine("Presione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 3:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                   SUBMÓDULO ALTA DE OMNIBUS                   *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Ingrese marca del omnibus: ");
                            string marca_omnibus = Console.ReadLine();
                            if(marca_omnibus == "")
                            {
                                throw new ArgumentNullException();
                            }
                            Console.WriteLine("Ingrese modelo del omnibus: ");
                            string modelo_omnibus = Console.ReadLine();
                            if(modelo_omnibus == "")
                            {
                                throw new ArgumentNullException();
                            }
                            Console.WriteLine("Ingrese capacidad del omnibus (Debe ser un número entero mayor a 0): ");
                            int capacidad_omnibus = int.Parse(Console.ReadLine());
                            if (capacidad_omnibus <= 0)
                            {
                                throw new OpcionNoValidaException("Opción Inválida");
                            }
                            Console.WriteLine("Ingrese el número de la unidad (Debe ser un número entero mayor a 0): ");
                            int unidad_omnibus = int.Parse(Console.ReadLine());
                            if (unidad_omnibus <= 0)
                            {
                                throw new OpcionNoValidaException("Opción Inválida");
                            }
                            bool verificarOmnibus = false;
                            foreach (Omnibus item in pOmnibuses)
                            {
                                if (unidad_omnibus == item.numeroDeUnidad)
                                {
                                    verificarOmnibus = true;
                                }
                            }
                            Console.WriteLine("Ingrese el tipo del omnibus (Básico, Semi-Cama, Coche-Cama, Suite): ");
                            string tipo_omnibus = Console.ReadLine();
                            if (tipo_omnibus == "Básico" && verificarOmnibus == false ||tipo_omnibus == "Semi-Cama" && verificarOmnibus == false|| tipo_omnibus =="Coche-Cama"&& verificarOmnibus == false|| tipo_omnibus =="Suite" && verificarOmnibus==false)
                            {
                                Omnibus nuevo_omnibus = new Omnibus(marca_omnibus, modelo_omnibus, capacidad_omnibus, unidad_omnibus, tipo_omnibus);
                                pOmnibuses.Add(nuevo_omnibus);
                                Console.WriteLine("El Omnibus ha sido dado de alta con éxito. Presione una tecla para continuar.");
                                Console.ReadKey(true);
                            }else
                            {
                                throw new OpcionNoValidaException("Opción Inválida");
                            }
                            
                            break;

                            case 4:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                   SUBMÓDULO BAJA DE OMNIBUS                   *****");
                            Console.WriteLine("*************************************************************************");
                            foreach (Omnibus o in pOmnibuses)
                            {
                                Console.WriteLine("Marca:{0} - Modelo:{1} - Capacidad:{2} - Unidad:{3} - Tipo:{4}\n", o.marca, o.modelo, o.capacidad, o.numeroDeUnidad, o.tipo);
                            }
                            Console.WriteLine("Ingrese el número de la unidad a dar de baja: ");
                            bool validacion_omnibus = false;
                            int baja_omnibus = int.Parse(Console.ReadLine());
                            foreach (Omnibus item in pOmnibuses)
                            {
                                if(item.numeroDeUnidad == baja_omnibus)
                                {
                                    Console.WriteLine("Se ha dado de baja el Omnibus Exitosamente.\n");
                                    Console.WriteLine("Presione una tecla para volver al menú anterior.");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    validacion_omnibus = true;
                                    pOmnibuses.Remove(item);
                                    break;
                                }
                            }
                            if (validacion_omnibus == false)
                                {
                                    Console.WriteLine("No existe unidad con el número ingresado. Inténtelo nuevamente.");
                                    Console.WriteLine("Presione una tecla para volver al menú anterior.");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                            validacion_omnibus = false;
                            Console.WriteLine("Listado de Omnibus disponible:\n");
                            foreach (Omnibus o in pOmnibuses)
                            {
                                Console.WriteLine("Marca:{0} - Modelo:{1} - Capacidad:{2} - Unidad:{3} - Tipo:{4}\n", o.marca, o.modelo, o.capacidad, o.numeroDeUnidad, o.tipo);
                            }
                            Console.ReadKey(true);
                            break;

                            case 5:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                SUBMÓDULO LISTADO DE EXCURSIONES               *****");
                            Console.WriteLine("*************************************************************************");
                            foreach (Excursion item in pExcursiones)
                            {
                                Console.WriteLine("Excursión:{0}\nRecorrido:{1}\nHorario:{2}\nDuración:{3}\nDias de salida:{4}\nOmnibus asignado:{5}\nFecha:{6}/{7}/{8}\n", item.nombre, item.recorrido, item.horarioDeSalida, item.duracion, item.diasDeSalida, item.omnibus.numeroDeUnidad, item.fecha.Day, item.fecha.Month, item.fecha.Year);
                            }
                            Console.WriteLine("Presione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 6:
                            opcionIncorrecta = false;
                            break;

                            default:
                            throw new OpcionNoValidaException("Opción Inválida");
                        }
                        
                        Console.Clear();    
                    } while (opcionSistema !=6);   
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Los datos ingresados no son correctos. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OpcionNoValidaException)
                {
                    Console.Clear();
                    Console.WriteLine("Los datos ingresados no son correctos o el número de unidad ingresado ya está asignado a un omnibus. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Los datos ingresados no son correctos. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                catch(System.ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Los datos ingresados para la fecha no son correctos. Por favor, inténtelo nuevamente.");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                
                catch(ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("El ingreso de este dato no puede ser nulo. Por favor, inténtelo nuevamente.");
                    Console.WriteLine("Presione una tecla para volver al menú anterior.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } 
        }

        private static void moduloGestionEmpleados(ref List<Empleado> pEmpleados)
        {
            int opcionSistema = 0;
            bool opcionIncorrecta = true;
            while(opcionIncorrecta)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("*****                  MODULO GESTIÓN DE EMPLEADOS                  *****");
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Seleccione una opción del menú:\n");
                        Console.WriteLine("1- Alta de empleado.\n");
                        Console.WriteLine("2- Baja de empleado.\n");
                        Console.WriteLine("3- Listado de empleados.\n");
                        Console.WriteLine("4- Volver.\n");
                        opcionSistema = int.Parse(Console.ReadLine());
                        
                        switch(opcionSistema)
                        {
                            case 1:
                            Console.Clear();
                            bool validar_empleado = false;
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                  SUBMÓDULO ALTA DE EMPLEADO                   *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Ingrese el nombre y apellido del empleado: ");
                            string nombreEmpleado = Console.ReadLine();
                            if(nombreEmpleado == "")
                            {
                                throw new ArgumentNullException();
                            }
                            Console.WriteLine("Ingrese el DNI del empleado: ");
                            int dniEmpleado = int.Parse(Console.ReadLine());
                            foreach (Empleado item in pEmpleados)
                            {
                                if(item.dni == dniEmpleado)
                                {
                                    validar_empleado = true;
                                }
                            }
                            if (validar_empleado == false)
                            {
                                Empleado nuevoEmpleado = new Empleado(nombreEmpleado, dniEmpleado);
                                pEmpleados.Add(nuevoEmpleado);
                                Console.WriteLine("El empleado fue dado de alta satisfactoriamente. Su número de legajo es: {0}", nuevoEmpleado.legajo);
                                Console.ReadKey(true);
                            }else{
                                Console.WriteLine("Ya existe un empleado con el DNI ingresado. Por favor, inténtelo nuevamente.");
                                Console.ReadKey(true); 

                            }
                            break;

                            case 2:
                            Console.Clear();
                            bool validacion_empleado = false;
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                  SUBMÓDULO BAJA DE EMPLEADOS                  *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Listado de empleados:\n");
                            foreach (Empleado item in pEmpleados)
                            {
                                Console.WriteLine("Nombre y Apellido: {0} - DNI: {1} - Legajo: {2}", item.nombreyApellido, item.dni, item.legajo);
                            }
                            Console.WriteLine("\nIngrese el número de legajo del empleado a dar de baja: ");
                            int baja_legajo = int.Parse(Console.ReadLine());
                            foreach (Empleado item in pEmpleados)
                            {
                                if(item.legajo == baja_legajo)
                                {
                                    Console.WriteLine("Se ha dado de baja al empleado exitosamente.\n");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    validacion_empleado = true;
                                    pEmpleados.Remove(item);
                                    break;
                                }

                            }
                            if (validacion_empleado == false)
                                {
                                    Console.WriteLine("No existe empleado con el número de legajo ingresado. Inténtelo nuevamente.");
                                    Console.WriteLine("Presione una tecla para continuar...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                            validacion_empleado = false;
                            Console.WriteLine("Listado de empleados:\n");
                            foreach (Empleado item in pEmpleados)
                            {
                                Console.WriteLine("Nombre y Apellido: {0} - DNI: {1} - Legajo: {2}", item.nombreyApellido, item.dni, item.legajo);
                            }
                            Console.WriteLine("\nPresione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 3:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                SUBMÓDULO LISTADO DE EMPLEADOS                 *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Listado de empleados:\n");
                            foreach (Empleado item in pEmpleados)
                            {
                                Console.WriteLine("Nombre y Apellido: {0} - DNI: {1} - Legajo: {2}", item.nombreyApellido, item.dni, item.legajo);
                            }
                            Console.WriteLine("\nPresione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 4:
                            opcionIncorrecta = false;
                            break;

                            default:
                            throw new OpcionNoValidaException("Opción Inválida");
                        }

                        Console.Clear();    
                    } while (opcionSistema !=4);   
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OpcionNoValidaException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("El ingreso de este dato no puede ser nulo. Por favor, inténtelo nuevamente.");
                    Console.WriteLine("Presione una tecla para volver al menú anterior.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } 
        }

        private static void moduloVentaDeExcursiones(ref List<Empleado> pEmpleados, ref List<Cliente> pClientes, ref List<Excursion> pExcursiones, ref List<Transaccion> pTransacciones)
        {
            int opcionSistema = 0;
            bool opcionIncorrecta = true;
            while(opcionIncorrecta)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("*****                  MÓDULO VENTA DE EXCURSIONES                  *****");
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Seleccione una opción del menú:\n");
                        Console.WriteLine("1- Alta de cliente.\n");
                        Console.WriteLine("2- Compra de pasajes para una excursión.\n");
                        Console.WriteLine("3- Devolución de pasajes.\n");
                        Console.WriteLine("4- Volver.\n");
                        opcionSistema = int.Parse(Console.ReadLine());
                        
                        switch(opcionSistema)
                        {
                            case 1:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                   SUBMÓDULO ALTA DE CLIENTE                   *****");
                            Console.WriteLine("*************************************************************************");
                            bool validar_cliente = false;
                            Console.WriteLine("Ingrese el nombre y apellido del cliente: ");
                            string nombreCliente = Console.ReadLine();
                            if(nombreCliente == "")
                            {
                                throw new ArgumentNullException();
                            }
                            Console.WriteLine("Ingrese el DNI del cliente: ");
                            int dniCliente = int.Parse(Console.ReadLine());
                            foreach (Cliente item in pClientes)
                            {
                                if(item.dni == dniCliente)
                                {
                                    validar_cliente = true;
                                }
                            }
                            if (validar_cliente == false)
                            {
                                Cliente nuevoCliente = new Cliente(nombreCliente, dniCliente);
                                pClientes.Add(nuevoCliente);
                                Console.WriteLine("El Cliente fue dado de alta satisfactoriamente. Su número de cliente es: {0}", nuevoCliente.numeroDeCliente);
                                Console.ReadKey(true);
                            }else{
                                Console.WriteLine("Ya existe un cliente con el DNI ingresado. Por favor, inténtelo nuevamente.");
                                Console.ReadKey(true); 

                            }
                            break;

                            case 2:
                            Console.Clear();
                            validar_cliente = false;
                            bool validar_excursion = false;
                            bool validar_empleado = false;
                            int indice_cliente=0;
                            int indice_excursion=0;
                            int indice_empleado=0;
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                  SUBMÓDULO COMPRA DE PASAJES                  *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Lista de clientes:\n");
                            foreach (Cliente item in pClientes)
                            {
                                Console.WriteLine("Nombre y Apellido: {0} - Número de cliente: {1}", item.nombreyApellido, item.numeroDeCliente);
                            }
                            Console.WriteLine("\nIngrese el número de cliente: ");
                            int numero_cliente = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el DNI del cliente: ");
                            int dni_cliente = int.Parse(Console.ReadLine());
                            foreach (Cliente item in pClientes)
                            {
                                if(item.numeroDeCliente == numero_cliente && item.dni==dni_cliente)
                                {
                                    validar_cliente = true;
                                    indice_cliente = pClientes.IndexOf(item);
                                    Console.WriteLine("indice de cliente:{0}", indice_cliente);
                                }
                            }
                            if (validar_cliente== true)
                            {
                                foreach (Excursion item in pExcursiones)
                                {
                                    Console.WriteLine("{0}- Excursión:{1}\nRecorrido:{2}\nHorario:{3}\nDuración:{4}\nDías de Salida{5}\nOmnibus Asignado:{6}\n",item.numeroExcursion, item.nombre, item.recorrido, item.horarioDeSalida, item.duracion, item.diasDeSalida, item.omnibus.numeroDeUnidad);
                                }
                                Console.WriteLine("Ingrese número de la excursión a comprar: ");
                                int compraExcursion = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese cantidad de pasajes: ");
                                int pasajes = int.Parse(Console.ReadLine());
                                foreach (Excursion item in pExcursiones)
                                {
                                    if(item.numeroExcursion == compraExcursion)
                                    {
                                        indice_excursion = pExcursiones.IndexOf(item);
                                        validar_excursion = true;
                                    }
                                }
                                if(validar_excursion == false)
                                {
                                    Console.WriteLine("No hay excursiones con el número de excursión ingresado. Inténtelo nuevamente.");

                                }
                                if(validar_excursion == true)
                                {
                                    Console.WriteLine("Lista de empleados:\n");
                                    foreach (Empleado item in pEmpleados)
                                    {
                                        Console.WriteLine("Nombre y Apellido: {0} - Legajo: {1}", item.nombreyApellido, item.legajo);
                                    }
                                    Console.WriteLine("\nIngrese el número de legajo del empleado: ");
                                    int legajo_empleado = int.Parse(Console.ReadLine());
                                    foreach (Empleado item in pEmpleados)
                                    {
                                        if(item.legajo == legajo_empleado)
                                        {
                                            indice_empleado = pEmpleados.IndexOf(item);
                                            validar_empleado = true;
                                        }
                                    }
                                    if (validar_empleado == false)
                                    {
                                        Console.WriteLine("No hay empleados con el número de legajo ingresado. Inténtelo nuevamente.");
                                    }
                                }
                                
                            }
                            if(validar_empleado== true && validar_cliente == true && validar_excursion==true)
                            {
                                foreach (Cliente item in pClientes)
                                {
                                    if(pClientes.IndexOf(item)== indice_cliente)
                                    {
                                        foreach (Excursion ex in pExcursiones)
                                        {
                                            if(pExcursiones.IndexOf(ex)==indice_excursion)
                                            {
                                                foreach (Empleado employee in pEmpleados)
                                                {
                                                    if (pEmpleados.IndexOf(employee)==indice_empleado)
                                                    {
                                                        item.compradasExcursiones.Add(ex);
                                                        item.comprarExcursion();
                                                        employee.realizarVenta();
                                                        ex.incrementarSolicitudes();
                                                        Transaccion nuevaTransaccion = new Transaccion(ex, employee, item);
                                                        pTransacciones.Add(nuevaTransaccion);
                                                        Console.WriteLine("Transacción Exitosa.");
                                                        Console.WriteLine("Pruebas:");
                                                        Console.WriteLine("Número excursion:{0}\nNombre empleado:{1}\nVentas empleado:{2}\nNombre Cliente:{3}\nCantidad compras cliente:{4}",nuevaTransaccion.Excursion.numeroExcursion, nuevaTransaccion.Empleado.nombreyApellido, nuevaTransaccion.Empleado.ventas, nuevaTransaccion.Cliente.nombreyApellido,nuevaTransaccion.Cliente.excursionesCompradas); 
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            
                            if (validar_cliente == false)
                            {
                                Console.WriteLine("No se ha encontrado cliente con el DNI y Número de cliente ingresados. Inténtelo nuevamente.");
                            }
                            
                            Console.ReadKey(true);
                            Console.Clear();
                            break;

                            case 3:
                            Console.Clear();
                            validar_cliente = false;
                            validar_empleado = false;
                            validar_excursion = false;
                            bool validar_transaccion = false;
                            int porcentaje_devolucion=0;
                            int indice_transaccion = 0;
                            indice_cliente = 0;
                            indice_excursion = 0;
                            DateTime fecha_hoy = DateTime.Now.Date;
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****                SUBMÓDULO DEVOLUCIÓN DE PASAJES                *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("Lista de clientes:\n");
                            foreach (Cliente item in pClientes)
                            {
                                Console.WriteLine("Nombre y Apellido: {0} - Número de cliente: {1}", item.nombreyApellido, item.numeroDeCliente);
                            }
                            Console.WriteLine("\nIngrese el número de cliente: ");
                            numero_cliente = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el DNI del cliente: ");
                            dni_cliente = int.Parse(Console.ReadLine());
                            foreach (Cliente item in pClientes)
                            {
                                if(item.numeroDeCliente == numero_cliente && item.dni==dni_cliente)
                                {
                                    validar_cliente = true;
                                    indice_cliente = pClientes.IndexOf(item);
                                }
                            }
                            if(validar_cliente==true)
                            {
                                foreach (Excursion item in pExcursiones)
                                {
                                    Console.WriteLine("{0}- Excursión:{1}\nRecorrido:{2}\nHorario:{3}\nDuración:{4}\nDías de Salida{5}\nOmnibus Asignado:{6}\n",item.numeroExcursion, item.nombre, item.recorrido, item.horarioDeSalida, item.duracion, item.diasDeSalida, item.omnibus.numeroDeUnidad);
                                }
                                Console.WriteLine("Ingrese número de la excursión a Devolver: ");
                                int devolver_excursion = int.Parse(Console.ReadLine());
                                foreach (Excursion item in pExcursiones)
                                {
                                    if(item.numeroExcursion == devolver_excursion)
                                    {
                                        indice_excursion = pExcursiones.IndexOf(item);
                                    }
                                }
                                foreach (Transaccion item in pTransacciones)
                                {
                                    if(item.Excursion.numeroExcursion==devolver_excursion & item.Cliente.numeroDeCliente == numero_cliente)
                                    {
                                        validar_transaccion = true;
                                        indice_transaccion = pTransacciones.IndexOf(item);
                                    }   
                                }
                                if(validar_transaccion == true)
                                {
                                    if((pExcursiones[indice_excursion].fecha - fecha_hoy).TotalDays <= 1)
                                    {
                                        porcentaje_devolucion = 0;
                                    }
                                    if((pExcursiones[indice_excursion].fecha - fecha_hoy).TotalDays ==2)
                                    {
                                        porcentaje_devolucion = 50;
                                    }
                                    if((pExcursiones[indice_excursion].fecha - fecha_hoy).TotalDays >=3)
                                    {
                                        porcentaje_devolucion = 90;
                                    }
                                    if(porcentaje_devolucion >0)
                                    {
                                        pExcursiones[indice_excursion].decrementarSolicitudes();
                                        pClientes[indice_cliente].devolverExcursion();
                                        pTransacciones[indice_transaccion].Empleado.cancelarVenta();
                                        pTransacciones.Remove(pTransacciones[indice_transaccion]);
                                        Console.WriteLine("Transacción exitosa. Se le devolverá el {0}% del valor abonado", porcentaje_devolucion);
                                        Console.ReadKey(true);
                                    }else
                                    {
                                        Console.WriteLine("No se aceptan devoluciones 24 horas antes de la salida.");
                                        Console.ReadKey(true);
                                    }

                                }else
                                {
                                    Console.WriteLine("No existe una transacción con la excursión y cliente ingresados. Inténtelo nuevamente.");
                                    Console.ReadKey(true);
                                }
                            }
                            if(validar_cliente==false)
                            {
                                Console.WriteLine("No se ha encontrado cliente con el DNI y Número de cliente ingresados. Inténtelo nuevamente.");
                                Console.ReadKey(true);
                            }
                            Console.Clear();
                            break;

                            case 4:
                            opcionIncorrecta = false;
                            break;

                            default:
                            throw new OpcionNoValidaException("Opción Inválida");
                        }

                        Console.Clear();    
                    } while (opcionSistema !=4);   
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OpcionNoValidaException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("El ingreso de este dato no puede ser nulo. Por favor, inténtelo nuevamente.");
                    Console.WriteLine("Presione una tecla para volver al menú anterior.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } 
        }

        private static void moduloEstadisticas(ref List<Transaccion> pTransacciones, ref List<Cliente> pClientes, ref List<Empleado> pEmpleados, ref List<Excursion> pExcursiones)
        {
            int opcionSistema = 0;
            bool opcionIncorrecta = true;
            while(opcionIncorrecta)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("*****                      MÓDULO ESTADÍSTICAS                      *****");
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("Seleccione una opción del menú:\n");
                        Console.WriteLine("1- Consultar la cantidad de excursiones vendidas.\n");
                        Console.WriteLine("2- Consultar los clientes que más viajan.\n");
                        Console.WriteLine("3- Consultar la excursión más solicitada.\n");
                        Console.WriteLine("4- Consultar el operador que más excursiones vende.\n");
                        Console.WriteLine("5- Volver. \n");
                        opcionSistema = int.Parse(Console.ReadLine());
                        
                        switch(opcionSistema)
                        {
                            case 1:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****          SUBMÓDULO CANTIDAD DE EXCURSIONES VENDIDAS           *****");
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("La cantidad de excursiones vendidas es: {0}", pTransacciones.Count);
                            Console.WriteLine("Presione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 2:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****               SUBMÓDULO CLIENTES QUE MÁS VIAJAN               *****");
                            Console.WriteLine("*************************************************************************");
                            int cantidad_clientes = pClientes.Count;
                            Console.WriteLine("Clientes Ordenados por excursiones compradas:\n");
                            ordenarClientes(pClientes);
                            imprimirClientes(pClientes, cantidad_clientes-1);
                            Console.WriteLine("\nPresione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 3:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****               SUBMÓDULO EXCURSIÓN MÁS SOLICITADA              *****");
                            Console.WriteLine("*************************************************************************");
                            int cantidad_excursiones = pExcursiones.Count;
                            Console.WriteLine("Excursiones más vendidas:\n");
                            ordenarExcursiones(pExcursiones);
                            imprimirExcursiones(pExcursiones, cantidad_excursiones-1);
                            Console.WriteLine("\nPresione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 4:
                            Console.Clear();
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine("*****               SUBMÓDULO OPERADOR CON MÁS VENTAS               *****");
                            Console.WriteLine("*************************************************************************");
                            int cantidad_empleados = pEmpleados.Count;
                            Console.WriteLine("Clientes Ordenados por excursiones compradas:\n");
                            ordenarEmpleados(pEmpleados);
                            imprimirEmpleados(pEmpleados, cantidad_empleados-1);
                            Console.WriteLine("\nPresione una tecla para volver al menú anterior.");
                            Console.ReadKey(true);
                            break;

                            case 5:
                            opcionIncorrecta = false;
                            break;

                            default:
                            throw new OpcionNoValidaException("Opción Inválida");
                        }
                        Console.Clear();    
                    } while (opcionSistema !=5);   
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OpcionNoValidaException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("La opción ingresada no es válida. Inténtelo nuevamente.\n");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } 
        }

       private static void imprimirClientes (List<Cliente>customers, int index)
        {
            if(index <0 || index >= customers.Count)
            {
                return;
            }
            imprimirClientes(customers, index-1);
            Console.WriteLine("{0} ({1})",customers[index].nombreyApellido, customers[index].excursionesCompradas);
        }

        private static void ordenarClientes (List<Cliente> Customers)
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

        private static void imprimirEmpleados (List<Empleado>employees, int index)
        {
            if(index <0 || index >= employees.Count)
            {
                return;
            }
            imprimirEmpleados(employees, index-1);
            Console.WriteLine("{0} - Legajo: {1} - Ventas:{2}",employees[index].nombreyApellido, employees[index].legajo, employees[index].ventas);
        }

        private static void ordenarEmpleados (List<Empleado> Employees)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (Employees[j - 1].ventas < Employees[j].ventas)
                    {
                        Empleado temp = Employees[j - 1];
                        Employees[j - 1] = Employees[j];
                        Employees[j] = temp;
                    }
                 }
            }
        }

        private static void imprimirExcursiones (List<Excursion>paseo, int index)
        {
            if(index <0 || index >= paseo.Count)
            {
                return;
            }
            imprimirExcursiones(paseo, index-1);
            Console.WriteLine("{0} - {1}",paseo[index].nombre, paseo[index].vecesSolicitada);
        }
        
        private static void ordenarExcursiones (List<Excursion> paseo)
        {
            for (int i = 0; i < paseo.Count; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (paseo[j - 1].vecesSolicitada < paseo[j].vecesSolicitada)
                    {
                        Excursion temp = paseo[j - 1];
                        paseo[j - 1] = paseo[j];
                        paseo[j] = temp;
                    }
                 }
            }
        }
    }
}