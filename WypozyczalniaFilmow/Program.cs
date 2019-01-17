using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    /// <summary>
    /// Wyliczeniaowy tym gatunków filmów
    /// </summary>
    public enum Gatunki
    {
        /// <summary>
        /// Gatunek dramat
        /// </summary>
        Dramat,
        /// <summary>
        /// Gatunek komedia
        /// </summary>
        Komedia,
        /// <summary>
        /// Gatunek horror
        /// </summary>
        Horror,
        /// <summary>
        /// Gatunek obyczjowy
        /// </summary>
        Obyczajowy,
        /// <summary>
        /// Gatunek biograficzny
        /// </summary>
        Biograficzny,
        /// <summary>
        /// Gatunek psychologiczy
        /// </summary>
        Psychologiczny,
        /// <summary>
        /// Gatunek wojenny
        /// </summary>
        Wojenny,
        /// <summary>
        /// Gatunek gangsterski
        /// </summary>
        Gangsterski,
        /// <summary>
        /// Gatunek thriller
        /// </summary>
        Thriller
    };
    class Program
    {
        static void Main(string[] args)
        {
            Film f1 = new Film("Skazani na Shawshank", "Adaptacja opowiadania Stephena Kinga. Niesłusznie skazany na dożywocie bankier, stara się przetrwać w brutalnym, więziennym świecie.", "Frank Darabont", "1994", Gatunki.Dramat);
            Film f2 = new Film("Nietykalni", "Sparaliżowany milioner zatrudnia do opieki młodego chłopaka z przedmieścia, który właśnie wyszedł z więzienia.", "Olivier Nakache, Eric Toledano", "2011", Gatunki.Biograficzny);
            Film f3 = new Film("Zielona mila", "Emerytowany strażnik więzienny opowiada przyjaciółce o niezwykłym mężczyźnie, którego skazano na śmierć za zabójstwo dwóch 9-letnich dziewczynek.", "Frank Darabont", "1999", Gatunki.Dramat);
            Film f4 = new Film("Ojciec chrzestny", "Opowieść o nowojorskiej rodzinie mafijnej. Starzejący się Don Corleone pragnie przekazać władzę swojemu synowi.", "Francis Ford Coppola", "1972", Gatunki.Dramat);
            Film f5 = new Film("Dwunastu gniewnych ludzi", "Dwunastu przysięgłych ma wydać wyrok w procesie o morderstwo. Jeden z nich ma wątpliwości dotyczące winy oskarżonego.", "Sidney Lumet", "1957", Gatunki.Dramat);
            Film f6 = new Film("Forrest Gump", "Historia życia Forresta, chłopca o niskim ilorazie inteligencji z niedowładem kończyn, który staje się miliarderem i bohaterem wojny w Wietnamie.", "Robert Zemeckis", "1994", Gatunki.Dramat);
            Film f7 = new Film("Lot nad kukułczym gniazdem ", "Historia złodzieja, szulera i chuligana, który, by uniknąć więzienia, udaje niepoczytalność. Trafia do szpitala dla umysłowo chorych, gdzie twardą ręką rządzi siostra Ratched.", "Milos Forman", "1975", Gatunki.Psychologiczny);
            Film f8 = new Film("Lista Schindlera", "Historia przedsiębiorcy Oskara Schindlera, który podczas II wojny światowej uratował przed pobytem w obozach koncentracyjnych 1100 Żydów.", "Steven Spielberg", "1993", Gatunki.Wojenny);
            Film f9 = new Film("Pulp Fiction", "Przemoc i odkupienie w opowieści o dwóch płatnych mordercach pracujących na zlecenie mafii, żonie gangstera, bokserze i parze okradającej ludzi w restauracji.", "Quentin Tarantino", "1994", Gatunki.Gangsterski);
            Film f10 = new Film("Życie jest piękne", "Zamknięty w obozie koncentracyjnym wraz z synem Guido próbuje przekonać chłopca, że okrutna rzeczywistość jest jedynie formą zabawy dla dorosłych.", "Roberto Beningi", "1997", Gatunki.Dramat);
            Film f11 = new Film("Siedem", "Dwóch policjantów stara się złapać seryjnego mordercę wybierającego swoje ofiary wg specjalnego \"klucza\".", "Dawid Fincher", "1995", Gatunki.Thriller);
            Film f12 = new Film("Podziemy krąg", "Dwóch mężczyzn znudzonych rutyną zakłada klub, w którym co tydzień odbywają się walki na gołe pięści.", "David Fincher", "1999", Gatunki.Thriller);
            Film f13 = new Film("Chłopcy z ferajny", "Kilkunastoletni Henry i Tommy DeVito trafiają pod opiekę potężnego gangstera. Obaj szybko uczą się panujących w mafii reguł.", "Martin Scorsese", "1990", Gatunki.Gangsterski);
            Film f14 = new Film("Pianista", "Podczas drugiej wojny światowej Władysław Szpilman, znakomity polski pianista, stara się przeżyć w okupowanej Warszawie. ", "Roman Polański", "2002", Gatunki.Biograficzny);
            Film f15 = new Film("Incepcja", "Czasy, gdy technologia pozwala na wchodzenie w świat snów. Złodziej Cobb ma za zadanie wszczepić myśl do śpiącego umysłu.", "Christopher Nolan", "2010", Gatunki.Thriller);

            ListaFilmowDostepnych l1 = new ListaFilmowDostepnych("Lista Filmow");
            l1.Dodaj(f1);
            l1.Dodaj(f2);
            l1.Dodaj(f3);
            l1.Dodaj(f4);
            l1.Dodaj(f5);
            l1.Dodaj(f6);
            l1.Dodaj(f7);
            l1.Dodaj(f8);
            l1.Dodaj(f9);
            l1.Dodaj(f10);
            l1.Dodaj(f11);
            l1.Dodaj(f12);
            l1.Dodaj(f13);
            l1.Dodaj(f14);
            l1.Dodaj(f15);

            Klient k1 = new Klient("Ola", "Bas", "265148759", "klaudia.djiw@dao.pl", "lala", "bec");
            Klient k2 = new Klient("Ala", "Las", "265178759", "klsjsudia.djiw@dao.pl", "lala", "bec");
            l1.Wypozyczenie(k1, f1);
            l1.Wypozyczenie(k2, f2);

            SystemKont ko1 = new SystemKont();
            ko1.Dodaj(k1);
            ko1.Dodaj(k2);

            /*SystemKont.ZapiszXML("SystemKont.xml", ko1);
            SystemKont sk1 = new SystemKont();
            sk1 = (SystemKont)SystemKont.OdczytajXML("SystemKont.xml");
            Console.WriteLine(sk1);

            ListaFilmowDostepnych.ZapiszXML("ListaFilmowDostepnych.xml", l1);*/

            /*List<Film> nowaLista = new List<Film>();
            nowaLista = l1.SzukanieGatunkow(l1.ListaFilmow, Gatunki.Dramat);
            foreach (Film f in nowaLista)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("Wyswietlone");*/
            //l1.Przedluz(f1);
            //Console.WriteLine(f1);
            Console.ReadKey();

        }
    }
}
