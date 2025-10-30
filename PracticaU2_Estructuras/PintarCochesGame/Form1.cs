using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PintarCochesGame
{
    public partial class Form1 : Form
    {
        // ====================================================================
        // 1. CLASE INTERNA DE MODELO
        // ====================================================================
        private class Carro
        {
            public string ColorSolicitado { get; set; } = string.Empty;
        }

        // ====================================================================
        // 2. VARIABLES DE JUEGO
        // ====================================================================
        private Queue<Carro> colaCarros = null!;
        private Random random = null!;
        private readonly List<string> coloresDisponibles = new List<string> { "Amarillo", "Naranja", "Rojo", "Verde", "Azul Marino" };

        private int carrosPintados = 0;
        private int carrosParaAcelerar = 0; // Contador de 3 carros pintados para aumentar velocidad
        private int intervaloEnfilamiento = 20000; // 20 segundos iniciales (20000 ms)
        private int tiempoJuegoSegundos = 0; 

        // Array para mapear la cola a los PictureBoxes (pbCarro1 es el más cercano a pintar)
        // Asegúrese de nombrar sus PictureBoxes en el diseñador como pbCarro1, pbCarro2, etc.
        private PictureBox[] pictureBoxesCola = null!; 

        // ====================================================================
        // 3. INICIALIZACIÓN
        // ====================================================================
        public Form1()
        {
            // Inicialización de componentes generados por el diseñador (NO MODIFICAR)
            InitializeComponent(); 
            InicializarJuego();
        }

        private void InicializarJuego()
        {
            colaCarros = new Queue<Carro>();
            random = new Random();
            
            // Inicializa el array de PictureBoxes. ¡Asegúrese de que existan en el Form!
            // El orden es importante: pbCarro1 es el primero en la cola (próximo a pintar).
            pictureBoxesCola = new PictureBox[] { pbCarro1, pbCarro2, pbCarro3, pbCarro4, pbCarro5 }; 

            // Configuración de los temporizadores
            timerEnfilamiento.Interval = intervaloEnfilamiento;
            timerJuego.Interval = 1000; 
            
            timerEnfilamiento.Start();
            timerJuego.Start();
            
            lblEstado.Text = "¡Juego iniciado! Esperando el primer carro...";
            lblCarrosPintados.Text = "Pintados: 0";
            lblTiempo.Text = "Tiempo: 0s";
            ActualizarUI();
        }

        // ====================================================================
        // 4. LÓGICA DE TEMPORIZADORES
        // ====================================================================
        
        /// <summary>
        /// Controla la aparición de nuevos carros y la condición de Game Over.
        /// Este método debe ser conectado al evento Tick de timerEnfilamiento.
        /// </summary>
        private void timerEnfilamiento_Tick(object sender, EventArgs e)
        {
            // **Criterio de Fin del Juego: 5 carros en la cola**
            if (colaCarros.Count >= 5) 
            {
                GameOver();
                return;
            }

            // Añadir carro (generar una solicitud de color aleatoria)
            string color = coloresDisponibles[random.Next(coloresDisponibles.Count)];
            colaCarros.Enqueue(new Carro { ColorSolicitado = color });
            
            lblEstado.Text = $"Nuevo carro en la cola. Color solicitado: {color}";
            ActualizarUI();
        }
        
        /// <summary>
        /// Controla el tiempo total de juego.
        /// Este método debe ser conectado al evento Tick de timerJuego.
        /// </summary>
        private void timerJuego_Tick(object sender, EventArgs e)
        {
            tiempoJuegoSegundos++;
            lblTiempo.Text = $"Tiempo: {tiempoJuegoSegundos}s";
        }

        // ====================================================================
        // 5. LÓGICA DE PINTADO (Botones de Color)
        // ====================================================================

        private void PintarCarro(string colorSeleccionado)
        {
            if (colaCarros.Count == 0 || !timerJuego.Enabled)
            {
                lblEstado.Text = "No hay carros para pintar o el juego ha terminado.";
                return;
            }
            
            // Solo se puede pintar el carro en el frente de la cola (Peek)
            Carro carroActual = colaCarros.Peek(); 

            if (carroActual.ColorSolicitado == colorSeleccionado)
            {
                // Éxito: Desencolar el carro pintado
                colaCarros.Dequeue();
                carrosPintados++;
                
                lblCarrosPintados.Text = $"Pintados: {carrosPintados}";
                lblEstado.Text = $"¡Éxito! Carro pintado de {colorSeleccionado}.";
                
                // Lógica de Aceleración de Juego: Aumentar dificultad
                carrosParaAcelerar++;
                if (carrosParaAcelerar >= 3)
                {
                    // Reducir el intervalo en 5 segundos (5000 ms)
                    intervaloEnfilamiento -= 5000; 
                    
                    // Límite de velocidad: Intervalo mínimo de 1 segundo
                    if (intervaloEnfilamiento < 1000)
                    {
                        intervaloEnfilamiento = 1000;
                    }
                    
                    timerEnfilamiento.Interval = intervaloEnfilamiento;
                    lblEstado.Text += $"\n¡Velocidad aumentada! Nuevo intervalo: {intervaloEnfilamiento / 1000}s.";
                    carrosParaAcelerar = 0; // Resetear el contador de aceleración
                }
            }
            else
            {
                // Fracaso de pintado
                lblEstado.Text = $"¡Error! Se solicitó {carroActual.ColorSolicitado}, pero seleccionaste {colorSeleccionado}.";
            }

            ActualizarUI();
        }

        // Métodos de clic para cada color (Conectarlos manualmente a los botones del Form)
        private void btnAmarillo_Click(object sender, EventArgs e) => PintarCarro("Amarillo");
        private void btnNaranja_Click(object sender, EventArgs e) => PintarCarro("Naranja");
        private void btnRojo_Click(object sender, EventArgs e) => PintarCarro("Rojo");
        private void btnVerde_Click(object sender, EventArgs e) => PintarCarro("Verde");
        private void btnAzulMarino_Click(object sender, EventArgs e) => PintarCarro("Azul Marino");

        // ====================================================================
        // 6. UI Y GAME OVER
        // ====================================================================
        
        private void ActualizarUI()
        {
            // 1. Limpiar todos los PictureBoxes (simulan los slots de la cola)
            foreach (var pb in pictureBoxesCola)
            {
                pb.BackColor = Color.LightGray; 
                pb.BorderStyle = BorderStyle.None;
            }

            // 2. Mostrar los carros en la cola (FIFO)
            Carro[] carrosEnCola = colaCarros.ToArray();
            for (int i = 0; i < carrosEnCola.Length; i++)
            {
                PictureBox pb = pictureBoxesCola[i];
                Carro c = carrosEnCola[i];
                
                pb.BackColor = GetColorFromName(c.ColorSolicitado);
                // Resaltar el primer carro, el que está a punto de ser pintado
                if (i == 0)
                {
                    pb.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }
        
        private Color GetColorFromName(string colorName)
        {
            // Mapeo simple de nombres a colores de la paleta de Drawing
            switch (colorName)
            {
                case "Amarillo": return Color.Yellow;
                case "Naranja": return Color.Orange;
                case "Rojo": return Color.Red;
                case "Verde": return Color.LimeGreen;
                case "Azul Marino": return Color.DarkBlue;
                default: return Color.White;
            }
        }

        private void GameOver()
        {
            // Detener ambos temporizadores
            timerEnfilamiento.Stop();
            timerJuego.Stop();

            string mensaje = "¡JUEGO TERMINADO!\n\n" +
                             "Razón: La cola ha alcanzado el límite de 5 carros.\n" +
                             "Carros Pintados Correctamente: " + carrosPintados + "\n" +
                             "Tiempo Total de Juego: " + tiempoJuegoSegundos + " segundos.";
            
            lblEstado.Text = mensaje;
            MessageBox.Show(mensaje, "Fin del Juego - Récord", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Opcional: Deshabilitar los botones de color aquí
        }
    }
}