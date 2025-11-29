namespace battConEventi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPlayer;
        private System.Windows.Forms.DataGridView dgvEnemy;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTurno;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPlayer = new System.Windows.Forms.DataGridView();
            this.dgvEnemy = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lst_log = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayer
            // 
            this.dgvPlayer.ColumnHeadersHeight = 34;
            this.dgvPlayer.Location = new System.Drawing.Point(20, 50);
            this.dgvPlayer.Name = "dgvPlayer";
            this.dgvPlayer.RowHeadersWidth = 62;
            this.dgvPlayer.Size = new System.Drawing.Size(420, 420);
            this.dgvPlayer.TabIndex = 0;
            // 
            // dgvEnemy
            // 
            this.dgvEnemy.ColumnHeadersHeight = 34;
            this.dgvEnemy.Location = new System.Drawing.Point(480, 50);
            this.dgvEnemy.Name = "dgvEnemy";
            this.dgvEnemy.RowHeadersWidth = 62;
            this.dgvEnemy.Size = new System.Drawing.Size(420, 420);
            this.dgvEnemy.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Inizia Partita";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTurno.Location = new System.Drawing.Point(200, 15);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(182, 32);
            this.lblTurno.TabIndex = 3;
            this.lblTurno.Text = "Turno: Nessuno";
            // 
            // lst_log
            // 
            this.lst_log.FormattingEnabled = true;
            this.lst_log.ItemHeight = 20;
            this.lst_log.Location = new System.Drawing.Point(921, 53);
            this.lst_log.Name = "lst_log";
            this.lst_log.Size = new System.Drawing.Size(195, 404);
            this.lst_log.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1132, 500);
            this.Controls.Add(this.lst_log);
            this.Controls.Add(this.dgvPlayer);
            this.Controls.Add(this.dgvEnemy);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battaglia Navale";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lst_log;
    }
}

