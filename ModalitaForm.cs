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
    public partial class ModalitaForm : Form
    {
        public int ModalitàSelezionata { get; private set; } = 1;

        public ModalitaForm()
        {
            InitializeComponent();
        }

        private void btnSingolo_Click(object sender, EventArgs e)
        {
            ModalitàSelezionata = 1;
            DialogResult = DialogResult.OK;
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            ModalitàSelezionata = 2;
            DialogResult = DialogResult.OK;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            ModalitàSelezionata = 3;
            DialogResult = DialogResult.OK;
        }
    }
}
