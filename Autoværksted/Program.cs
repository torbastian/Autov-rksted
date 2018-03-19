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

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            {
                Console.WriteLine("Du er nu i Hoved-Menuen");
                Datalag lag = new Datalag();
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
                        Menu();
                        break;
                }
                Console.Clear();
                Console.ReadKey();
            }
        }

        static public void Kunder()
        {
            Datalag lag = new Datalag();
            int kunder = 0;
            int kundeid = 0;
            Console.WriteLine("Du har valgt Kunder");
            Console.WriteLine("\nIndtast 1 for at oprette en Kunde\nIndtast 2 for at Updatere oplysninger på Kunde\nIndtast 3 for at slette en Kunde\nIndtast 4 for at vise oplysninger af Kunde\nIndtast 5 for vise alle Kunder");
            kunder = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Du har valgt Kunder");
            switch (kunder)
            {
                case 1:
                    Console.WriteLine("\nHer opretter man en ny Kunde");
                    lag.CreateKunde();
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 2:
                    Console.WriteLine("\nHer kan du skifte dine kunde oplysninger");
                    Console.Write("Indtast dit Kunde id: ");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.UpdateKunde(kundeid);
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 3:
                    Console.WriteLine("\nHer kan man Slette en kunde");
                    Console.WriteLine("\nIndtast kunde ud fra Kundens id");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.DeleteKunde(kundeid);
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;

                case 4:
                    Console.WriteLine("\nHer vises Kundeoversigt på individuel Kunde");
                    Console.WriteLine("\nIndtast kundes Id");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.ShowKunde(kundeid);
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
            Datalag lag = new Datalag();
            int biler = 0;
            string regnr = "";
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
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.UpdateBil(regnr);
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 3:
                    Console.WriteLine("\nHer kan man slette en Bil");
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.DeleteBil(regnr);
                    Console.WriteLine("\nTryk på tast for at gå tilbage til Bil-Menu");
                    Console.ReadKey();
                    Biler();
                    break;
                case 4:
                    Console.WriteLine("\nHer kan du se oplysninger på valgte Bil");
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.ShowBil(regnr);
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
