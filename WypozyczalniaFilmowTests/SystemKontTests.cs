using Microsoft.VisualStudio.TestTools.UnitTesting;
using WypozyczalniaFilmow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Tests
{
    [TestClass()]
    public class SystemKontTests
    {
        [TestMethod()]
        public void SystemKontTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DodajTest()
        {
            SystemKont sk = new SystemKont();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            bool expected = true;
            sk.Dodaj(k);
            bool actual = sk.ListaKont.Contains(k);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CzyIstniejeTest()
        {
            SystemKont sk = new SystemKont();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            sk.ListaKont.Add(k);
            bool expected = true;
            bool actual = sk.CzyIstnieje(k.Login);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UsunTest()
        {
            SystemKont sk = new SystemKont();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            sk.ListaKont.Add(k);
            bool expected = false;
            sk.Usun(k);
            bool actual = sk.ListaKont.Contains(k);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SprLoginHasloTest()
        {
            SystemKont sk = new SystemKont();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            sk.ListaKont.Add(k);
            Klient expected = k;
            Klient actual = sk.SprLoginHaslo(k.Login, k.Haslo);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WprowadzZmianyTest()
        {
            SystemKont sk = new SystemKont();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            List<Film> listaWprowadzana = new List<Film>();
            Film f1 = new Film("a", "b", "c", "1887", Gatunki.Dramat);
            listaWprowadzana.Add(f1);
            sk.WprowadzZmiany(k, listaWprowadzana);
            bool expected = true;
            bool actual = k.ListaWypozyczonychFilmow.Contains(f1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ZapiszXMLTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OdczytajXMLTest()
        {
            Assert.Fail();
        }
    }
}