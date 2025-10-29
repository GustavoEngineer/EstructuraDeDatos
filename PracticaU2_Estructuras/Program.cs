using System;
using PracticaU2_Estructuras.Services; // Asumimos esta carpeta para las clases Service

namespace PracticaU2_Estructuras
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar los servicios (Cumpliendo el estandar POO)
            var listasService = new ListasService();
            var pilasService = new PilasService();
            var colasService = new ColasService();

            bool continuar = true;
            while (continuar)
            {
                MostrarMenuPrincipal();

                // ⚠️ Implementación de validación de excepciones (Introducir sólo números)
                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("\n----------------------------------------");
                    switch (opcion)
                    {
                        case 1:
                            // Redireccionar al menú de Listas (Implementar en ListasService)
                            listasService.EjecutarMenu();
                            break;
                        case 2:
                            // Redireccionar al menú de Pilas (Implementar en PilasService)
                            pilasService.EjecutarMenu();
                            break;
                        case 3:
                            // Redireccionar al menú de Colas (Implementar en ColasService)
                            colasService.EjecutarMenu();
                            break;
                        case 0:
                            Console.WriteLine("👋 Saliendo de la aplicación...");
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                            break;
                    }
                    Console.WriteLine("----------------------------------------\n");
                }
                else
                {
                    Console.WriteLine("\n🚨 Error: Por favor, introduce solo un número para seleccionar la opción.");
                }

                if (continuar)
                {
                    Console.WriteLine("Presiona cualquier tecla para volver al Menú Principal...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("========== Práctica U2: Estructuras de Datos ==========");
            Console.WriteLine("Selecciona una estructura para ver sus ejercicios:");
            Console.WriteLine("  1. Listas (5 Ejercicios)");
            Console.WriteLine("  2. Pilas (4 Ejercicios)");
            Console.WriteLine("  3. Colas (3 Ejercicios)");
            Console.WriteLine("  0. Salir");
            Console.Write("Tu opción: ");
        }
    }
}