using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battConEventi
{
    public static class DgvBuilder
    {
        public static void InizializzaGriglia(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = true;
            dgv.ColumnHeadersVisible = true;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;

            dgv.ClearSelection();

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.Black;

            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false; // solo una cella alla volta
            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
            dgv.ClearSelection();
            dgv.DefaultCellStyle.SelectionBackColor = dgv.BackColor;

            //colonne A-J
            for (int c = 0; c < 10; c++)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Width = 30;
                col.HeaderText = ((char)('A' + c)).ToString();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns.Add(col);
            }

            //righe 1-10
            dgv.Rows.Add(10);
            for (int r = 0; r < 10; r++)
            {
                dgv.Rows[r].Height = 30;
                dgv.Rows[r].HeaderCell.Value = (r + 1).ToString();
            }

            dgv.ClearSelection();
        }

        public static void Colora(DataGridView dgv, int x, int y, Color colore)
        {
            dgv.Rows[y].Cells[x].Style.BackColor = colore;
        }
    }
}
