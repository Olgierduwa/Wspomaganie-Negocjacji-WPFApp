using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace negocjacja
{
    public class Kwestia
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public double Waga { get; set; }
        public Brush Kolor { get; set; }
        public int Skala { get; set; }
        public List<Opcja> Opcje { get; set; }
        public Kwestia(int id, string nazwa, double waga = 0)
        {
            ID = id;
            Nazwa = nazwa;
            Waga = waga;
            Kolor = Brushes.White;
            Skala = 10;
            Opcje = new List<Opcja>();
        }
        public Kwestia(Kwestia k)
        {
            ID = k.ID;
            Nazwa = k.Nazwa;
            Waga = k.Waga;
            Kolor = k.Kolor;
            Skala = 10;
            Opcje = new List<Opcja>(k.Opcje);
        }

        public Kwestia(string kwestia)
        {
            string[] K = kwestia.Split('#');
            ID = Convert.ToInt32(K[0]);
            Nazwa = K[1];
            Waga = Convert.ToDouble(K[2]);
            Kolor = Brushes.White;
            Skala = Convert.ToInt32(K[3]);
            Opcje = new List<Opcja>();
            int OptionCount = Convert.ToInt32(K[4]);
            for (int i = 0; i < OptionCount; i++) Opcje.Add(new Opcja(Convert.ToInt32(K[5 + i * 4]), K[6 + i * 4], Convert.ToDouble(K[7 + i * 4]), Convert.ToInt32(K[8 + i * 4])));
        }

        public string ZapiszKwestie()
        {
            string kwestia = ID.ToString() + "#" + Nazwa + "#" + Waga.ToString() + "#" + Skala.ToString() + "#" + Opcje.Count().ToString();
            for (int i = 0; i < Opcje.Count; i++) kwestia += "#" + Opcje[i].ID.ToString() + "#" + Opcje[i].Nazwa + "#" + Opcje[i].Waga.ToString() + "#" + Opcje[i].Skala.ToString();
            kwestia += ";";
            return kwestia;
        }
    }
}
