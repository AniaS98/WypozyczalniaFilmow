using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    /// <summary>
    /// Klasa Klient, która dziedziczy po klasie Osoba
    /// </summary>
    [Serializable]
    public class Klient : Osoba
    {

        private string login;
        private string haslo;
        private string potworzHaslo;
        private List<Film> listaWypozyczonychFilmow;
        /// <summary>
        /// Login klienta
        /// </summary>
        public string Login { get => login; set => login = value; }
        /// <summary>
        /// Hasło klienta
        /// </summary>
        public string Haslo { get => haslo; set => haslo = value; }
        /// <summary>
        /// Zmienna pomocnicza do sprawdzenia poprawnosci wpisanego hasła
        /// </summary>
        public string PotworzHaslo { get => potworzHaslo; set => potworzHaslo = value; }
        /// <summary>
        /// Lista wypożyczonych filmów przez klienta
        /// </summary>
        public List<Film> ListaWypozyczonychFilmow { get => listaWypozyczonychFilmow; set => listaWypozyczonychFilmow = value; }
        /// <summary>
        /// Konstruktor nieparametryczny klasy Klient
        /// </summary>
        public Klient() { }
        /// <summary>
        /// Konstruktor parametryczny klasy Klient przypisujący wartości zmiennym oraz pobierający zmmienne z klasy Osoba
        /// </summary>
        /// <param name="i">Imię</param>
        /// <param name="n">Nazwisko</param>
        /// <param name="nrT">Numer telefonu</param>
        /// <param name="m">E-mail</param>
        /// <param name="l">Login</param>
        /// <param name="h">Hasło</param>
        public Klient(string i, string n, string nrT, string m, string l, string h) : base(i, n, nrT, m)
        {
            login = l;
            haslo = h;
            listaWypozyczonychFilmow = new List<Film>();
        }
        /// <summary>
        /// Sortowanie listy wypożyczoncyh filmów przez klienta według nazwy filmu
        /// </summary>
        public void Sortuj()
        {
            listaWypozyczonychFilmow.Sort();
        }
        /// <summary>
        /// Wypisywanie danych klienta oraz jego listy wypoozyczoncyh filmów
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Imie + " " + Nazwisko + " " + NrTelefonu + " " + Mail + " " + Login + " " + Haslo);
            foreach (Film f in listaWypozyczonychFilmow)
            {
                sb.AppendLine(f.ToString() + "\nData wypożyczenia: " + f.DataWypozyczenia.ToShortDateString() + "\nData oddania: " + f.DataOddania.ToShortDateString());
            }
            return sb.ToString();
        }
    }
}
