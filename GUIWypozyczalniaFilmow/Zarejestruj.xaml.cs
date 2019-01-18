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
    /// Logika interakcji dla klasy Zarejestruj.xaml
    /// </summary>
    public partial class Zarejestruj : Window
    {
        SystemKont systemk = new SystemKont();
        public Zarejestruj()
        {
            InitializeComponent();
        }

        public Zarejestruj(SystemKont sk) : this()
        {
            systemk = sk;
        }


        private void button_zalozKonto_Click(object sender, RoutedEventArgs e)
        {
            Klient k = new Klient();
            k.Imie = textBox_imie.Text;
            k.Nazwisko = textBox1_nazwisko.Text;
            k.NrTelefonu = textBox2_nrTel.Text;
            if (textBox_imie.Text == "" || textBox1_nazwisko.Text == "" || textBox2_nrTel.Text == "" || textBox6_mail.Text == "" || textBox3_login.Text == "" || textBox4_haslo.Password == "" || textBox5_powtorzHaslo.Password == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
                return;
            }
            if (textBox2_nrTel.Text.Length != 9)
            {
                MessageBox.Show("Zly numer telefonu. Numery wyłacznie 9 cyfrowe.");
                return;
            }
            k.Mail = textBox6_mail.Text;
            k.Login = textBox3_login.Text;
            if (systemk.CzyIstnieje(textBox3_login.Text))
            {
                MessageBox.Show("Taki login już istnieje.");
                return;
            }
            k.Haslo = textBox4_haslo.Password;
            k.PotworzHaslo = textBox5_powtorzHaslo.Password;
            if (textBox4_haslo.Password != textBox5_powtorzHaslo.Password)
            {
                MessageBox.Show("Źle powtórzyłeś hasło.");
                return;
            }
            k.ListaWypozyczonychFilmow = new List<Film>();
            systemk.Dodaj(k);
            SystemKont.ZapiszXML("SystemKont.xml", systemk);
            this.Close();
        }

        private void button_anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}