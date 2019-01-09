using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WypozyczalniaFilmow;

namespace GUIWypozyczalniaFilmow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Klient> listaKlientow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_zaloguj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            Zarejestruj z = new Zarejestruj();
            z.ShowDialog();
        }
    }
}
