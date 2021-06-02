using negocjacja.Strony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace negocjacja
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Kwestia> Kwestie;
        public static List<Kwestia> Wyniki;
        public static List<Kwestia> Kombinacje;
        public static UzupelnienieDanych page1 = new UzupelnienieDanych();
        public static SuperNegocjacje page2 = new SuperNegocjacje();

        public MainWindow()
        {
            InitializeComponent();
            frame.Content = page1;
        }

        public static void Oblicz()
        {
            // sumowanie wartosci kwestii
            double suma = 0;
            for (int i = 0; i < Kwestie.Count; i++)
                suma += Kwestie[i].Waga;

            // ustawianie wlasciwych wag kwestii
            Wyniki = new List<Kwestia>();
            for (int i = 0; i < Kwestie.Count; i++)
                Wyniki.Add(new Kwestia(i, Kwestie[i].Nazwa, Kwestie[i].Waga / suma * 100));

            // ustawianie wlasciwych wag opcji dla kolejnych kwestii
            for (int i = 0; i < Kwestie.Count; i++)
            {
                double max = 0;
                double min = 100;
                for (int j = 0; j < Kwestie[i].Opcje.Count; j++)
                {
                    if (max < Kwestie[i].Opcje[j].Waga) max = Kwestie[i].Opcje[j].Waga;
                    if (min > Kwestie[i].Opcje[j].Waga) min = Kwestie[i].Opcje[j].Waga;
                }
                Wyniki[i].Opcje = new List<Opcja>();
                double skala = max - min;
                for (int j = 0; j < Kwestie[i].Opcje.Count; j++)
                    if(max == min) Wyniki[i].Opcje.Add(new Opcja(i, Kwestie[i].Opcje[j].Nazwa, 0));
                    else Wyniki[i].Opcje.Add(new Opcja(i, Kwestie[i].Opcje[j].Nazwa, (Kwestie[i].Opcje[j].Waga - min) / skala * Wyniki[i].Waga));
            }

            // zliczenie ilosci kombinacji oraz utworzenie listy kombinacji
            Kombinacje = new List<Kwestia>();
            int liczbakombpinacji = 1;
            for (int i = 0; i < Kwestie.Count; i++) liczbakombpinacji *= (Kwestie[i].Opcje.Count);
            for (int i = 0; i < liczbakombpinacji; i++) Kombinacje.Add(new Kwestia(i, ""));

            // uzupelnienie kolejno każdej kolumny odpowiednimi opcjami
            int poziom = 1;
            for (int j = 0; j < Wyniki.Count; j++)
            {
                int ile_powtorzen = Kombinacje.Count / Wyniki[j].Opcje.Count / poziom;
                int x = 0;
                for (int i = 0; i < Kombinacje.Count; i++)
                {
                    Kombinacje[i].Opcje.Add(Wyniki[j].Opcje[x]);
                    if ((i+1) % ile_powtorzen == 0) x++;
                    if (x == Kwestie[j].Opcje.Count) x = 0;
                }
                poziom *= (Wyniki[j].Opcje.Count);
            }

            // formatowanie gotowej listy kombinacji dla lepszej czytelnosci
            for (int i = 0; i < Kombinacje.Count; i++)
            {
                double wartosc = 0;
                for (int j = 0; j < Kombinacje[i].Opcje.Count; j++) wartosc += Kombinacje[i].Opcje[j].Waga;
                Kombinacje[i].Waga = Math.Round(wartosc, 2);
                Kombinacje[i].Nazwa = Kombinacje[i].Waga + "%";
                for (int j = 0; j < Kombinacje[i].Opcje.Count; j++) Kombinacje[i].Nazwa += "\t| " + Kombinacje[i].Opcje[j].Nazwa;
            }
        }
    }
}
