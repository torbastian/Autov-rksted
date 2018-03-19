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
            {
                //Switch som sender en ud til de forskellige menuer ud fra valgte tal.
                Console.WriteLine("Du er nu i Hoved-Menuen");
                int.TryParse(Console.ReadLine(), out int valg);
                Console.WriteLine("\nIndtast 1 for at gå ind i Kunde-Menu\nIndtast 2 for at gå ind i Bil-Menu\nIndtast 3 for at gå ind i Værksteds-Menu");
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
                        Console.Clear();
                        Menu();
                        break;
                }
                Console.Clear();
                Console.ReadKey();
            }
        }

        //Denne metode er lavet til håndtering af kunder
        static public void Kunder()
        {
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            int kunder = 0;
            Console.WriteLine("Du har valgt Kunder");
            Console.WriteLine("\nIndtast 1 for at oprette en Kunde\nIndtast 2 for at Updatere oplysninger på Kunde\nIndtast 3 for at slette en Kunde\nIndtast 4 for at vise oplysninger af Kunde\nIndtast 5 for vise alle Kunder");
            kunder = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Du har valgt Kunder");
            switch (kunder)
            {
                case 1:
                    Console.WriteLine("\nHer opretter man en ny Kunde");
                    lag.CreateKunde(); //Bruger metoden Createkunde fra Klassen Datalag 
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 2:
                    Console.WriteLine("\nHer kan du skifte dine kunde oplysninger");
                    lag.UpdateKunde(); //Bruger metoden UpdateKunde fra Klassen Datalag 
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man Slette en kunde");
                    lag.DeleteKunde(); //Bruger metoden DeleteKunde fra Klassen Datalag
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 4:
                    Console.WriteLine("\nHer vises Kundeoversigt på individuel Kunde");
                    lag.ShowKunde(); //Bruger metoden ShowKunde fra Klassen Datalag
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;
                case 5:
                    Console.WriteLine("\nHer vises Kundeoversigt på alle Kunder");
                    lag.ShowKundeAll();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;
                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }


        static public void Biler()
        {
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();
            int biler = 0;
            Console.WriteLine("Du har valgt Biler");
            Console.WriteLine("\nIndtast 1 for at oprette en Bil\nIndtast 2 for at Updatere oplysninger på Bil\nIndtast 3 for at slette en Bil\nIndtast 4 for at vise oplysninger af bil\nIndtast 5 for vise alle Biler");
            biler = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Du har valgt Biler");
            switch (biler)
            {
                case 1:
                    Console.WriteLine("\nHer opretter du din bil");
                    lag.CreateBil();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 2:
                    Console.WriteLine("\nHer updatere du din Bils oplysninger");
                    lag.UpdateBil();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 3:
                    Console.WriteLine("\nHer kan man slette en Bil");
                    lag.DeleteBil();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 4:
                    Console.WriteLine("\nHer kan du se oplysninger på valgte Bil");
                    lag.ShowBil();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 5:
                    Console.WriteLine("\nHer vises alle Bilers oplysninger");
                    lag.ShowBilAll();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                default:
                    Console.WriteLine("\nDu har indtastet tegn uden for valgte tal!");
                    Console.WriteLine("Tryk på tast for at gå tilbage til HovedMenu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        static public void Vaerksted()
        {
            //Gør at vi kan hente data og bruge metoderne i Klassen Datalag
            Datalag lag = new Datalag();

            int vaerksted = 0;
            Console.WriteLine("Du har valgt Værksted");
            switch (vaerksted)
            {
                case 1:
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine();
                    break;
                default:
                    Menu();
                    break;
            }
        }
    }
}
