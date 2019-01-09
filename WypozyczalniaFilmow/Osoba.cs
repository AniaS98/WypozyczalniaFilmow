using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public abstract class Osoba
    {
        private string imie;
        private string nazwisko;
        private string nrTelefonu;
        private string mail;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string NrTelefonu { get => nrTelefonu; set => nrTelefonu = value; }
        public string Mail { get => mail; set => mail = value; }

        public Osoba()
        {
            imie = "";
            nazwisko = "";
            nrTelefonu = "";
            mail = "";
        }

        public Osoba(string i, string n, string nrT, string m):this()
        {
            imie = i;
            nazwisko = n;
            nrTelefonu = nrT;
            mail = m;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Imie + " " + Nazwisko + " " + NrTelefonu + " " + Mail);
            return sb.ToString();
        }

    }
}
