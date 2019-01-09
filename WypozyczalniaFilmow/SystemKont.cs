using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class SystemKont
    {
        private List<Klient> listaKont;

        internal List<Klient> ListaKont { get => listaKont; set => listaKont = value; }

        public SystemKont()
        {
            ListaKont = new List<Klient>();
        }

        public void Dodaj(Klient k)
        {
            ListaKont.Add(k);
        }

        public bool CzyIstnieje(string nrL)
        {
            foreach(Klient n in listaKont)
            {
                if (n.Login == nrL)
                    return true;
            }
            return false;
        }

        public void Usun(Klient k)
        {
            listaKont.Remove(k);
        }
    }
}
