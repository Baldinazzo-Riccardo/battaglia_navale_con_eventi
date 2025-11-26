using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battConEventi
{
    public class CNave
    {
        public int Lunghezza { get; private set; }
        public List<(int x, int y)> Coordinate { get; private set; }
        public HashSet<(int x, int y)> ColpiSubiti { get; private set; }

        public bool ÈAffondata => ColpiSubiti.Count == Lunghezza;

        public CNave(int lunghezza)
        {
            Lunghezza = lunghezza;
            Coordinate = new List<(int x, int y)>();
            ColpiSubiti = new HashSet<(int x, int y)>();
        }

        public void ImpostaCoordinate(List<(int x, int y)> coords)
        {
            Coordinate = coords;
        }

        public bool ContieneCella(int x, int y)
        {
            foreach (var c in Coordinate)
                if (c.x == x && c.y == y)
                    return true;
            return false;
        }

        public bool Colpisci(int x, int y)
        {
            if (ContieneCella(x, y))
            {
                ColpiSubiti.Add((x, y));
                return true;
            }
            return false;
        }
    }
}
