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

        ListaFilmowDostepnych filmy;
        SystemKont sk = new SystemKont();
        ObservableCollection<Klient> systemKont;
        public MainWindow()
        {

            InitializeComponent();
            systemKont = new ObservableCollection<Klient>();
            sk = (SystemKont)SystemKont.OdczytajXML("SystemKont.xml");
            systemKont = new ObservableCollection<Klient>(sk.ListaKont);
            filmy = (ListaFilmowDostepnych)ListaFilmowDostepnych.OdczytajXML("ListaFilmowDostepnych.xml");
            label_login.FontSize = 20;
            label1_haslo.FontSize = 20;
            button_zarejestruj.FontSize = 20;
            label_zaloguj.FontSize = 13;
            label2_rejestracja.FontSize = 13;
        }

        private void button_zaloguj_Click(object sender, RoutedEventArgs e)
        {
            if (sk.SprLoginHaslo(textBox_login.Text, textBox1_haslo.Password) != null)
            {
                Klient k = new Klient();
                k = sk.SprLoginHaslo(textBox_login.Text, textBox1_haslo.Password);
                KontoUzytkownika ko = new KontoUzytkownika(sk, k, filmy);
                ko.Top = 100;
                ko.Left = 400;
                ko.ShowDialog();
            }
            else
            {
                MessageBox.Show("Niepoprawny login lub hasło.");
                return;
            }
        }

        private void button_zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            Zarejestruj z = new Zarejestruj(sk);
            z.Top = 100;
            z.Left = 400;
            z.ShowDialog();
        }
    }
}