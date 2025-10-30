namespace PintarCochesUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // Declaración de PictureBoxes para los carros
    private System.Windows.Forms.PictureBox pbCarro1;
    private System.Windows.Forms.PictureBox pbCarro2;
    private System.Windows.Forms.PictureBox pbCarro3;
    private System.Windows.Forms.PictureBox pbCarro4;
    private System.Windows.Forms.PictureBox pbCarro5;

    // Declaración de Labels para el Récord/Estado
    private System.Windows.Forms.Label lblTiempo;
    private System.Windows.Forms.Label lblCarrosPintados;
    private System.Windows.Forms.Label lblEstado;

    // Declaración de Botones para la paleta de colores
    private System.Windows.Forms.Button btnAmarillo;
    private System.Windows.Forms.Button btnNaranja;
    private System.Windows.Forms.Button btnRojo;
    private System.Windows.Forms.Button btnVerde;
    private System.Windows.Forms.Button btnAzulMarino;

    // Declaración de Timers
    private System.Windows.Forms.Timer timerEnfilamiento;
    private System.Windows.Forms.Timer timerJuego;

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        // Timers
        this.timerEnfilamiento = new System.Windows.Forms.Timer(this.components);
        this.timerEnfilamiento.Tick += new System.EventHandler(this.timerEnfilamiento_Tick);
        this.timerJuego = new System.Windows.Forms.Timer(this.components);
        this.timerJuego.Tick += new System.EventHandler(this.timerJuego_Tick);

        // Buttons
        this.btnAmarillo = new System.Windows.Forms.Button();
        this.btnAmarillo.Text = "Amarillo";
        this.btnAmarillo.Name = "btnAmarillo";
        this.btnAmarillo.Location = new System.Drawing.Point(12, 12);
        this.btnAmarillo.Size = new System.Drawing.Size(75, 23);
        this.btnAmarillo.Click += new System.EventHandler(this.btnAmarillo_Click);

        this.btnNaranja = new System.Windows.Forms.Button();
        this.btnNaranja.Text = "Naranja";
        this.btnNaranja.Name = "btnNaranja";
        this.btnNaranja.Location = new System.Drawing.Point(93, 12);
        this.btnNaranja.Size = new System.Drawing.Size(75, 23);
        this.btnNaranja.Click += new System.EventHandler(this.btnNaranja_Click);

        this.btnRojo = new System.Windows.Forms.Button();
        this.btnRojo.Text = "Rojo";
        this.btnRojo.Name = "btnRojo";
        this.btnRojo.Location = new System.Drawing.Point(174, 12);
        this.btnRojo.Size = new System.Drawing.Size(75, 23);
        this.btnRojo.Click += new System.EventHandler(this.btnRojo_Click);

        this.btnVerde = new System.Windows.Forms.Button();
        this.btnVerde.Text = "Verde";
        this.btnVerde.Name = "btnVerde";
        this.btnVerde.Location = new System.Drawing.Point(255, 12);
        this.btnVerde.Size = new System.Drawing.Size(75, 23);
        this.btnVerde.Click += new System.EventHandler(this.btnVerde_Click);

        this.btnAzulMarino = new System.Windows.Forms.Button();
        this.btnAzulMarino.Text = "Azul Marino";
        this.btnAzulMarino.Name = "btnAzulMarino";
        this.btnAzulMarino.Location = new System.Drawing.Point(336, 12);
        this.btnAzulMarino.Size = new System.Drawing.Size(75, 23);
        this.btnAzulMarino.Click += new System.EventHandler(this.btnAzulMarino_Click);

        // Labels
        this.lblTiempo = new System.Windows.Forms.Label();
        this.lblTiempo.Text = "Tiempo: 0";
        this.lblTiempo.Name = "lblTiempo";
        this.lblTiempo.Location = new System.Drawing.Point(12, 40);
        this.lblTiempo.Size = new System.Drawing.Size(100, 20);

        this.lblCarrosPintados = new System.Windows.Forms.Label();
        this.lblCarrosPintados.Text = "Carros Pintados: 0";
        this.lblCarrosPintados.Name = "lblCarrosPintados";
        this.lblCarrosPintados.Location = new System.Drawing.Point(12, 65);
        this.lblCarrosPintados.Size = new System.Drawing.Size(150, 20);

        this.lblEstado = new System.Windows.Forms.Label();
        this.lblEstado.Text = "Estado: Esperando";
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Location = new System.Drawing.Point(12, 90);
        this.lblEstado.Size = new System.Drawing.Size(200, 20);

        // PictureBoxes
        this.pbCarro1 = new System.Windows.Forms.PictureBox();
        this.pbCarro1.BackColor = System.Drawing.Color.LightGray;
        this.pbCarro1.Name = "pbCarro1";
        this.pbCarro1.Location = new System.Drawing.Point(12, 120);
        this.pbCarro1.Size = new System.Drawing.Size(100, 50);
        this.pbCarro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.pbCarro2 = new System.Windows.Forms.PictureBox();
        this.pbCarro2.BackColor = System.Drawing.Color.LightGray;
        this.pbCarro2.Name = "pbCarro2";
        this.pbCarro2.Location = new System.Drawing.Point(12, 180);
        this.pbCarro2.Size = new System.Drawing.Size(100, 50);
        this.pbCarro2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.pbCarro3 = new System.Windows.Forms.PictureBox();
        this.pbCarro3.BackColor = System.Drawing.Color.LightGray;
        this.pbCarro3.Name = "pbCarro3";
        this.pbCarro3.Location = new System.Drawing.Point(12, 240);
        this.pbCarro3.Size = new System.Drawing.Size(100, 50);
        this.pbCarro3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.pbCarro4 = new System.Windows.Forms.PictureBox();
        this.pbCarro4.BackColor = System.Drawing.Color.LightGray;
        this.pbCarro4.Name = "pbCarro4";
        this.pbCarro4.Location = new System.Drawing.Point(12, 300);
        this.pbCarro4.Size = new System.Drawing.Size(100, 50);
        this.pbCarro4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.pbCarro5 = new System.Windows.Forms.PictureBox();
        this.pbCarro5.BackColor = System.Drawing.Color.LightGray;
        this.pbCarro5.Name = "pbCarro5";
        this.pbCarro5.Location = new System.Drawing.Point(12, 360);
        this.pbCarro5.Size = new System.Drawing.Size(100, 50);
        this.pbCarro5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        // Add controls to the form
        this.Controls.Add(this.btnAmarillo);
        this.Controls.Add(this.btnNaranja);
        this.Controls.Add(this.btnRojo);
        this.Controls.Add(this.btnVerde);
        this.Controls.Add(this.btnAzulMarino);
        this.Controls.Add(this.lblTiempo);
        this.Controls.Add(this.lblCarrosPintados);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.pbCarro1);
        this.Controls.Add(this.pbCarro2);
        this.Controls.Add(this.pbCarro3);
        this.Controls.Add(this.pbCarro4);
        this.Controls.Add(this.pbCarro5);
    }

    #endregion
}
