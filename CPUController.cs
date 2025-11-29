using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battConEventi
{
    public class CPUController
    {
        private Random rnd = new Random();

        private enum StatoRicerca { Hunt, Target, Destroy }
        private StatoRicerca stato = StatoRicerca.Hunt;

        private List<(int x, int y)> attacchiDisponibili = new List<(int, int)>();
        private Queue<(int x, int y)> targetQueue = new Queue<(int, int)>();
        private (int x, int y)? ultimoColpo = null;

        public CPUController()
        {
            // genera lista 10x10
            for (int x = 0; x < GrigliaGioco.SIZE; x++)
                for (int y = 0; y < GrigliaGioco.SIZE; y++)
                    attacchiDisponibili.Add((x, y));
        }
        //su funzioni seguenti si poteva usare Point al posto di tupla

        //per rimuoverre mossa casuale 
        private (int x, int y) RimuoviCasuale()
        {
            int i = rnd.Next(attacchiDisponibili.Count);
            var c = attacchiDisponibili[i];
            attacchiDisponibili.RemoveAt(i);
            return c;
        }

        public (int x, int y) ProssimaMossa()
        {
            if (stato == StatoRicerca.Hunt)
            {
                return RimuoviCasuale();
            }
            else if (stato == StatoRicerca.Target)
            {
                if (targetQueue.Count == 0)
                {
                    stato = StatoRicerca.Hunt;
                    return RimuoviCasuale();
                }
                return targetQueue.Dequeue();
            }
            else // destroy
            {
                if (targetQueue.Count == 0)
                {
                    stato = StatoRicerca.Hunt;
                    return RimuoviCasuale();
                }
                return targetQueue.Dequeue();
            }
        }

        public void RisultatoColpo(int x, int y, bool colpito, bool affondato)
        {
            if (colpito)
            {
                if (affondato)
                {
                    // reset logica
                    stato = StatoRicerca.Hunt;
                    targetQueue.Clear();
                    ultimoColpo = null;
                    return;
                }

                // fase target
                stato = StatoRicerca.Target;
                ultimoColpo = (x, y);

                // aggiungi celle adiacenti a coda da usare
                AggiungiSeValida(x + 1, y);
                AggiungiSeValida(x - 1, y);
                AggiungiSeValida(x, y + 1);
                AggiungiSeValida(x, y - 1);
            }
        }

        private void AggiungiSeValida(int x, int y)
        {
            if (x < 0 || y < 0 || x >= GrigliaGioco.SIZE || y >= GrigliaGioco.SIZE)
                return;

            var cella = (x, y);

            if (attacchiDisponibili.Contains(cella))
            {
                targetQueue.Enqueue(cella);
                attacchiDisponibili.Remove(cella);
            }
        }
    }
}
