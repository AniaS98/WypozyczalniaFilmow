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
    /// Klasa Film
    /// </summary>
    [Serializable]
    public class Film : IComparable
    {
        private string nazwa;
        private string opis;
        private string rezyser;
        private string rokWydania;
        private Gatunki gatunek;
        private DateTime dataWypozyczenia;
        private DateTime dataOddania;

        /// <summary>
        /// Nazwa filmu
        /// </summary>
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Opis filmu
        /// </summary>
        public string Opis { get => opis; set => opis = value; }
        /// <summary>
        /// Reżyser filmu 
        /// </summary>
        public string Rezyser { get => rezyser; set => rezyser = value; }
        /// <summary>
        /// Rok wydania filmu
        /// </summary>
        public string RokWydania { get => rokWydania; set => rokWydania = value; }
        /// <summary>
        /// Gatunek filmu
        /// </summary>
        public Gatunki Gatunek { get => gatunek; set => gatunek = value; }
        /// <summary>
        /// Data wypożyczenia filmu
        /// </summary>
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        /// <summary>
        /// Data oddania filmu
        /// </summary>
        public DateTime DataOddania { get => dataOddania; set => dataOddania = value; }
        /// <summary>
        /// Konstruktor nieparametryczny klasy Film przypisujący systemowaą minimalną datę do zmiennych dataWypożyczenia, dataOddania
        /// </summary>
        public Film()
        {
            dataWypozyczenia = DateTime.MinValue;
            dataOddania = DateTime.MinValue;
        }
        /// <summary>
        /// Konstruktor parametryczny klasy Film przypisujący wartości zmiennym
        /// </summary>
        /// <param name="n">Nazwa</param>
        /// <param name="o">Opis</param>
        /// <param name="r">Reżyser</param>
        /// <param name="rw">Rok wydania</param>
        /// <param name="g">Gatunek</param>
        public Film(string n, string o, string r, string rw, Gatunki g) : this()
        {
            nazwa = n;
            opis = o;
            rezyser = r;
            rokWydania = rw;
            gatunek = g;
        }
        /// <summary>
        /// Wypisywanie informacji o filmie
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Nazwa: " + Nazwa + "\nGatunek: " + Gatunek + "\nReżyser: " + Rezyser + "\nRok wydania: " + RokWydania + "\nOpis: " + Opis;
        }
        /// <summary>
        /// Interfejs IComparable porównujący nazwy filmów
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            if (o != null)
            {
                Film f = (Film)o;
                int cmp = this.Nazwa.CompareTo(f.Nazwa);
                if (cmp != 0)
                    return cmp;
                else return 1;
            }
            return 1;
        }
    }
}
