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
            // La clase ColasService ya es estática y el menú lo hace ColasMenuService

            bool continuar = true;
            while (continuar)
            {
                MostrarMenuPrincipal();

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("\n----------------------------------------");
                    switch (opcion)
                    {
                        // ... (Cases 1 y 2 permanecen iguales) ...
                        case 3:
                            // El menú de Colas se manejará más adelante.
                            Console.WriteLine("Funcionalidad de Colas no implementada aún.");
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