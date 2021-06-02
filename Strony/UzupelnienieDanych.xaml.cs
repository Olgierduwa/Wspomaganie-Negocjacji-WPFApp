using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace negocjacja.Strony
{
    /// <summary>
    /// Logika interakcji dla klasy UzupelnienieDanych.xaml
    /// </summary>
    public partial class UzupelnienieDanych : Page
    {
        private bool POPRAWNOSC = false;
        public UzupelnienieDanych()
        {
            InitializeComponent();
            MainWindow.Kwestie = new List<Kwestia>()

                { new Kwestia(0, "Ilość pokoi"), new Kwestia(1, "Cena za pokój"), new Kwestia(2, "Powierzchnia"), };
                MainWindow.Kwestie[0].Waga = 60;
                MainWindow.Kwestie[1].Waga = 80;
                MainWindow.Kwestie[2].Waga = 40;
                MainWindow.Kwestie[0].Opcje.AddRange(new List<Opcja>() { new Opcja(0, "1x", 20), new Opcja(1, "2x", 40), new Opcja(2, "3x", 80) });
                MainWindow.Kwestie[1].Opcje.AddRange(new List<Opcja>() { new Opcja(0, "30pln", 50), new Opcja(1, "50pln", 30), new Opcja(2, "100pln", 10) });
                MainWindow.Kwestie[2].Opcje.AddRange(new List<Opcja>() { new Opcja(0, "20m2", 20), new Opcja(1, "30m2", 50), new Opcja(2, "40m2", 70), new Opcja(3, "50m2", 80) });
                KwestieLista.Visibility = Visibility.Visible;
                //DalejButton.IsEnabled = true;

            KwestieLista.ItemsSource = MainWindow.Kwestie;
        }

        private void NowaKwestiaGotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Foreground = Brushes.Black;
            textbox.Text = "";
            OpcjeLista.Visibility = Visibility.Hidden;
            OpcjeLabel.Visibility = Visibility.Hidden;
            NowaOpcjaTextBox.Visibility = Visibility.Hidden;
            KwestieLista.SelectedIndex = -1;
            ZAWSZEPOWTORZ();
        }
        private void NowaKwestiaLostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Foreground = Brushes.Gray;
            textbox.Text = "Nowa kwestia...";
            ZAWSZEPOWTORZ();
        }
        private void NowaKwestiaKlikKlawisz(object sender, KeyEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.Key == Key.Enter && textbox.Text != "")
            {
                MainWindow.Kwestie.Add(new Kwestia(MainWindow.Kwestie.Count, textbox.Text));
                KwestieLista.Visibility = Visibility.Visible;
                KwestieLista.Items.Refresh();
                textbox.Text = "";
            }
            ZAWSZEPOWTORZ();
        }
        private void KwestiaGotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            KwestieLista.SelectedIndex = Convert.ToInt32(textbox.Tag.ToString());
            OpcjeLista.ItemsSource = MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje;
            if (MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.Count > 0)
                OpcjeLista.Visibility = Visibility.Visible;
            else OpcjeLista.Visibility = Visibility.Hidden;
            OpcjeLabel.Visibility = Visibility.Visible;
            NowaOpcjaTextBox.Visibility = Visibility.Visible;
            MainWindow.Kwestie[KwestieLista.SelectedIndex].Kolor = Brushes.White;
            ZAWSZEPOWTORZ();
        }
        private void KwestiaKlikKlawisz(object sender, KeyEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.Key == Key.Enter && textbox.Text == "")
            {
                MainWindow.Kwestie.RemoveAt(KwestieLista.SelectedIndex);
                if (MainWindow.Kwestie.Count > 0)
                    for (int i = KwestieLista.SelectedIndex; i < MainWindow.Kwestie.Count(); i++)
                        if (i > 0) MainWindow.Kwestie[i].ID = MainWindow.Kwestie[i - 1].ID + 1;
                        else MainWindow.Kwestie[i].ID = 0;
                else KwestieLista.Visibility = Visibility.Hidden;
                OpcjeLista.Visibility = Visibility.Hidden;
                OpcjeLabel.Visibility = Visibility.Hidden;
                NowaOpcjaTextBox.Visibility = Visibility.Hidden;
                KwestieLista.Items.Refresh();
            }
            ZAWSZEPOWTORZ();
        }

        private void NowaOpcjaGotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Foreground = Brushes.Black;
            textbox.Text = "";
            OpcjeLista.SelectedIndex = -1;
            ZAWSZEPOWTORZ();
        }
        private void NowaOpcjaLostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            textbox.Foreground = Brushes.Gray;
            textbox.Text = "Nowa opcja...";
            ZAWSZEPOWTORZ();
        }
        private void NowaOpcjaKlikKlawisz(object sender, KeyEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.Key == Key.Enter && textbox.Text != "")
            {
                MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.Add(new Opcja(MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.Count, textbox.Text));
                OpcjeLista.Visibility = Visibility.Visible;
                OpcjeLista.Items.Refresh();
                textbox.Text = "";
            }
            ZAWSZEPOWTORZ();
        }
        private void OpcjaGotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            OpcjeLista.SelectedIndex = Convert.ToInt32(textbox.Tag.ToString());
            ZAWSZEPOWTORZ();
        }
        private void OpcjaKlikKlawisz(object sender, KeyEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.Key == Key.Enter && textbox.Text == "")
            {
                MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.RemoveAt(OpcjeLista.SelectedIndex);
                if (MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.Count > 0)
                    for (int i = OpcjeLista.SelectedIndex; i < MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje.Count(); i++)
                        if (i > 0) MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje[i].ID = MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje[i - 1].ID + 1;
                        else MainWindow.Kwestie[KwestieLista.SelectedIndex].Opcje[i].ID = 0;
                else OpcjeLista.Visibility = Visibility.Hidden;
                OpcjeLista.Items.Refresh();
            }
            ZAWSZEPOWTORZ();
        }

        private void ZAWSZEPOWTORZ()
        {
            if(MainWindow.Kwestie.Count > 0)
                SprawdzButton.IsEnabled = true;
            else SprawdzButton.IsEnabled = false;
            DalejButton.IsEnabled = false;
            POPRAWNOSC = false;

            if (MainWindow.Kwestie.Count > 0)
            {
                SuwakiSkala.IsEnabled = true;
                WyczyscButton.IsEnabled = true;
                SuwakiButton.IsEnabled = true;
            }
        }
        private void SprawdzPoprawnosc(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MainWindow.Kwestie.Count; i++)
            {
                if(MainWindow.Kwestie[i].Waga > 0)
                    POPRAWNOSC = true;
                if (MainWindow.Kwestie[i].Opcje.Count == 0)
                {
                    MainWindow.Kwestie[i].Kolor = Brushes.OrangeRed;
                    DalejButton.IsEnabled = false;
                    POPRAWNOSC = false;
                }
                else
                {
                    for (int j = 0; j < MainWindow.Kwestie[i].Opcje.Count; j++)
                        if (MainWindow.Kwestie[i].Opcje[j].Nazwa == "")
                        {
                            MainWindow.Kwestie[i].Kolor = Brushes.OrangeRed;
                            DalejButton.IsEnabled = false;
                            POPRAWNOSC = false;
                            break;
                        }
                        else MainWindow.Kwestie[i].Kolor = Brushes.White;
                }
                KwestieLista.Items.Refresh();
            }

            string errorMessage = "- Wszystkie Kwestie muszą mieć nazwy!" +
                                "\n- Wszystkie Opcje muszą mieć nazwy!" +
                                "\n- Przynajmniej jedna Kwestia musi mieć ustawioną wartość!";
            if (!POPRAWNOSC) MessageBox.Show(errorMessage, "Wystąpiły niepoprawnie dane!");
            else DalejButton.IsEnabled = true;
            SprawdzButton.IsEnabled = false;
        }
        private void PrzyciskNegocjacji(object sender, RoutedEventArgs e)
        {
            MainWindow.Oblicz();
            MainWindow.page2.Uzupelnij();
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            mw.frame.Content = MainWindow.page2;
        }
        private void WyczyscKwestie(object sender, RoutedEventArgs e)
        {
            MainWindow.Kwestie.Clear();
            KwestieLista.Visibility = Visibility.Hidden;
            OpcjeLista.Visibility = Visibility.Hidden;
            OpcjeLabel.Visibility = Visibility.Hidden;
            NowaOpcjaTextBox.Visibility = Visibility.Hidden;
            ZAWSZEPOWTORZ();
            SuwakiSkala.IsEnabled = false;
            WyczyscButton.IsEnabled = false;
            SuwakiButton.IsEnabled = false;
        }
        private void UstawSuwaki(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MainWindow.Kwestie.Count; i++)
            {
                MainWindow.Kwestie[i].Waga = 50;
                for (int j = 0; j < MainWindow.Kwestie[i].Opcje.Count; j++)
                    MainWindow.Kwestie[i].Opcje[j].Waga = (j) * 100 / MainWindow.Kwestie[i].Opcje.Count / 10 * 10 + 10;
            }
            KwestieLista.Items.Refresh();
            OpcjeLista.Items.Refresh();
        }
        private void UstawSkale(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int skala = MainWindow.Kwestie[0].Skala;
            if (skala == 10)
            {
                button.Content = "SKALA: 20";
                skala = 5;
            }
            else
            {
                button.Content = "SKALA: 10";
                skala = 10;
            }
            for (int i = 0; i < MainWindow.Kwestie.Count; i++)
            {
                MainWindow.Kwestie[i].Skala = skala;
                for (int j = 0; j < MainWindow.Kwestie[i].Opcje.Count; j++)
                {
                    MainWindow.Kwestie[i].Opcje[j].Skala = skala;
                }
            }
            KwestieLista.Items.Refresh();
            OpcjeLista.Items.Refresh();
        }
        private void Zapisz(object sender, RoutedEventArgs e)
        {
            SprawdzPoprawnosc(sender,e);

            if (MainWindow.Kwestie.Count == 0)
            {
                DalejButton.IsEnabled = false;
                MessageBox.Show("Musisz mieć co zapisać!");
            }
            else if (POPRAWNOSC)
            {
                SaveFileDialog fileDialog = new SaveFileDialog()
                {
                    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
                };
                if(fileDialog.ShowDialog() == true)
                {
                    int KwestieCout = MainWindow.Kwestie.Count;
                    string zawartosc = "negocjator4200;";
                    for (int i = 0; i < KwestieCout; i++)
                        zawartosc += MainWindow.Kwestie[i].ZapiszKwestie();
                    File.WriteAllText(fileDialog.FileName, zawartosc);
                }
            }
        }
        private void Wczytaj(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Kwestie.Count != 0)
            {
                string sMessageBoxText = "Na pewno chcesz nadpisać te dane?";
                string sCaption = "Wczytywanie Danych";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rezultat = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                if (rezultat == MessageBoxResult.No) return;
            }

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };
            bool? res = fileDialog.ShowDialog();
            if (res.HasValue && res.Value)
            {
                StreamReader sr = new StreamReader(fileDialog.FileName);
                string[] zawartosc = sr.ReadToEnd().Split(';');
                if (zawartosc[0] != "negocjator4200")
                    MessageBox.Show("Nie potrafię tego rozszyfrować");
                else
                {
                    MainWindow.Kwestie = new List<Kwestia>();
                    int KwestieCout = zawartosc.Count();
                    for (int i = 1; i < KwestieCout - 1; i++) MainWindow.Kwestie.Add(new Kwestia(zawartosc[i]));
                    KwestieLista.ItemsSource = MainWindow.Kwestie;
                    KwestieLista.Visibility = Visibility.Visible;
                    OpcjeLista.Visibility = Visibility.Hidden;
                    SuwakiSkala.IsEnabled = true;
                    WyczyscButton.IsEnabled = true;
                    SuwakiButton.IsEnabled = true;
                    POPRAWNOSC = false;
                }
                sr.Close();
            }
        }

        private void AktualizacjaSuwaka(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ZAWSZEPOWTORZ();
        }
    }
}
