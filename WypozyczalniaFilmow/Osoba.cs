using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WypozyczalniaFilmow
{
    /// <summary>
    /// Klasa Osoba
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Klient))]
    public abstract class Osoba
    {
        private string imie;
        private string nazwisko;
        private string nrTelefonu;
        private string mail;
        /// <summary>
        /// Imię osoby
        /// </summary>
        public string Imie { get => imie; set => imie = value; }
        /// <summary>
        /// Nazwisko osoby
        /// </summary>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        /// <summary>
        /// Nuemr telefonu osoby
        /// </summary>
        public string NrTelefonu { get => nrTelefonu; set => nrTelefonu = value; }
        /// <summary>
        /// E-mail osoby
        /// </summary>
        public string Mail { get => mail; set => mail = value; }
        /// <summary>
        /// Konstruktor nieparametryczny klasy Osoba przypisujący puste wartości
        /// </summary>
        public Osoba()
        {
            imie = "";
            nazwisko = "";
            nrTelefonu = "";
            mail = "";
        }
        /// <summary>
        /// Konstruktor parametrycznyy klasy Osoba przypisujący konkretne wartości
        /// </summary>
        /// <param name="i">Imie</param>
        /// <param name="n">Nazwisko</param>
        /// <param name="nrT">Nuemr telefonu</param>
        /// <param name="m">E-mail</param>
        public Osoba(string i, string n, string nrT, string m) : this()
        {
            imie = i;
            nazwisko = n;
            nrTelefonu = nrT;
            mail = m;
        }
        /// <summary>
        /// Wypisywanie danych osoby
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Imie + " " + Nazwisko + " " + nrTelefonu + " " + mail;

        }
    }
}
