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
using System.Windows.Shapes;
using WypozyczalniaFilmow;

namespace GUIWypozyczalniaFilmow
{
    /// <summary>
    /// Logika interakcji dla klasy KontoUzytkownika.xaml
    /// </summary>
    public partial class KontoUzytkownika : Window
    {
        public SystemKont sk;
        ObservableCollection<Film> listaWypozyczonych;
        ListaFilmowDostepnych filmy;
        ObservableCollection<Film> lf;
        Klient klient;
        Film film_data;
        public KontoUzytkownika()
        {
            InitializeComponent();
        }

        public KontoUzytkownika(SystemKont s, Klient k, ListaFilmowDostepnych f) : this()
        {
            sk = s;
            klient = k;
            listaWypozyczonych = new ObservableCollection<Film>(k.ListaWypozyczonychFilmow);
            textBlock_imie.Text = k.Imie;
            textBlock_nazwisko.Text = k.Nazwisko;
            listBox_listaFilmow.ItemsSource = listaWypozyczonych;
            filmy = f;
            lf = new ObservableCollection<Film>(filmy.ListaFilmow);

        }

        private void button_oddaj_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_listaFilmow.SelectedIndex;
            if (zaznaczony != -1)
            {
                filmy.Oddaj(klient, listaWypozyczonych[zaznaczony]);
                listaWypozyczonych.RemoveAt(zaznaczony);
            }
            else
            {
                MessageBox.Show("Zaznacz film, który chcesz oddać.");
                return;
            }
        }

        private void button_wypozycz_Click(object sender, RoutedEventArgs e)
        {
            Wypozycz w = new Wypozycz(klient, filmy);
            w.Top = 100;
            w.Left = 400;
            w.ShowDialog();
            this.filmy = w.filmy;
            this.klient = w.klient;
            listaWypozyczonych = new ObservableCollection<Film>(klient.ListaWypozyczonychFilmow);
            lf = new ObservableCollection<Film>(filmy.ListaFilmow);
            listBox_listaFilmow.ItemsSource = listaWypozyczonych;
        }

        private void button_wyloguj_Click(object sender, RoutedEventArgs e)
        {
            ListaFilmowDostepnych.ZapiszXML("ListaFilmowDostepnych.xml", filmy);
            sk.WprowadzZmiany(klient, listaWypozyczonych.ToList());
            SystemKont.ZapiszXML("SystemKont.xml", sk);
            this.Close();
        }

        private void button_data_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_listaFilmow.SelectedIndex;
            if (zaznaczony != -1)
            {
                film_data = listaWypozyczonych[zaznaczony];
                textBlock_datawyp.Text = film_data.DataWypozyczenia.ToShortDateString();
                textBlock_dataodd.Text = film_data.DataOddania.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Zaznacz film.");
                return;
            }
        }

        private void button_przedluz_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_listaFilmow.SelectedIndex;

            if (zaznaczony != -1)
            {
                filmy.Przedluz(listaWypozyczonych[zaznaczony]);
                if (listaWypozyczonych[zaznaczony].DataOddania.Month - listaWypozyczonych[zaznaczony].DataWypozyczenia.Month >= 4)
                {
                    MessageBox.Show("Nie możesz wypożyczyc filmu na dłużej niż 4 miesiące.");
                    return;
                }
                else textBlock_dataodd.Text = listaWypozyczonych[zaznaczony].DataOddania.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Zaznacz film.");
                return;
            }
        }
    }
}