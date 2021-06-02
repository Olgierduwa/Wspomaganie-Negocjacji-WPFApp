using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocjacja
{
    public class Opcja
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public double Waga { get; set; }
        public int Skala { get; set; }
        public Opcja(int id, string nazwa, double waga = 0, int skala = 10)
        {
            ID = id;
            Nazwa = nazwa;
            Waga = waga;
            Skala = skala;
        }

        public override string ToString()
        {
            return Nazwa + " - " + Math.Round(Waga,2);
        }
    }
}
