using negocjacja.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
    /// Logika interakcji dla klasy SuperNegocjacje.xaml
    /// </summary>
    public partial class SuperNegocjacje : Page
    {
        public static List<Kwestia> Propozycje;
        public List<double> KolejneWartosci;
        public double suma;
        public int liczbapropozycji = 4;
        public SuperNegocjacje()
        {
            InitializeComponent();
        }

        public void Uzupelnij()
        {
            lista.ItemsSource = MainWindow.Wyniki;
            KolejneWartosci = new List<double>();
            for (int i = 0; i < MainWindow.Wyniki.Count; i++)
                KolejneWartosci.Add(MainWindow.Wyniki[i].Opcje[0].Waga);
            suma = 0;
            for (int i = 0; i < MainWindow.Wyniki.Count; i++) suma += KolejneWartosci[i];
            suma = Math.Round(suma, 2);
            oplacalnosc.Text = suma.ToString();

            DataGridTextColumn column;
            datagrid.Columns.Clear();
            column = new DataGridTextColumn();
            column.Header = "SUMA";
            column.Binding = new Binding("SUMA");
            column.Foreground = Styl.CzcionkaWazna;
            column.CellStyle = new Style(typeof(DataGridCell));
            column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloWazne)));
            datagrid.Columns.Add(column);

            UzupelnijPropozycje(0);
            for (int i = 0; i < Propozycje[0].Opcje.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = " ";
                column.Binding = new Binding("split" + i);
                column.CellStyle = new Style(typeof(DataGridCell));
                column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloCiemne)));
                datagrid.Columns.Add(column);

                column = new DataGridTextColumn();
                column.Header = MainWindow.Kwestie[i].Nazwa;
                column.Binding = new Binding(MainWindow.Kwestie[i].ID.ToString());
                column.Foreground = Styl.CzcionkaCiemna;
                column.CellStyle = new Style(typeof(DataGridCell));
                column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloJasne)));
                datagrid.Columns.Add(column);
            }
            UzupelnijDatagrid();
        }

        private void GoWstecz(object sender, RoutedEventArgs e)
        {
            MainWindow.page1.SprawdzButton.IsEnabled = false;
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            mw.frame.Content = MainWindow.page1;
        }

        private void PokazWyniki(object sender, RoutedEventArgs e)
        {
            Wyniki okno = new Wyniki();
            okno.ShowDialog();
        }

        private void wybor(object sender, SelectionChangedEventArgs e)
        {
            var combobox = (ComboBox)sender;
            int kid = Convert.ToInt32(combobox.Tag.ToString());

            if (combobox.SelectedIndex > -1)
            {
                suma = 0;
                KolejneWartosci[kid] = MainWindow.Wyniki[kid].Opcje[combobox.SelectedIndex].Waga;
                for (int i = 0; i < MainWindow.Wyniki.Count; i++) suma += KolejneWartosci[i];
                suma = Math.Round(suma, 2);
            }
            oplacalnosc.Text = suma.ToString();
        }

        private void Proponuj(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            UzupelnijPropozycje(slider.Value);
            UzupelnijDatagrid();
        }

        private void UzupelnijPropozycje(double szukana)
        {
            Propozycje = new List<Kwestia>();
            List<Kwestia> pom = new List<Kwestia>();
            pom = MainWindow.Kombinacje.OrderBy(f => f.Waga).ToList();

            int index = 0, dodano = 0;
            while (index < pom.Count && dodano < liczbapropozycji)
            {
                if (pom[index].Waga >= szukana)
                {
                    dodano++;
                    Propozycje.Add(new Kwestia(pom[index]));
                }
                index++;
            }
            index = pom.Count - 1;
            if (dodano > 1) dodano = 0;
            while (index >= 0 && dodano < liczbapropozycji)
            {
                if (pom[index].Waga < szukana)
                {
                    dodano++;
                    Propozycje.Add(new Kwestia(pom[index]));
                }
                index--;
            }
            Propozycje = Propozycje.OrderBy(f => f.Waga).ToList();
        }

        private void UzupelnijDatagrid()
        {
            datagrid.Items.Clear();
            
            for (int j = 0; j < Propozycje.Count; j++)
            {
                dynamic row = new ExpandoObject();
                ((IDictionary<String, Object>)row)["SUMA"] = Math.Round(Propozycje[j].Waga, 2);
                for (int i = 0; i < Propozycje[j].Opcje.Count; i++)
                    ((IDictionary<String, Object>)row)[MainWindow.Kwestie[i].ID.ToString()] = Propozycje[j].Opcje[i].Nazwa;
                datagrid.Items.Add(row);
            }
            datagrid.Items.Refresh();
        }

        private void LiczbaWynikow(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            liczbapropozycji = Convert.ToInt32(slider.Value);
            if(MainWindow.Kombinacje != null && MainWindow.Kombinacje.Count > 0)
                Proponuj(sender, e);
        }

        private void Autor(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Olgierd Kuczyński ©2021 \n", "Autor Negocjatora4200");
        }
    }
}
