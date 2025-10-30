using System;

public class Estacionamiento
{
    // Usar '?' para indicar que pueden ser null (CS8618)
    private Auto? Cabeza; 
    private Auto? Cola;  
    public int Contador { get; private set; } = 0;

    public bool EstaVacio => Contador == 0;

    public void EntradaAuto(string placas, string propietario)
    {
        Auto nuevoAuto = new Auto(placas, propietario);

        if (EstaVacio)
        {
            Cabeza = nuevoAuto;
            Cola = nuevoAuto;
        }
        else
        {
            // Sabemos que Cola y Cabeza no son null si no está vacío, usamos '!'
            nuevoAuto.Anterior = Cola!;
            nuevoAuto.Siguiente = Cabeza!;

            Cola!.Siguiente = nuevoAuto;
            Cabeza!.Anterior = nuevoAuto;
            
            Cola = nuevoAuto;
        }
        Contador++;
        Console.WriteLine($"\nAuto con placas {placas} ingresado al estacionamiento.");
        MostrarEstadoEstacionamiento();
    }

    public void SalidaAuto()
    {
        if (EstaVacio)
        {
            Console.WriteLine("\nEl estacionamiento está vacío. No hay autos para sacar.");
            return;
        }

        // Sabemos que Cabeza no es null, usamos '!' para asignar a autoSalida
        Auto autoSalida = Cabeza!;
        DateTime horaSalida = DateTime.Now;

        // Calcular costo
        double costoTotal = CalcularCosto(autoSalida.HoraEntrada, horaSalida);
        MostrarReporteSalida(autoSalida, horaSalida, costoTotal);

        // Caso de un solo auto
        if (Contador == 1)
        {
            Cabeza = null;
            Cola = null;
        }
        else
        {
            // El nuevo Cabeza es el Siguiente del auto actual (Sabemos que no es null)
            Cabeza = autoSalida.Siguiente;

            // Sabemos que Cabeza y Cola no son null aquí, usamos '!'
            Cabeza!.Anterior = Cola!;
            Cola!.Siguiente = Cabeza!;
        }

        Contador--;
        Console.WriteLine($"\nAuto con placas {autoSalida.Placas} ha salido del estacionamiento.");
        MostrarEstadoEstacionamiento();
    }

    private double CalcularCosto(DateTime horaEntrada, DateTime horaSalida)
    {
        TimeSpan tiempoEstacionado = horaSalida - horaEntrada;
        double costoPorMinuto = 0.5; // 50 centavos por minuto
        return tiempoEstacionado.TotalMinutes * costoPorMinuto;
    }

    private void MostrarReporteSalida(Auto auto, DateTime horaSalida, double costoTotal)
    {
        Console.WriteLine($"\n--- Reporte de Salida ---");
        Console.WriteLine($"Auto: {auto.Placas}");
        Console.WriteLine($"Propietario: {auto.Propietario}");
        Console.WriteLine($"Hora de Entrada: {auto.HoraEntrada.ToShortTimeString()}");
        Console.WriteLine($"Hora de Salida: {horaSalida.ToShortTimeString()}");
        Console.WriteLine($"Costo Total: {costoTotal:C2}");
        Console.WriteLine("-------------------------");
    }

    private void MostrarEstadoEstacionamiento()
    {
        Console.WriteLine("\n--- Estado Actual del Estacionamiento ---");
        if (EstaVacio)
        {
            Console.WriteLine("Estacionamiento vacío.");
            return;
        }

        Auto? actual = Cabeza;
        for (int i = 0; i < Contador; i++)
        {
            Console.WriteLine($"- {actual!.Placas}, {actual.Propietario}");
            actual = actual.Siguiente;
        }
        Console.WriteLine("-----------------------------------------");
    }
}