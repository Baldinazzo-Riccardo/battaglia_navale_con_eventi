using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battConEventi
{
    public partial class PiazzamentoForm : Form
    {
        private GrigliaGioco griglia;
        private int naveIndex = 0;
        private int[] navi = { 4, 3, 3, 2, 2, 1 };

        public PiazzamentoForm(GrigliaGioco g, bool nascondi = false)
        {
            InitializeComponent();

            griglia = g;
            DgvBuilder.InizializzaGriglia(dgvPiazzamento);

            if (nascondi)
                dgvPiazzamento.Visible = false;

            lblInfo.Text = $"Posiziona nave lunghezza {navi[naveIndex]}";
        }

        private void dgvPiazzamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvPiazzamento.ClearSelection();

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int x = e.ColumnIndex;
            int y = e.RowIndex;

            bool orizzontale = rdbOrizz.Checked;

            CNave nuova = new CNave(navi[naveIndex]);

            if (griglia.PuòPiazzare(nuova, x, y, orizzontale))
            {
                griglia.PiazzaNave(nuova, x, y, orizzontale);

                // colora cella
                foreach (var c in nuova.Coordinate)
                    DgvBuilder.Colora(dgvPiazzamento, c.x, c.y, Color.Gray);

                naveIndex++;
                if (naveIndex >= navi.Length)
                    DialogResult = DialogResult.OK;
                else
                    lblInfo.Text = $"Posiziona nave lunghezza {navi[naveIndex]}";
            }
            else
            {
                MessageBox.Show("Posizione non valida!");
            }
        }
    }
}
