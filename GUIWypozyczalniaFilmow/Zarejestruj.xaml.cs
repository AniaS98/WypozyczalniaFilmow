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
using System.Windows.Shapes;
using WypozyczalniaFilmow;

namespace GUIWypozyczalniaFilmow
{
    /// <summary>
    /// Logika interakcji dla klasy Zarejestruj.xaml
    /// </summary>
    public partial class Zarejestruj : Window
    {
        Klient k;
        public Zarejestruj()
        {
            InitializeComponent();
        }

        private void button_zaluzKonto_Click(object sender, RoutedEventArgs e)
        {
            Klient k = new Klient();
            SystemKont sk = new SystemKont();
            this.k.Imie = textBox_imie.Text;
            this.k.Nazwisko = textBox1_nazwisko.Text;
            this.k.NrTelefonu = textBox2_nrTel.Text;
            this.k.Mail = textBox6_mail.Text;
            this.k.Login = textBox3_login.Text;
            this.k.Haslo = textBox4_haslo.Text;
            //if ()
                //sk.Dodaj(k);
        }
    }
}
