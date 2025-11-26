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
    public partial class Form1 : Form
    {

        private int modalità; 
        private GrigliaGioco grigliaPlayer;
        private GrigliaGioco grigliaEnemy;
        private CPUController cpu;
        private bool turnoGiocatore = true;

        public Form1()
        {
            InitializeComponent();

            InizializzaDGV();
        }

        private void InizializzaDGV()
        {
            DgvBuilder.InizializzaGriglia(dgvPlayer);
            DgvBuilder.InizializzaGriglia(dgvEnemy);

            dgvPlayer.CellClick += dgvPlayer_CellContentClick;
            dgvEnemy.CellClick += DgvEnemy_CellClick;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AvviaPartita();
        }

        private void AvviaPartita()
        {
            grigliaPlayer = new GrigliaGioco();
            grigliaEnemy = new GrigliaGioco();

            collegaEventi(grigliaPlayer, dgvPlayer);
            collegaEventi(grigliaEnemy, dgvEnemy);

            cpu = new CPUController();

            lblTurno.Text = "Turno: Giocatore";
            switch (modalità)
            {
                case 1:
                    Modalità1_PlayerVsCPU();
                    break;

                case 2:
                    Modalità2_Multiplayer();
                    dgvPlayer.Visible = false;
                    break;

                case 3:
                    Modalità3_RandomVsRandom();
                    lblTurno.Text = "Turno: Giocatore 2";
                    break;
            }

            
            turnoGiocatore = true;
        }

        private void collegaEventi(GrigliaGioco g, DataGridView dgv)
        {
            g.OnColpita += (x, y) =>
            {
                DgvBuilder.Colora(dgv, x, y, Color.Red);
                
            };

            g.OnAcqua += (x, y) =>
            {
                DgvBuilder.Colora(dgv, x, y, Color.LightBlue);
                
            };

            g.OnAffondata += (nave) =>
            {
                foreach (var c in nave.Coordinate)
                    DgvBuilder.Colora(dgv, c.x, c.y, Color.Black);

                
            };
        }

        private void Modalità1_PlayerVsCPU()
        {
            // mostra form piazzamento navi al giocatore
            using (var f = new PiazzamentoForm(grigliaPlayer))
                f.ShowDialog();

            // piazza CPU random
            PiazzamentoRandom(grigliaEnemy);
        }


        private void Modalità2_Multiplayer()
        {
            using (var f = new PiazzamentoForm(grigliaEnemy))
                f.ShowDialog();

            MessageBox.Show("Passa il PC al giocatore 2");

            //using (var f = new PiazzamentoForm(grigliaEnemy, nascondi: true))
            //    f.ShowDialog();
        }


        private void Modalità3_RandomVsRandom()
        {
            //PiazzamentoRandom(grigliaPlayer);
            //PiazzamentoRandom(grigliaEnemy);

            dgvPlayer.Enabled = true;

            MessageBox.Show("Posizionamento navi giocatore 1");
            using (var f = new PiazzamentoForm(grigliaPlayer))
                f.ShowDialog();

            MessageBox.Show("Posizionamento navi giocatore 2");
            using (var f = new PiazzamentoForm(grigliaEnemy))
                f.ShowDialog();
        }


        private void PiazzamentoRandom(GrigliaGioco griglia)
        {
            int[] navi = { 4, 3, 3, 2, 2, 1 };

            Random rnd = new Random();

            foreach (int n in navi)
            {
                bool piazzata = false;

                while (!piazzata)
                {
                    bool or = rnd.Next(2) == 0;
                    int x = rnd.Next(10);
                    int y = rnd.Next(10);

                    CNave nuova = new CNave(n);

                    if (griglia.PuòPiazzare(nuova, x, y, or))
                    {
                        griglia.PiazzaNave(nuova, x, y, or);
                        piazzata = true;
                    }
                }
            }
        }

        private void DgvEnemy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEnemy.ClearSelection();

            
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int x = e.ColumnIndex;
            int y = e.RowIndex;

            if (modalità == 2) // Multiplayer
            {
                if (!turnoGiocatore) return;
                grigliaEnemy.Attacca(x, y);

                if (Vittoria(grigliaEnemy))
                {
                    MessageBox.Show("Giocatore 2 ha vinto!");
                    this.Close();
                    return;
                }
                

                

                //______________________________________________
                //turnoGiocatore = false;

                lblTurno.Text = "Turno: Giocatore 2";

                
            }
            else if (modalità == 1) 
            {
                if (!turnoGiocatore) return;
                grigliaEnemy.Attacca(x, y);

                if (Vittoria(grigliaEnemy))
                {
                    MessageBox.Show("Hai vinto!");
                    this.Close();
                    return;
                }

                turnoGiocatore = false;
                lblTurno.Text = "Turno: CPU";

                Timer t = new Timer();
                t.Interval = 500; // ritardo CPU
                t.Tick += (s2, e2) =>
                {
                    t.Stop();
                    MossaCPU();
                };
                t.Start();
            }
            else if(modalità == 3)
            {
                grigliaEnemy.Attacca(x, y);

                if (Vittoria(grigliaEnemy))
                {
                    MessageBox.Show("Giocatore 2 ha vinto!");
                    this.Close();
                    return;
                }

                if(Vittoria(grigliaPlayer))
                {
                    MessageBox.Show("Giocatore 1 ha vinto!");
                    this.Close();
                    return;
                }



                turnoGiocatore = true;

                lblTurno.Text = "Turno: Giocatore 2";


                dgvEnemy.Enabled = false;
                dgvPlayer.Enabled = true;
            }
        }

        private void MossaCPU()
        {
            var (x, y) = cpu.ProssimaMossa();

            bool colpitoPrima = false;
            bool affondataPrima = false;

            // intercettiamo gli eventi per capire cosa è successo
            void colpita(int a, int b) { colpitoPrima = true; }
            void affondata(CNave n) { affondataPrima = true; }

            grigliaPlayer.OnColpita += colpita;
            grigliaPlayer.OnAffondata += affondata;

            grigliaPlayer.Attacca(x, y);

            // rimuoviamo gli handler
            grigliaPlayer.OnColpita -= colpita;
            grigliaPlayer.OnAffondata -= affondata;

            cpu.RisultatoColpo(x, y, colpitoPrima, affondataPrima);

            if (Vittoria(grigliaPlayer))
            {
                MessageBox.Show("Hai perso!");
                this.Close();
                return;
            }
            
            turnoGiocatore = true;
            lblTurno.Text = "Turno: Giocatore";
        }

        private bool Vittoria(GrigliaGioco g)
        {
            foreach (var n in g.Navi)
            {
                if (!n.ÈAffondata)
                {
                    return false;
                }
            }
            return true;
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            using (ModalitaForm modalitaForm = new ModalitaForm())
            {
                if (modalitaForm.ShowDialog() == DialogResult.OK)
                {
                    modalità = modalitaForm.ModalitàSelezionata;
                }
            }
        }

        private void dgvPlayer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (!turnoGiocatore) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            dgvPlayer.ClearSelection();
            if (modalità == 1 || modalità == 2)
            {
                return;
            }
            else
            {
                int x = e.ColumnIndex;
                int y = e.RowIndex;

                

                grigliaPlayer.Attacca(x, y);


                if (Vittoria(grigliaEnemy))
                {
                    MessageBox.Show("Giocatore 2 ha vinto!");
                    this.Close();
                    return;
                }

                if (Vittoria(grigliaPlayer))
                {
                    MessageBox.Show("Giocatore 1 ha vinto!");
                    this.Close();
                    return;
                }



                turnoGiocatore = false;

                lblTurno.Text = "Turno: Giocatore 1";
                dgvEnemy.Enabled = true;
                dgvPlayer.Enabled = false;

            }

        }
    }
}

