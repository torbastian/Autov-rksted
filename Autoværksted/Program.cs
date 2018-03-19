using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Autoværksted
{
    class Program
    {
        //opretter og sender en ud til metoden Menu
        static void Main(string[] args)
        {
            Menu();
        }

        //Dette er metoden menu den består af en switch og returnere ingenting
        static void Menu()
        {
            Console.Clear();
            //Switch som sender en ud til de forskellige menuer ud fra valgte tal.
            Console.WriteLine("Du er nu i Hoved-Menuen");
            Console.WriteLine("\nIndtast 1 for at gå ind i Kunde-Menu\n" +
                                "Indtast 2 for at gå ind i Bil-Menu\n" +
                                "Indtast 3 for at gå ind i Værksteds-Menu");

            int.TryParse(Console.ReadLine(), out int valg);

            switch (valg)
            {
                case 1:
                    Kunder();
                    break;

                case 2:
                    Biler();
                    break;

                case 3:
                    Vaerksted();
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet et ugyldigt tegn udefor valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Menu();
                    break;
            }
            Console.Clear();
            Console.ReadKey();
        }

        //Denne metode er lavet til håndtering af kunder
        static public void Kunder()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            Console.WriteLine("Du har valgt Kunder");
            Console.WriteLine("\nIndtast 1 for at oprette en Kunde\n" +
                                "Indtast 2 for at opdatere oplysninger på Kunde\n" +
                                "Indtast 3 for at slette en Kunde\n" +
                                "Indtast 4 for at vise oplysninger af en bestemt Kunde\n" +
                                "Indtast 5 for vise alle Kunder");

            int.TryParse(Console.ReadLine(), out int kunder);

            Console.Clear();
            Console.WriteLine("Du har valgt Kunder");

            switch (kunder)
            {
                case 1:
                    Console.WriteLine("\nHer opretter man en ny Kunde");
                    lag.CreateKunde(); //Bruger metoden Createkunde fra Klassen Datalag 
                    break;

                case 2:
                    Console.WriteLine("\nHer kan du skifte dine kunde oplysninger");
                    lag.UpdateKunde(); //Bruger metoden UpdateKunde fra Klassen Datalag 
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man slette en kunde");
                    lag.DeleteKunde(); //Bruger metoden DeleteKunde fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer vises Kundeoversigt på individuel Kunde");
                    lag.ShowKunde(); //Bruger metoden ShowKunde fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder");
                    lag.ShowKundeAll(); //Bruger metoden ShowKundeAll fra Klassen Datalag
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Menu();
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
            Console.ReadKey();
            Kunder();
        }


        static public void Biler()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            Console.WriteLine("Du har valgt Biler");
            Console.WriteLine("\nIndtast 1 for at oprette en Bil\n" +
                                "Indtast 2 for at opdatere oplysninger på Bil\n" +
                                "Indtast 3 for at slette en Bil\n" +
                                "Indtast 4 for at vise oplysninger på en bestemt Bil\n" +
                                "Indtast 5 for vise oplysninger på alle Biler");

            int.TryParse(Console.ReadLine(), out int biler);
            Console.Clear();
            Console.WriteLine("Du har valgt Biler");

            switch (biler)
            {
                case 1:
                    Console.WriteLine("\nHer opretter du din bil");
                    lag.CreateBil(); //Bruger metoden CreateBil fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer opdatere du din Bils oplysninger");
                    lag.UpdateBil(); //Bruger metoden UpdateBil fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man slette en Bil");
                    lag.DeleteBil(); //Bruger metoden DeleteBil fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer kan du se oplysninger på valgte Bil");
                    lag.ShowBil(); //Bruger metoden ShowBil fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger");
                    lag.ShowBilAll(); //Bruger metoden ShowBilAll fra Klassen Datalag
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Menu();
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
            Console.ReadKey();
            Biler();
        }

        static public void Vaerksted()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();

            Console.WriteLine("Du har valgt Værkstedsophold");
            Console.WriteLine("\nIndtast 1 for at oprette et Værkstedsophold\n" +
                                "Indtast 2 for at slette et Værkstedsophold\n" +
                                "Indtast 3 for at vise oplysninger på et bestemt Værkstedsophold\n" +
                                "Indtast 4 for vise oplysninger på alle Værkstedsophold");

            int.TryParse(Console.ReadLine(), out int vaerksted);

            Console.Clear();
            Console.WriteLine("Du har valgt Værkstedsophold");

            switch (vaerksted)
            {
                case 1:
                    Console.WriteLine("\nHer laver man et nyt Værkstedsophold");
                    lag.NewAutoRecord(); //Bruger metoden NewAutoRecord fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer sletter man et Værkstedsophold");
                    lag.DeleteAutoRecord(); //Bruger metoden DeleteAutoRecord fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man se et bestemt Værstedsophold");
                    lag.ShowAutoRecord(); //Bruger metoden ShowAutoRecord fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer kan man se alle Værkstedsophold");
                    lag.ShowAutoRecordAll(); //Bruger metoden ShowAutoRecordAll fra Klassen Datalag
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Menu();
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Værksteds-Menu");
            Console.ReadKey();
            Vaerksted();
        }
    }
}
