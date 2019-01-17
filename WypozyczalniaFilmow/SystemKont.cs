using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WypozyczalniaFilmow
{
    /// <summary>
    /// Klasa SystemKont
    /// </summary>
    [Serializable]
    public class SystemKont
    {
        private List<Klient> listaKont;
        /// <summary>
        /// Lista kont w systemie kont
        /// </summary>
        public List<Klient> ListaKont { get => listaKont; set => listaKont = value; }

        /// <summary>
        /// Konstryktor klasy SystemKont inicjujący pustą listę kont
        /// </summary>
        public SystemKont()
        {
            listaKont = new List<Klient>();
        }
        /// <summary>
        /// Doodanie klienta do listy kont
        /// </summary>
        /// <param name="k">Klient</param>
        public void Dodaj(Klient k)
        {
            listaKont.Add(k);
        }
        /// <summary>
        /// Sprawdzanie czy login już istnieje w sysytemie
        /// </summary>
        /// <param name="nrL">Numer login</param>
        /// <returns></returns>
        public bool CzyIstnieje(string nrL)
        {
            foreach (Klient n in listaKont)
            {
                if (n.Login == nrL)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Usunięcie klienta z listy kont
        /// </summary>
        /// <param name="k">Klient</param>
        public void Usun(Klient k)
        {
            listaKont.Remove(k);
        }
        /// <summary>
        /// Sprawdzenie czy podany login i hasło jest na liście kont, jesli istanieje to zwracany jest klient
        /// </summary>
        /// <param name="l">Login</param>
        /// <param name="h">Hasło</param>
        /// <returns></returns>
        public Klient SprLoginHaslo(string l, string h)
        {
            foreach (Klient k in listaKont)
            {
                if (k.Login == l && k.Haslo == h)
                {
                    return k;
                }
            }
            return null;
        }
        /// <summary>
        /// Wprowadznie zmian na liscie wypożyczonych filmów klienta
        /// </summary>
        /// <param name="k">Klient</param>
        /// <param name="l">Lista wypożyczonych filmów po modyfikacji</param>
        public void WprowadzZmiany(Klient k, List<Film> l)
        {
            Klient klient = k;
            k.ListaWypozyczonychFilmow = l;
        }
        /// <summary>
        /// Wypisywanie listy klientów nalezących do systemu kont
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Klient k in listaKont)
            {
                sb.AppendLine(k.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Zapis do pliku XML klasy SystemKont
        /// </summary>
        /// <param name="nazwaPliku">Nazwa pliku</param>
        /// <param name="s"></param>
        public static void ZapiszXML(string nazwaPliku, SystemKont s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SystemKont));
            StreamWriter sw = new StreamWriter(nazwaPliku);
            serializer.Serialize(sw, s);
            sw.Close();
        }
        /// <summary>
        /// Odczyt pliku XML zawierającego dane na temat klasy SystemKont
        /// </summary>
        /// <param name="nazwaPliku">Nazwa pliku</param>
        /// <returns></returns>
        public static Object OdczytajXML(string nazwaPliku)
        {
            SystemKont systemOdczytany;
            try
            {
                TextReader tr = new StreamReader(nazwaPliku);
                XmlSerializer serializer = new XmlSerializer(typeof(SystemKont));
                systemOdczytany = (SystemKont)serializer.Deserialize(tr);
                tr.Close();
                return systemOdczytany;
            }
            catch (FileNotFoundException)
            {
                SystemSounds.Exclamation.Play();
                Console.WriteLine("Plik {0} nie istnieje!!!", nazwaPliku);
            }
            return null;
        }
    }
}
