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
        public static Datalag lag = new Datalag();
        public static Menu menu = new Menu();

        public static MenuItem[] HovedMenu = new MenuItem[]
        {   
            new MenuItem("Kunde Menu"),
            new MenuItem("Bil Menu"),
            new MenuItem("Værksteds Menu")
        };

        public static MenuItem[] KundeMenu = new MenuItem[]
        {   
            new MenuItem("Opret kunde"),
            new MenuItem("Vis oplysninger på en bestemt Kunde"),
            new MenuItem("Vis Alle Kunder"),
            new MenuItem("Vis Sorteret kunder"),
            new MenuItem("Vis Alle Kunder og deres biler"),
            new MenuItem("Opdater Kunde"),
            new MenuItem("Slet kunde"),
            new MenuItem("Tilbage til HovedMenu")
        };

        public static MenuItem[] BilMenu = new MenuItem[]
        {
            new MenuItem("Opret bil"),
            new MenuItem("Vis oplysninger på en bil"),
            new MenuItem("Vis Alle biler"),
            new MenuItem("Vis Sorteret biler"),
            new MenuItem("Opdater bil"),
            new MenuItem("Slet bil"),
            new MenuItem("Tilbage til HovedMenu")
        };

        public static MenuItem[] VaerkstedsMenu = new MenuItem[]
        {
            new MenuItem("Opret et Værkstedsophold"),
            new MenuItem("Vis oplysninger på et Bestemt Værkstedsophold"),
            new MenuItem("Vis oplysninger på alle Værkstedsophold"),
            new MenuItem("Opdater et Værkstedsophold"),
            new MenuItem("Slet et Værkstedsophold"),
            new MenuItem("Tilbage til HovedMenu")
        };

        //opretter og sender en ud til metoden Menu
        static void Main(string[] args)
        {
            MainMenu();
        }

        //Dette er metoden menu den består af en switch og returnere ingenting
        static void MainMenu()
        {
            Console.Clear();

            switch (menu.MenuSelector(HovedMenu, "Hoved Menu"))
            {
                case 0:
                    Kunder();
                    break;

                case 1:
                    Biler();
                    break;

                case 2:
                    Vaerksted();
                    break;

                default:
                    Console.WriteLine("Fejl! du er ude for menuen");
                    break;
            }

            Console.WriteLine("Tryk på tast for at gå tilbage");
            Console.ReadKey();
            MainMenu();
        }

        //Denne metode er lavet til håndtering af kunder
        static void Kunder()
        {
            Console.Clear();

            switch (menu.MenuSelector(KundeMenu, "Kunde Menu"))
            {
                case 0:
                    Console.WriteLine("\nHer opretter man en ny Kunde");
                    lag.CreateKunde(); //Bruger metoden Createkunde fra Klassen Datalag 
                    break;

                case 1:
                    Console.WriteLine("\nHer vises Kundeoversigt på en individuel Kunde");
                    lag.ShowKunde(); //Bruger metoden ShowKunde fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder");
                    lag.ShowKundeAll(); //Bruger metoden ShowKundeAll fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder sorteret efter eget valg");
                    lag.ShowKundeOrder(); //Bruger metoden ShowKundeOrder fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer vise alle Kunder og hvilket Biler de ejer");
                    lag.InnerJoinAll(); //Bruger metoden InnerJoinAll fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer kan man skifte en Kundes oplysninger");
                    lag.UpdateKunde(); //Bruger metoden UpdateKunde fra Klassen Datalag 
                    break;

                case 6:
                    Console.WriteLine("\nHer kan man slette en Kunde");
                    lag.DeleteKunde(); //Bruger metoden DeleteKunde fra Klassen Datalag
                    break;

                case 7:
                    MainMenu();
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
            
            switch (menu.MenuSelector(BilMenu, "Bil Menu"))
            {
                case 0:
                    Console.WriteLine("\nHer opretter du en Bil");
                    lag.CreateBil(); //Bruger metoden CreateBil fra Klassen Datalag
                    break;

                case 1:
                    Console.WriteLine("\nHer kan du se oplysninger på en valgt Bil");
                    lag.ShowBil(); //Bruger metoden ShowBil fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger");
                    lag.ShowBilAll(); //Bruger metoden ShowBilAll fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger sorteret efter eget valg");
                    lag.ShowBilOrder(); //Bruger metoden ShowBilOrder fra Klassen Datalag
                    break;

                case 4:
                    Console.WriteLine("\nHer opdatere du en Bils oplysninger");
                    lag.UpdateBil(); //Bruger metoden UpdateBil fra Klassen Datalag
                    break;

                case 5:
                    Console.WriteLine("\nHer kan man slette en Bil");
                    lag.DeleteBil(); //Bruger metoden DeleteBil fra Klassen Datalag
                    break;

                case 6:
                    MainMenu();
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

            switch (menu.MenuSelector(VaerkstedsMenu, "Værkstedsophold"))
            {
                case 0:
                    Console.WriteLine("\nHer laver man et nyt Værkstedsophold");
                    lag.NewAutoRecord(); //Bruger metoden NewAutoRecord fra Klassen Datalag
                    break;

                case 1:
                    Console.WriteLine("\nHer kan man se et bestemt Værstedsophold");
                    lag.ShowAutoRecord(); //Bruger metoden ShowAutoRecord fra Klassen Datalag
                    break;

                case 2:
                    Console.WriteLine("\nHer kan man se alle Værkstedsophold");
                    lag.ShowAutoRecordAll(); //Bruger metoden ShowAutoRecordAll fra Klassen Datalag
                    break;

                case 3:
                    Console.WriteLine("\nHer opdatere man en Bils Værkstedsophold");
                    lag.DeliverGetAutoRecord();
                    break;

                case 4:
                    Console.WriteLine("\nHer sletter man et Værkstedsophold");
                    lag.DeleteAutoRecord(); //Bruger metoden DeleteAutoRecord fra Klassen Datalag
                    break;

                case 5:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Fejl Ude for menu!");
                    break;
            }

            Console.WriteLine("\nTryk på tast for at gå tilbage til Værksteds-Menu");
            Console.ReadKey();
            Vaerksted();
        }
    }
}

