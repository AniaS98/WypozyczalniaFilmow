using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class Film
    {
        private string nazwa;
        private string opis;
        private string rezyser;
        private string rokWydania;
        private Gatunki gatunek;
        private DateTime dataWypozyczenia;
        private DateTime dataOddania;
        

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Opis { get => opis; set => opis = value; }
        public string Rezyser { get => rezyser; set => rezyser = value; }
        public string RokWydania { get => rokWydania; set => rokWydania = value; }
        public Gatunki Gatunek { get => gatunek; set => gatunek = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public DateTime DataOddania { get => dataOddania; set => dataOddania = value; }

        public Film(string n, string o, string r, string rw, Gatunki g)
        {
            nazwa = n;
            opis = o;
            rezyser = r;
            rokWydania = rw;
            dataWypozyczenia = DateTime.MinValue;
            dataOddania = DateTime.MinValue;
        }

        public override string ToString()
        {
            return "Nazwa: " + Nazwa + "\nGatunek: " + Gatunek+ "\nReżyser: " + Rezyser + "\nRok wydania: " + RokWydania + "\nOpis: " + Opis;
        }
    }
}
