using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class ListaFilmowPoGatunkach
    {
        private string nazwa;
        private List<Film> listaFilmow;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        internal List<Film> ListaFilmow { get => listaFilmow; set => listaFilmow = value; }

        public ListaFilmowPoGatunkach()
        {
            listaFilmow = new List<Film>();
        }

        public ListaFilmowPoGatunkach(string n):this()
        {
            nazwa = n;
        }

        public void Dodaj(Film f)
        {
            listaFilmow.Add(f);
        }

        public void Wypozyczenie(Klient k, Film f)
        {
                k.ListaWypozyczonychFilmow.Add(f);
                ListaFilmow.Remove(f);
                f.DataWypozyczenia = DateTime.Now;
                f.DataOddania = f.DataWypozyczenia.AddMonths(1);
        }

        public void Oddaj(Klient k, Film f)
        {
            k.ListaWypozyczonychFilmow.Remove(f);
            ListaFilmow.Add(f);
        }

        public void Przedluz(int i, Film f)
        {
            f.DataOddania.AddDays(i);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Filmy z gatunku: "+Nazwa);
            foreach(Film f in listaFilmow)
            {
                sb.AppendLine(f.ToString());
            }
            return sb.ToString();
        }
    }
}
