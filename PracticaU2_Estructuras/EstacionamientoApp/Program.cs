using System;
using System.Threading;

// NOTA: Esta clase es el punto de entrada (Program) para el nuevo proyecto "EstacionamientoApp"
public class Program
{
    // Se usa la clase Estacionamiento que implementa la Cola Circular Doblemente Ligada
    private static Estacionamiento estacionamiento = new Estacionamiento();

    public static void Main(string[] args)
    {
        RunEstacionamientoModule();
    }

    // Método que contiene la lógica del bucle de menú (antes estaba en el Main del borrador)
    private static void RunEstacionamientoModule()
    {
        Console.Title = "Estacionamiento Callejón (Ejercicio 3)";
        string opcion;

        do
        {
            MostrarMenu();
            opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "1":
                    IngresarAuto();
                    break;
                case "2":
                    SacarAuto();
                    break;
                case "3":
                    Console.WriteLine("\nCerrando la aplicación del Estacionamiento...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    break;
            }
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
            Console.Clear();
        } while (opcion != "3");
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("   EJERCICIO 3: ESTACIONAMIENTO CALLEJÓN");
        Console.WriteLine($"   Autos Estacionados: {estacionamiento.Contador}");
        Console.WriteLine("=============================================");
        Console.WriteLine("1. Entrada de Auto");
        Console.WriteLine("2. Salida de Auto (FIFO)");
        Console.WriteLine("3. Salir de la Aplicación");
        Console.Write("Seleccione una opción: ");
    }

    private static void IngresarAuto()
    {
        Console.Clear();
        Console.WriteLine("--- 1. ENTRADA DE AUTO ---");
        Console.Write("Capturar Placas del Auto: ");
        string placas = (Console.ReadLine() ?? string.Empty).ToUpper();
        Console.Write("Capturar Nombre del Propietario: ");
        string propietario = Console.ReadLine() ?? string.Empty;
        
        estacionamiento.EntradaAuto(placas, propietario);
    }

    private static void SacarAuto()
    {
        Console.Clear();
        Console.WriteLine("--- 2. SALIDA DE AUTO ---");
        
        // Simular un tiempo de permanencia si hay autos para asegurar un cobro
        if (estacionamiento.Contador > 0)
        {
            Console.WriteLine("Procesando cálculo de costo... (Espere 3 segundos)");
            Thread.Sleep(3000); 
        }
        
        estacionamiento.SalidaAuto();
    }
}