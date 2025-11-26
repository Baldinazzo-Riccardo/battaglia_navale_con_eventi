using System.Windows.Forms;

namespace battConEventi
{
    partial class ModalitaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSingolo;
        private System.Windows.Forms.Button btnMultiplayer;
        private System.Windows.Forms.Button btnRandom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSingolo = new System.Windows.Forms.Button();
            this.btnMultiplayer = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSingolo
            // 
            this.btnSingolo.Location = new System.Drawing.Point(30, 20);
            this.btnSingolo.Name = "btnSingolo";
            this.btnSingolo.Size = new System.Drawing.Size(200, 40);
            this.btnSingolo.TabIndex = 0;
            this.btnSingolo.Text = "Player vs CPU";
            this.btnSingolo.Click += new System.EventHandler(this.btnSingolo_Click);
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.Location = new System.Drawing.Point(30, 70);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(200, 40);
            this.btnMultiplayer.TabIndex = 1;
            this.btnMultiplayer.Text = "Multiplayer stesso PC";
            this.btnMultiplayer.Click += new System.EventHandler(this.btnMultiplayer_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(30, 120);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(200, 40);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "1vs1 amici";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // ModalitaForm
            // 
            this.ClientSize = new System.Drawing.Size(260, 180);
            this.Controls.Add(this.btnSingolo);
            this.Controls.Add(this.btnMultiplayer);
            this.Controls.Add(this.btnRandom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModalitaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleziona Modalità";
            this.ResumeLayout(false);

        }
    }
}