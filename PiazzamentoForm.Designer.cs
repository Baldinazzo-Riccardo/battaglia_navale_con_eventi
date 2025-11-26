namespace battConEventi
{
    partial class PiazzamentoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPiazzamento;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RadioButton rdbOrizz;
        private System.Windows.Forms.RadioButton rdbVert;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPiazzamento = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.rdbOrizz = new System.Windows.Forms.RadioButton();
            this.rdbVert = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiazzamento)).BeginInit();
            this.SuspendLayout();

            // dgvPiazzamento
            this.dgvPiazzamento.Location = new System.Drawing.Point(20, 50);
            this.dgvPiazzamento.Size = new System.Drawing.Size(350, 350);
            this.dgvPiazzamento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPiazzamento_CellClick);

            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(20, 20);

            // rdbOrizz
            this.rdbOrizz.Text = "Orizzontale";
            this.rdbOrizz.Location = new System.Drawing.Point(200, 10);
            this.rdbOrizz.Checked = true;

            // rdbVert
            this.rdbVert.Text = "Verticale";
            this.rdbVert.Location = new System.Drawing.Point(300, 10);

            // PiazzamentoForm
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.dgvPiazzamento);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.rdbOrizz);
            this.Controls.Add(this.rdbVert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "PiazzamentoForm";
            this.Text = "Piazza le tue navi";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPiazzamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}