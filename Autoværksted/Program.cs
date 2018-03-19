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
                Datalag lag = new Datalag();
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
                        Menu();
                        break;
                }

                Console.ReadKey();
            }
        }

        static public void Kunder()
        {
            Datalag lag = new Datalag();
            int kunder = 0;
            int kundeid = 0;
            Console.WriteLine("Du har valgt Kunder");
            kunder = Convert.ToInt16(Console.ReadLine());
            switch (kunder)
            {
                case 1:
                    Console.WriteLine("Opretter ny Kunde");
                    lag.CreateKunde();
                    Console.WriteLine("\nGår tilbage til Kunde-Menu");
                    Console.Clear();
                    Kunder();
                    break;

                case 2:
                    Console.WriteLine("Her kan du skifte dine kunde oplysninger");
                    Console.Write("Indtast dit Kunde id: ");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.UpdateKunde(kundeid);
                    Console.WriteLine("\nGår tilbage til Kunde-Menu");
                    Console.Clear();
                    Kunder();
                    break;

                case 3:
                    Console.WriteLine("Sletter kunde");
                    Console.WriteLine("\nIndtast kunde ud fra Kundens id");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.DeleteKunde(kundeid);
                    Console.WriteLine("\nGår tilbage til Kunde-Menu");
                    Console.Clear();
                    Kunder();
                    break;

                case 4:
                    Console.WriteLine("Kundeoversigt");
                    Console.WriteLine("\nIndtast kundes Id");
                    kundeid = Convert.ToInt16(Console.ReadLine());
                    lag.ShowKunde(kundeid);
                    Console.WriteLine("\nGår tilbage til Kunde-Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Kunder();
                    break;
                case 5:
                    Console.WriteLine("Alle Kunder");
                    lag.ShowKundeAll();
                    Console.ReadKey();
                    Console.WriteLine("\nGår tilbage til Kunde-Menu");
                    Console.Clear();
                    Kunder();
                    break;
                default:
                    Console.WriteLine("\nGår tilbage til Hoved-Menu");
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
            Console.WriteLine("\nIndtast 1 for at oprette en Bil\nIndtast 2 for at Updatere oplysninger på Bil\nIndtast 3 for at slette en Bil\nIndtast 4 for at vise oplysninger af bil\nIndtast 5 for vise alle  Biler");
            biler = Convert.ToInt16(Console.ReadLine());

            switch (biler)
            {
                case 1:
                    Console.WriteLine("Her opretter du din bil");
                    lag.CreateBil();
                    Console.WriteLine("\nGår tilbage til Bil-Menu");
                    Biler();
                    break;
                case 2:
                    Console.WriteLine("Her updatere du din Bils oplysninger");
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.UpdateBil(regnr);
                    Console.WriteLine("\nGår tilbage til Bil-Menu");
                    Biler();
                    break;
                case 3:
                    Console.WriteLine("Sletter Bil");
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.DeleteBil(regnr);
                    Console.WriteLine("\nGår tilbage til Bil-Menu");
                    Biler();
                    break;
                case 4:
                    Console.WriteLine("Her kan du se oplysninger på valgte Bil");
                    Console.Write("Indtast Bilens RegNr: ");
                    regnr = Console.ReadLine();
                    lag.ShowBil(regnr);
                    Console.WriteLine("\nGår tilbage til Bil-Menu");
                    Biler();
                    break;
                case 5:
                    Console.WriteLine("Her vises alle Bilers oplysninger");
                    lag.ShowBilAll();
                    Console.WriteLine("\nGår tilbage til Bil-Menu");
                    Biler();
                    break;
                default:
                    Console.WriteLine("\nGår tilbage til Hoved-Menu");
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
