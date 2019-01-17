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
    public class ListaFilmowDostepnychTests
    {
        [TestMethod()]
        public void ListaFilmowDostepnychTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListaFilmowDostepnychTest1()
        {
            ListaFilmowDostepnych lfd = new ListaFilmowDostepnych();
            lfd.Nazwa = "Nazwa";
            string expected = "Nazwa";
            Assert.AreEqual(expected, lfd.Nazwa);
        }

        [TestMethod()]
        public void DodajTest()
        {
            ListaFilmowDostepnych lfd = new ListaFilmowDostepnych();
            Film film = new Film("a", "b", "c", "1887", Gatunki.Dramat);
            bool expected = true;
            lfd.Dodaj(film);
            bool actual = lfd.ListaFilmow.Contains(film);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WypozyczenieTest()
        {
            ListaFilmowDostepnych lista = new ListaFilmowDostepnych();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            Film f = new Film("a", "b", "c", "1887", Gatunki.Dramat);
            bool expected1 = true; // w liscie wypożyczonych filmów
            bool expected2 = false;
            lista.Wypozyczenie(k, f);

            bool actual1 = k.ListaWypozyczonychFilmow.Contains(f);
            bool actual2 = lista.ListaFilmow.Contains(f);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);

        }

        [TestMethod()]
        public void OddajTest()
        {
            ListaFilmowDostepnych lista = new ListaFilmowDostepnych();
            Klient k = new Klient("a", "b", "468795142", "mail", "l", "h");
            Film f = new Film("a", "b", "c", "1887", Gatunki.Dramat);
            k.ListaWypozyczonychFilmow.Add(f);
            bool expected1 = false;
            bool expected2 = true;
            lista.Oddaj(k, f);
            bool actual1 = k.ListaWypozyczonychFilmow.Contains(f);
            bool actual2 = lista.ListaFilmow.Contains(f);
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod()]
        public void PrzedluzTest()
        {
            ListaFilmowDostepnych lista = new ListaFilmowDostepnych();
            Film f = new Film("a", "b", "c", "1887", Gatunki.Dramat);

            string dataOddania = "22-03-2018";
            string expected = "22-04-2018";
            DateTime parsedDataOddania = DateTime.Parse(dataOddania);
            DateTime parsedExpected = DateTime.Parse(expected);

            DateTime actual;
            f.DataOddania = parsedDataOddania;
            lista.Przedluz(f);
            actual = f.DataOddania;

            Assert.AreEqual(parsedExpected, actual);
            //Assert.Inconclusive("Coś nie działa."); Dlaczego z tym nie działa?

        }

        [TestMethod()]
        public void SzukanieGatunkowTest()
        {
            List<Film> nowaLista = new List<Film>();
            ListaFilmowDostepnych lfd = new ListaFilmowDostepnych();
            Film f = new Film("a", "b", "c", "1887", Gatunki.Dramat);
            Film f2 = new Film("aaa", "b", "c", "1887", Gatunki.Biograficzny);
            lfd.ListaFilmow.Add(f);
            lfd.ListaFilmow.Add(f2);
            bool expected1 = true;
            bool expected2 = false;

            nowaLista = lfd.SzukanieGatunkow(lfd.ListaFilmow, Gatunki.Dramat);

            bool actual1 = nowaLista.Contains(f);
            bool actual2 = nowaLista.Contains(f2);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);

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

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}