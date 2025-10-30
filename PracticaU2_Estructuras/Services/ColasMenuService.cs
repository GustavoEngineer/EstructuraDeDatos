using System;
using System.Collections.Generic;
using System.Diagnostics; // Added for Process.Start()
using System.Data; // Added for DataTable from ColasService
using System.IO; // Added for Path.Combine and File.Exists

// Ensure the correct namespace for ColasService
using Services; // Assuming ColasService is in the 'Services' namespace

namespace PracticaU2_Estructuras.Services
{
    public static class ColasMenuService
    {
        public static void EjecutarMenu()
        {
            MostrarMenuColas();
        }

        private static void MostrarMenuColas()
        {
            bool volverAPrincipal = false;
            while (!volverAPrincipal)
            {
                Console.Clear();
                Console.WriteLine("--- Menú Ejercicios de Colas ---");
                Console.WriteLine("1. Ejercicio 1: Ventanilla del Banco (ColasService)");
                Console.WriteLine("2. Ejercicio 2 de Colas (Pendiente)");
                Console.WriteLine("3. Ejercicio 3: Estacionamiento Callejón (EstacionamientoApp)");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1: EjecutarEjercicio1Colas(); break;
                        case 2: Console.WriteLine("Funcionalidad de Cola - Ejercicio 2 no implementada aún."); break;
                        case 3: LanzarEstacionamientoApp(); break;
                        case 0: volverAPrincipal = true; break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }

                if (!volverAPrincipal)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private static void EjecutarEjercicio1Colas()
        {
            Console.Clear();
            Console.WriteLine("--- Ejercicio 1: Ventanilla del Banco ---");

            // Inicializar ColasService si no ha sido inicializado
            // Asumimos una capacidad de 5 para la cola del banco
            ColasService.Inicializar(5);

            bool volverAMenuColas = false;
            while (!volverAMenuColas)
            {
                Console.WriteLine("\n--- Opciones Ventanilla del Banco ---");
                Console.WriteLine("1. Añadir Cliente a la Cola");
                Console.WriteLine("2. Atender Siguiente Cliente");
                Console.WriteLine("3. Ver Estado de la Cola");
                Console.WriteLine("0. Volver al Menú de Colas");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcionBanco))
                {
                    try
                    {
                        switch (opcionBanco)
                        {
                            case 1:
                                Console.Write("Nombre del cliente: ");
                                string nombre = Console.ReadLine() ?? "Cliente Anónimo";
                                Console.Write("Tipo de movimiento (Depósito, Retiro, Pago): ");
                                string tipoMovimiento = Console.ReadLine() ?? "General";
                                ColasService.InsertaCola(nombre, tipoMovimiento, DateTime.Now);
                                Console.WriteLine($"Cliente '{nombre}' añadido a la cola. Turno: {ColasService.ObtenerFinal()?.NumeroTurno}");
                                break;
                            case 2:
                                var resultado = ColasService.AtenderVentanilla();
                                Console.WriteLine($"Cliente atendido: Turno {resultado.Cliente.NumeroTurno}, Nombre: {resultado.Cliente.Nombre}, Espera: {resultado.TiempoEspera.TotalSeconds:F2} segundos.");
                                break;
                            case 3:
                                Console.WriteLine("\n--- Estado Actual de la Cola ---");
                                if (ColasService.ColaVacia())
                                {
                                    Console.WriteLine("La cola está vacía.");
                                }
                                else
                                {
                                    DataTable dt = ColasService.ObtenerSnapshot();
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        Console.WriteLine($"Turno: {row["Turno"]}, Nombre: {row["Nombre"]}, Movimiento: {row["Movimiento"]}, Llegada: {((DateTime)row["HoraLlegada"]).ToShortTimeString()}");
                                    }
                                }
                                Console.WriteLine($"Elementos en cola: {ColasService.Conteo}/{ColasService.Capacidad}");
                                break;
                            case 0:
                                volverAMenuColas = true;
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("🚨 Error: Ingresa solo números.");
                }

                if (!volverAMenuColas)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private static void LanzarEstacionamientoApp()
        {
            Console.Clear();
            Console.WriteLine("--- Ejercicio 3: Estacionamiento Callejón ---");
            Console.WriteLine("Lanzando la aplicación de Estacionamiento...");

            try
            {
                // Ruta relativa al ejecutable de EstacionamientoApp
                // Asumiendo que EstacionamientoApp.exe se encuentra en
                // PracticaU2_Estructuras/EstacionamientoApp/bin/Debug/net9.0/EstacionamientoApp.exe
                string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "EstacionamientoApp", "bin", "Debug", "net9.0", "EstacionamientoApp.exe");

                // Asegurarse de que el archivo existe
                if (File.Exists(appPath))
                {
                    Process process = Process.Start(appPath)!;
                    process.WaitForExit(); // Wait for the launched application to exit
                    Console.WriteLine("EstacionamientoApp finalizado. Presiona una tecla para volver al menú de Colas.");
                }
                else
                {
                    Console.WriteLine($"Error: No se encontró el ejecutable en la ruta: {appPath}");
                    Console.WriteLine("Asegúrate de que EstacionamientoApp haya sido compilado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al lanzar EstacionamientoApp: {ex.Message}");
            }
        }
    }
}