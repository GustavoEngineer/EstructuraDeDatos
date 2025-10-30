using System;

public class Auto
{
    public string Placas { get; set; } = string.Empty; // Inicializar
    public string Propietario { get; set; } = string.Empty; // Inicializar
    public DateTime HoraEntrada { get; set; }

    // Usar '?' para indicar que pueden ser null (CS8618, CS8600, CS8625)
    public Auto? Siguiente { get; set; } 
    public Auto? Anterior { get; set; } 

    public Auto(string placas, string propietario)
    {
        this.Placas = placas;
        this.Propietario = propietario;
        this.HoraEntrada = DateTime.Now;
        
        // Inicialización circular: se asignan a sí mismos (no nulos)
        this.Siguiente = this; 
        this.Anterior = this; 
    }

    public override string ToString()
    {
        return $"Placas: {Placas}, Propietario: {Propietario}, Entrada: {HoraEntrada.ToShortTimeString()}";
    }
}