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
                                "Indtast 3 for at gå ind i Værksteds-Menu\n");

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
                    Console.WriteLine("\nDu har indtastet et ugyldigt tegn udenfor valgte tal!");
                    break;
            }

            Console.WriteLine("Tryk på tast for at gå tilbage");
            Console.ReadKey();
            Menu();
        }

        //Denne metode er lavet til håndtering af kunder
        static void Kunder()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            Console.WriteLine("Du har valgt Kunder");
            Console.WriteLine("\nIndtast 1 for at oprette en Kunde\n" +
                                "Indtast 2 for at opdatere oplysninger på Kunde\n" +
                                "Indtast 3 for at slette en Kunde\n" +
                                "Indtast 4 for at vise oplysninger på en bestemt Kunde\n" +
                                "Indtast 5 for vise alle Kunder\n" +
                                "Indtast 6 for at se Kundeoversigt sorteret efter eget valg\n" +
                                "Indtast 7 for at få vist hvilket Biler der høre til den valgte Kunde\n" +
                                "Indtast 8 for at se alle Kunder med deres Biler\n" +
                                "Indtast 9 for at gå tilbage til HovedMenu");

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
                    Console.WriteLine("\nHer kan man skifte en Kundes oplysninger");
                    lag.UpdateKunde(); //Bruger metoden UpdateKunde fra Klassen Datalag 
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man slette en Kunde");
                    lag.DeleteKunde(); //Bruger metoden DeleteKunde fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer vises Kundeoversigt på en individuel Kunde");
                    lag.ShowKunde(); //Bruger metoden ShowKunde fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder");
                    lag.ShowKundeAll(); //Bruger metoden ShowKundeAll fra Klassen Datalag
                    break;

                case 6:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder sorteret efter eget valg");
                    lag.ShowKundeOrder(); //Bruger metoden ShowKundeOrder fra Klassen Datalag
                    break;

                case 7:
                    Console.WriteLine("\nHer kan man vælge en Kunde og se hvilket Biler den har");
                    lag.InnerJoinKundeId(); //Bruger metoden InnerJoinKundeId fra Klassen Datalag
                    break;

                case 8:
                    Console.WriteLine("\nHer vise alle Kunder og hvilket Biler de ejer");
                    lag.InnerJoinAll(); //Bruger metoden InnerJoinAll fra Klassen Datalag
                    break;

                case 9:
                    Menu();
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
            Console.ReadKey();
            Kunder();
        }


        static void Biler()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            Console.WriteLine("Du har valgt Biler");
            Console.WriteLine("\nIndtast 1 for at oprette en Bil\n" +
                                "Indtast 2 for at opdatere oplysninger på en Bil\n" +
                                "Indtast 3 for at slette en Bil\n" +
                                "Indtast 4 for at se oplysninger på en bestemt Bil\n" +
                                "Indtast 5 for at se oplysninger på alle Biler\n" +
                                "Indtast 6 for at se Biloversigt sorteret efter eget valg\n" +
                                "Indtast 7 for at se hvilket Kunde der ejer valgte Bil\n" +
                                "Indtast 8 for at gå tilbage til HovedMenu");

            int.TryParse(Console.ReadLine(), out int biler);
            Console.Clear();
            Console.WriteLine("Du har valgt Biler");

            switch (biler)
            {
                case 1:
                    Console.WriteLine("\nHer opretter du en Bil");
                    lag.CreateBil(); //Bruger metoden CreateBil fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer opdatere du en Bils oplysninger");
                    lag.UpdateBil(); //Bruger metoden UpdateBil fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man slette en Bil");
                    lag.DeleteBil(); //Bruger metoden DeleteBil fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer kan du se oplysninger på en valgt Bil");
                    lag.ShowBil(); //Bruger metoden ShowBil fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger");
                    lag.ShowBilAll(); //Bruger metoden ShowBilAll fra Klassen Datalag
                    break;

                case 6:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger sorteret efter eget valg");
                    lag.ShowBilOrder(); //Bruger metoden ShowBilOrder fra Klassen Datalag
                    break;

                case 7:
                    Console.WriteLine("\nHer vises hvilket Kunde der er ejer af den valgte Bil");
                    lag.InnerJoinRegNr(); //Bruger metoden InnerJoinRegNr fra Klassen Datalag
                    break;

                case 8:
                    Menu();
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
            Console.ReadKey();
            Biler();
        }

        static void Vaerksted()
        {
            Console.Clear();
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();

            Console.WriteLine("Du har valgt Værkstedsophold");
            Console.WriteLine("\nIndtast 1 for at oprette et Værkstedsophold\n" +
                                "Indtast 2 for at slette et Værkstedsophold\n" +
                                "Indtast 3 for at updatere et Værkstedsophold\n" +
                                "Indtast 4 for at vise oplysninger på et bestemt Værkstedsophold\n" +
                                "Indtast 5 for vise oplysninger på alle Værkstedsophold\n" +
                                "Indtast 6 for at få vist hvilket Biler der hører til en valgt Kunde\n" +
                                "Indtast 7 for at se hvilket Kunde der ejer en valgt Bil\n" +
                                "Indtast 8 for at se alle Kunder med deres Biler\n" +
                                "Indtast 9 for at gå tilbage til HovedMenu");

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
                    Console.WriteLine("\nHer updatere man en Bils Værkstedsophold");
                    lag.UpdateAutoRecord();
                    break;

                case 4:
                    Console.WriteLine("\nHer kan man se et bestemt Værstedsophold");
                    lag.ShowAutoRecord(); //Bruger metoden ShowAutoRecord fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer kan man se alle Værkstedsophold");
                    lag.ShowAutoRecordAll(); //Bruger metoden ShowAutoRecordAll fra Klassen Datalag
                    break;

                case 6:
                    Console.WriteLine("\nHer kan man vælge en Kunde og se hvilket Biler den har");
                    lag.InnerJoinKundeId(); //Bruger metoden InnerJoinKundeId fra Klassen Datalag
                    break;

                case 7:
                    Console.WriteLine("\nHer vises hvilket Kunde der er ejer af den valgte Bil");
                    lag.InnerJoinRegNr(); //Bruger metoden InnerJoinRegNr fra Klassen Datalag
                    break;

                case 8:
                    Console.WriteLine("\nHer vises alle Kunder og hvilket Biler de ejer");
                    lag.InnerJoinAll(); //Bruger metoden InnerJoinAll fra Klassen Datalag
                    break;

                case 9:
                    Menu();
                    break;

                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Værksteds-Menu");
            Console.ReadKey();
            Vaerksted();
        }
    }
}
