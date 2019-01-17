using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WypozyczalniaFilmow
{
    /// <summary>
    /// Klasa ListaFilmowDostepnych
    /// </summary>
    [Serializable]
    public class ListaFilmowDostepnych
    {

        private string nazwa;
        private List<Film> listaFilmow;
        /// <summary>
        /// Nazwa grupy filmów
        /// </summary>
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Lista filmów dostępnych do wypożyczenia
        /// </summary>
        public List<Film> ListaFilmow { get => listaFilmow; set => listaFilmow = value; }
        /// <summary>
        /// Konstruktor klasy ListaFilmowDostepnych inicjujący pustą listę filmów dostępnych do wypożyczenia
        /// </summary>
        public ListaFilmowDostepnych()
        {
            ListaFilmow = new List<Film>();
        }
        /// <summary>
        /// Konstruktor paramateryczny klasy ListaFilmowDostepnych przypisujący nazwę grupy filmów
        /// </summary>
        /// <param name="n">Nazwa grupy Filmów</param>
        public ListaFilmowDostepnych(string n) : this()
        {
            Nazwa = n;
        }
        /// <summary>
        /// Dodanie filmu do listy filmów dostępnych do wypożyczenia
        /// </summary>
        /// <param name="f">Film</param>
        public void Dodaj(Film f)
        {
            ListaFilmow.Add(f);
        }
        /// <summary>
        /// Wypożyczenie filmu przez klienta. Film zostaje usunięty z listy filmów dotępnych do wypożyczenia i zostaje dodany do listy filmów wypożyczonych przez klienta.
        /// </summary>
        /// <param name="k">Klient</param>
        /// <param name="f">Film</param>
        public void Wypozyczenie(Klient k, Film f)
        {
            k.ListaWypozyczonychFilmow.Add(f);
            ListaFilmow.Remove(f);
            f.DataWypozyczenia = DateTime.Now;
            f.DataOddania = f.DataWypozyczenia.AddMonths(1);
        }
        /// <summary>
        /// Oddanie filmu wypożyczonego wcześniej przez klienta. Film zostaje dodany do listy filmów dostępnych do wypożyczenia i usuniety z listy filmów wypozyczonych przez klienta.
        /// </summary>
        /// <param name="k">Klient</param>
        /// <param name="f">Film</param>
        public void Oddaj(Klient k, Film f)
        {
            k.ListaWypozyczonychFilmow.Remove(f);
            ListaFilmow.Add(f);
        }
        /// <summary>
        /// Przedłużenie terminu oddania filmu wypożyczonego przez klienta
        /// </summary>
        /// <param name="f">Film</param>
        public void Przedluz(Film f)
        {
            f.DataOddania = f.DataOddania.AddMonths(1);
        }
        /// <summary>
        /// Szukanie filmów podanycm gatunku. Zwaracana jest nowa lista z filmami wyłącznie o danym gatunku.
        /// </summary>
        /// <param name="lf">Lista filmów przeszukiwana</param>
        /// <param name="g">Gatunek filmu</param>
        /// <returns></returns>
        public List<Film> SzukanieGatunkow(List<Film> lf, Gatunki g)
        {
            List<Film> nowaLista = new List<Film>();
            foreach (Film f in lf)
            {
                if (f.Gatunek == g)
                {
                    nowaLista.Add(f);
                }
            }
            return nowaLista;
        }
        /// <summary>
        /// Zapis do pliku XML klasy ListaFilmowDostepnych
        /// </summary>
        /// <param name="nazwaPliku"></param>
        /// <param name="l"></param>
        public static void ZapiszXML(string nazwaPliku, ListaFilmowDostepnych l)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListaFilmowDostepnych));
            StreamWriter sw = new StreamWriter(nazwaPliku);
            serializer.Serialize(sw, l);
            sw.Close();
        }
        /// <summary>
        /// Odczyt pliku XML zawierającego dane na temat klasy ListaFilmowDostepnych
        /// </summary>
        /// <param name="nazwaPliku"></param>
        /// <returns></returns>
        public static Object OdczytajXML(string nazwaPliku)
        {
            ListaFilmowDostepnych listaFilmowOdczytana;
            try
            {
                TextReader tr = new StreamReader(nazwaPliku);
                XmlSerializer serializer = new XmlSerializer(typeof(ListaFilmowDostepnych));
                listaFilmowOdczytana = (ListaFilmowDostepnych)serializer.Deserialize(tr);
                tr.Close();
                return listaFilmowOdczytana;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik {0} nie istnieje!!!", nazwaPliku);
            }
            return null;
        }
        /// <summary>
        /// Wypisywanie listy filmów możliwych do wypożyczenia
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Filmy z gatunku: " + Nazwa);
            foreach (Film f in ListaFilmow)
            {
                sb.AppendLine(f.ToString());
            }
            return sb.ToString();
        }
    }
}
