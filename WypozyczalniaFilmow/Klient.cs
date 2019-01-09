using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class Klient : Osoba
    {
        private string login;
        private string haslo;
        private List<Film> listaWypozyczonychFilmow;

        public string Login { get => login; set => login = value; }
        public string Haslo { get => haslo; set => haslo = value; }
        internal List<Film> ListaWypozyczonychFilmow { get => listaWypozyczonychFilmow; set => listaWypozyczonychFilmow = value; }

        public Klient():base()
        {
            login = "";
            haslo = "";
            listaWypozyczonychFilmow = new List<Film>();
        }

        public Klient(string i, string n, string nrT, string m, string l, string h):base(i, n, nrT, m)
        {
            login = l;
            haslo = h;
            listaWypozyczonychFilmow = new List<Film>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Film f in listaWypozyczonychFilmow)
                sb.Append(f.ToString() + "\nData wypożyczenia: " + f.DataWypozyczenia.ToShortDateString() + "\nData oddania: " + f.DataOddania.ToShortDateString());
            return base.ToString() + " " + this.login + " " + this.haslo;
            /*StringBuilder sb = new StringBuilder();
            sb.AppendLine(Imie + " " + Nazwisko + " " + NrTelefonu + " " + Mail + " " + Login + " " + Haslo);
            foreach(Film f in listaWypozyczonychFilmow)
            {
                sb.AppendLine(f.ToString()+"\nData wypożyczenia: "+ f.DataWypozyczenia.ToShortDateString() + "\nData oddania: " + f.DataOddania.ToShortDateString());
            }
            return sb.ToString();*/
        }

    }
}
