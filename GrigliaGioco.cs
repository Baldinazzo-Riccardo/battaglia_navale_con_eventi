using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battConEventi
{
    public class GrigliaGioco
    {
        public const int SIZE = 10;

        public List<CNave> Navi { get; private set; }
        public bool[,] CelleUsate { get; private set; }

        // EVENTI RICHIESTI
        public event Action<int, int> OnColpita;
        public event Action<CNave> OnAffondata;
        public event Action<int, int> OnAcqua;

        public GrigliaGioco()
        {
            Navi = new List<CNave>();
            CelleUsate = new bool[SIZE, SIZE];
        }

        public bool PuòPiazzare(CNave nave, int x, int y, bool orizz)
        {
            if (orizz)
            {
                if (x + nave.Lunghezza > SIZE) return false;
                for (int i = 0; i < nave.Lunghezza; i++)
                    if (CellaOccupata(x + i, y)) return false;
            }
            else
            {
                if (y + nave.Lunghezza > SIZE) return false;
                for (int i = 0; i < nave.Lunghezza; i++)
                    if (CellaOccupata(x, y + i)) return false;
            }
            return true;
        }

        public void PiazzaNave(CNave nave, int x, int y, bool orizz)
        {
            var coords = new List<(int, int)>();
            for (int i = 0; i < nave.Lunghezza; i++)
            {
                int cx = orizz ? x + i : x;
                int cy = orizz ? y : y + i;
                coords.Add((cx, cy));
            }

            nave.ImpostaCoordinate(coords);

            foreach (var c in coords)
                CelleUsate[c.Item1, c.Item2] = true;

            Navi.Add(nave);
        }

        private bool CellaOccupata(int x, int y)
        {
            return CelleUsate[x, y];
        }


        public void Attacca(int x, int y)
        {
            foreach (var nave in Navi)
            {
                if (nave.Colpisci(x, y))
                {
                    //evento colpita
                    OnColpita?.Invoke(x, y);

                    if (nave.ÈAffondata)
                        OnAffondata?.Invoke(nave);

                    return;
                }
            }

            OnAcqua?.Invoke(x, y);
        }
    }
}
