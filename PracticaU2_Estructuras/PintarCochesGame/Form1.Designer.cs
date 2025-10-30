namespace PintarCochesGame
{
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbCarro1 = new System.Windows.Forms.PictureBox();
            this.pbCarro2 = new System.Windows.Forms.PictureBox();
            this.pbCarro3 = new System.Windows.Forms.PictureBox();
            this.pbCarro4 = new System.Windows.Forms.PictureBox();
            this.pbCarro5 = new System.Windows.Forms.PictureBox();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblCarrosPintados = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnAmarillo = new System.Windows.Forms.Button();
            this.btnNaranja = new System.Windows.Forms.Button();
            this.btnRojo = new System.Windows.Forms.Button();
            this.btnVerde = new System.Windows.Forms.Button();
            this.btnAzulMarino = new System.Windows.Forms.Button();
            this.timerEnfilamiento = new System.Windows.Forms.Timer(this.components);
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro5)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCarro1
            // 
            this.pbCarro1.BackColor = System.Drawing.Color.LightGray;
            this.pbCarro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarro1.Location = new System.Drawing.Point(12, 12);
            this.pbCarro1.Name = "pbCarro1";
            this.pbCarro1.Size = new System.Drawing.Size(100, 50);
            this.pbCarro1.TabIndex = 0;
            this.pbCarro1.TabStop = false;
            // 
            // pbCarro2
            // 
            this.pbCarro2.BackColor = System.Drawing.Color.LightGray;
            this.pbCarro2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarro2.Location = new System.Drawing.Point(118, 12);
            this.pbCarro2.Name = "pbCarro2";
            this.pbCarro2.Size = new System.Drawing.Size(100, 50);
            this.pbCarro2.TabIndex = 1;
            this.pbCarro2.TabStop = false;
            // 
            // pbCarro3
            // 
            this.pbCarro3.BackColor = System.Drawing.Color.LightGray;
            this.pbCarro3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarro3.Location = new System.Drawing.Point(224, 12);
            this.pbCarro3.Name = "pbCarro3";
            this.pbCarro3.Size = new System.Drawing.Size(100, 50);
            this.pbCarro3.TabIndex = 2;
            this.pbCarro3.TabStop = false;
            // 
            // pbCarro4
            // 
            this.pbCarro4.BackColor = System.Drawing.Color.LightGray;
            this.pbCarro4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarro4.Location = new System.Drawing.Point(330, 12);
            this.pbCarro4.Name = "pbCarro4";
            this.pbCarro4.Size = new System.Drawing.Size(100, 50);
            this.pbCarro4.TabIndex = 3;
            this.pbCarro4.TabStop = false;
            // 
            // pbCarro5
            // 
            this.pbCarro5.BackColor = System.Drawing.Color.LightGray;
            this.pbCarro5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarro5.Location = new System.Drawing.Point(436, 12);
            this.pbCarro5.Name = "pbCarro5";
            this.pbCarro5.Size = new System.Drawing.Size(100, 50);
            this.pbCarro5.TabIndex = 4;
            this.pbCarro5.TabStop = false;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(12, 80);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(60, 15);
            this.lblTiempo.TabIndex = 5;
            this.lblTiempo.Text = "Tiempo: 0s";
            // 
            // lblCarrosPintados
            // 
            this.lblCarrosPintados.AutoSize = true;
            this.lblCarrosPintados.Location = new System.Drawing.Point(12, 100);
            this.lblCarrosPintados.Name = "lblCarrosPintados";
            this.lblCarrosPintados.Size = new System.Drawing.Size(69, 15);
            this.lblCarrosPintados.TabIndex = 6;
            this.lblCarrosPintados.Text = "Pintados: 0";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 120);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(190, 15);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "¡Juego iniciado! Esperando el primer carro...";
            // 
            // btnAmarillo
            // 
            this.btnAmarillo.Location = new System.Drawing.Point(12, 150);
            this.btnAmarillo.Name = "btnAmarillo";
            this.btnAmarillo.Size = new System.Drawing.Size(100, 30);
            this.btnAmarillo.TabIndex = 8;
            this.btnAmarillo.Text = "Amarillo";
            this.btnAmarillo.UseVisualStyleBackColor = true;
            this.btnAmarillo.Click += new System.EventHandler(this.btnAmarillo_Click);
            // 
            // btnNaranja
            // 
            this.btnNaranja.Location = new System.Drawing.Point(118, 150);
            this.btnNaranja.Name = "btnNaranja";
            this.btnNaranja.Size = new System.Drawing.Size(100, 30);
            this.btnNaranja.TabIndex = 9;
            this.btnNaranja.Text = "Naranja";
            this.btnNaranja.UseVisualStyleBackColor = true;
            this.btnNaranja.Click += new System.EventHandler(this.btnNaranja_Click);
            // 
            // btnRojo
            // 
            this.btnRojo.Location = new System.Drawing.Point(224, 150);
            this.btnRojo.Name = "btnRojo";
            this.btnRojo.Size = new System.Drawing.Size(100, 30);
            this.btnRojo.TabIndex = 10;
            this.btnRojo.Text = "Rojo";
            this.btnRojo.UseVisualStyleBackColor = true;
            this.btnRojo.Click += new System.EventHandler(this.btnRojo_Click);
            // 
            // btnVerde
            // 
            this.btnVerde.Location = new System.Drawing.Point(330, 150);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(100, 30);
            this.btnVerde.TabIndex = 11;
            this.btnVerde.Text = "Verde";
            this.btnVerde.UseVisualStyleBackColor = true;
            this.btnVerde.Click += new System.EventHandler(this.btnVerde_Click);
            // 
            // btnAzulMarino
            // 
            this.btnAzulMarino.Location = new System.Drawing.Point(436, 150);
            this.btnAzulMarino.Name = "btnAzulMarino";
            this.btnAzulMarino.Size = new System.Drawing.Size(100, 30);
            this.btnAzulMarino.TabIndex = 12;
            this.btnAzulMarino.Text = "Azul Marino";
            this.btnAzulMarino.UseVisualStyleBackColor = true;
            this.btnAzulMarino.Click += new System.EventHandler(this.btnAzulMarino_Click);
            // 
            // timerEnfilamiento
            // 
            this.timerEnfilamiento.Tick += new System.EventHandler(this.timerEnfilamiento_Tick);
            // 
            // timerJuego
            // 
            this.timerJuego.Tick += new System.EventHandler(this.timerJuego_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 200);
            this.Controls.Add(this.btnAzulMarino);
            this.Controls.Add(this.btnVerde);
            this.Controls.Add(this.btnRojo);
            this.Controls.Add(this.btnNaranja);
            this.Controls.Add(this.btnAmarillo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblCarrosPintados);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.pbCarro5);
            this.Controls.Add(this.pbCarro4);
            this.Controls.Add(this.pbCarro3);
            this.Controls.Add(this.pbCarro2);
            this.Controls.Add(this.pbCarro1);
            this.Name = "Form1";
            this.Text = "Pintar Coches Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarro5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCarro1;
        private System.Windows.Forms.PictureBox pbCarro2;
        private System.Windows.Forms.PictureBox pbCarro3;
        private System.Windows.Forms.PictureBox pbCarro4;
        private System.Windows.Forms.PictureBox pbCarro5;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblCarrosPintados;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnAmarillo;
        private System.Windows.Forms.Button btnNaranja;
        private System.Windows.Forms.Button btnRojo;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.Button btnAzulMarino;
        private System.Windows.Forms.Timer timerEnfilamiento;
        private System.Windows.Forms.Timer timerJuego;
    }
}