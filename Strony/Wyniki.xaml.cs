using negocjacja.Modele;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace negocjacja.Strony
{
    /// <summary>
    /// Logika interakcji dla klasy Wyniki.xaml
    /// </summary>
    public partial class Wyniki : Window
    {
        public Wyniki()
        {
            InitializeComponent();

            DataGridTextColumn column;
            column = new DataGridTextColumn();
            column.Header = "N";
            column.Binding = new Binding("N");
            column.Foreground = Styl.CzcionkaCiemna;
            column.CellStyle = new Style(typeof(DataGridCell));
            column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloCiemne)));
            KombinacjeLista.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "SUMA";
            column.Binding = new Binding("SUMA");
            column.Foreground = Styl.CzcionkaWazna;
            column.CellStyle = new Style(typeof(DataGridCell));
            column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloWazne)));
            KombinacjeLista.Columns.Add(column);

            for (int i = 0; i < MainWindow.Kwestie.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = " ";
                column.Binding = new Binding("split" + i);
                column.CellStyle = new Style(typeof(DataGridCell));
                column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloCiemne)));
                KombinacjeLista.Columns.Add(column);

                column = new DataGridTextColumn();
                column.Header = MainWindow.Kwestie[i].Nazwa;
                column.Binding = new Binding(MainWindow.Kwestie[i].ID.ToString());
                column.Foreground = Styl.CzcionkaCiemna;
                column.CellStyle = new Style(typeof(DataGridCell));
                column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloJasne)));
                KombinacjeLista.Columns.Add(column);

                column = new DataGridTextColumn();
                column.Header = "%";
                column.Binding = new Binding("PKT" + i);
                column.Foreground = Styl.CzcionkaJasna;
                column.CellStyle = new Style(typeof(DataGridCell));
                column.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Styl.TloZwykle)));
                KombinacjeLista.Columns.Add(column);
            }

            for (int j = 0; j < MainWindow.Kombinacje.Count; j++)
            {
                dynamic row = new ExpandoObject();
                ((IDictionary<String, Object>)row)["N"] = j+1;
                ((IDictionary<String, Object>)row)["SUMA"] = Math.Round(MainWindow.Kombinacje[j].Waga, 2);
                for (int i = 0; i < MainWindow.Kwestie.Count; i++)
                {
                    ((IDictionary<String, Object>)row) [MainWindow.Kwestie[i].ID.ToString()] = MainWindow.Kombinacje[j].Opcje[i].Nazwa;
                    ((IDictionary<String, Object>)row) ["PKT" + i] = Math.Round(MainWindow.Kombinacje[j].Opcje[i].Waga,2);
                }
                KombinacjeLista.Items.Add(row);
            }
            KombinacjeLista.Items.Refresh();
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
