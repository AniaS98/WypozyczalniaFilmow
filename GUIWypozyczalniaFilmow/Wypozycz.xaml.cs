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
    /// Logika interakcji dla klasy Wypozycz.xaml
    /// </summary>
    public partial class Wypozycz : Window
    {
        public ListaFilmowDostepnych filmy;
        ObservableCollection<Film> lf;
        public Klient klient;
        ObservableCollection<Film> dramaty;
        ObservableCollection<Film> psychologiczne;
        ObservableCollection<Film> wojenne;
        ObservableCollection<Film> gangsterskie;
        ObservableCollection<Film> biograficzne;
        ObservableCollection<Film> thrillery;
        ObservableCollection<Film> komedie;
        ObservableCollection<Film> horrory;
        ObservableCollection<Film> obyczajowe;

        public Wypozycz()
        {
            InitializeComponent();
        }

        public Wypozycz(Klient k, ListaFilmowDostepnych f) : this()
        {
            klient = k;
            filmy = f;
            lf = new ObservableCollection<Film>(filmy.ListaFilmow);
            listBox_lista.ItemsSource = lf;
            dramaty = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Dramat));
            psychologiczne = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Psychologiczny));
            wojenne = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Wojenny));
            gangsterskie = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Gangsterski));
            biograficzne = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Biograficzny));
            thrillery = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Thriller));
            komedie = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Komedia));
            horrory = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Horror));
            obyczajowe = new ObservableCollection<Film>(filmy.SzukanieGatunkow(lf.ToList(), Gatunki.Obyczajowy));
            button_wypozycz.FontSize = 14;
            label1_lista.FontSize = 14;
            label_kategoria.FontSize = 14;
        }

        private void button_wypozycz_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_lista.SelectedIndex;
            if (zaznaczony != -1)
            {

                if (comboBox_kategorie.Text == "Dramat")
                {
                    Film film = dramaty[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    dramaty.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Psychologiczny")
                {
                    Film film = psychologiczne[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    psychologiczne.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Biograficzny")
                {
                    Film film = biograficzne[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    biograficzne.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Thriller")
                {
                    Film film = thrillery[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    thrillery.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Komedia")
                {
                    Film film = komedie[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    komedie.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Obyczajowy")
                {
                    Film film = obyczajowe[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    obyczajowe.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Gangsterski")
                {
                    Film film = gangsterskie[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    gangsterskie.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Horror")
                {
                    Film film = komedie[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    komedie.Remove(film);
                }
                else if (comboBox_kategorie.Text == "Wojenny")
                {
                    Film film = wojenne[zaznaczony];
                    filmy.Wypozyczenie(klient, film);
                    wojenne.Remove(film);
                }
                else
                {
                    filmy.Wypozyczenie(klient, lf[zaznaczony]);
                    lf.RemoveAt(zaznaczony);
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczyłeś żadnego filmu.");
                return;
            }
            this.Close();
        }

        private void comboBox_kategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = (comboBox_kategorie.SelectedValue as ComboBoxItem).Content.ToString();

            switch (selected)
            {
                case "Dramat":
                    listBox_lista.ItemsSource = dramaty;
                    break;
                case "Biograficzny":
                    listBox_lista.ItemsSource = biograficzne;
                    break;
                case "Psychologiczny":
                    listBox_lista.ItemsSource = psychologiczne;
                    break;
                case "Gangsterski":
                    listBox_lista.ItemsSource = gangsterskie;
                    break;
                case "Komedia":
                    listBox_lista.ItemsSource = komedie;
                    break;
                case "Thriller":
                    listBox_lista.ItemsSource = thrillery;
                    break;
                case "Wojenny":
                    listBox_lista.ItemsSource = wojenne;
                    break;
                case "Obyczajowy":
                    listBox_lista.ItemsSource = obyczajowe;
                    break;
                case "Horror":
                    listBox_lista.ItemsSource = horrory;
                    break;

                default:
                    listBox_lista.ItemsSource = filmy.ListaFilmow;
                    break;
            }
        }
    }
}