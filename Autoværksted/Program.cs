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

        public void Kunder(int kunder = 0)
        {
            Console.WriteLine("Du har valgt Kunder");
            kunder = Convert.ToInt16(Console.ReadLine());
            switch (kunder)
            {
                case 1:
                    Console.WriteLine("Opretter ny Kunde");

                    break;
                case 2:
                    Console.WriteLine("Her kan du skifte dine kunde oplysninger");
                    Console.Write("Indtast dit Kunde id: ");

                    break;
                case 3:
                    Console.WriteLine("Sletter kunde");
                    Console.WriteLine("\nIndtast kunde ud fra Kundens id");
                    break;
                case 4:
                    Console.WriteLine("Kundeoversigt");
                    break;
                case 5:
                    Console.WriteLine("Alle Kunder");
                    lag.ShowKundeAll();
                    break;
                default:
                    break;
            }
        }


        public void Biler(int biler)
        {
            Console.WriteLine("Du har valgt Biler");
            switch (biler)
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
                    break;
            }
        }

        public void Vaerksted(int vaerksted)
        {
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
                    break;
            }
        }


        static void Main(string[] args)
        {
            {
                Datalag lag = new Datalag();





                //Kunde k4 = new Kunde();
                //k4.Fornavn = "Test";
                //k4.Efternavn = "Tester";
                //k4.Adresse = "Testvej 47";
                //k4.Tlf = "12345678";
                //Console.WriteLine(k4.Fornavn + k4.Efternavn + k4.Adresse + k4.Tlf);
                //Datalag lag = new Datalag();
                //lag.CreateKunde(k1);

                //Bil b1 = new Bil();

                //b1.RegNR = "xx12345";
                //b1.Maerke = "Mecedes";
                //b1.Model = "Dennis";
                //b1.Km = 123451;
                //b1.Aargang = 2010;
                //b1.KundeID = 2319;

                //lag.opretBil(b1);
                //Bil b2 = lag.hentBil("xx12345");
                //Console.WriteLine(b2.Model);




                Console.ReadKey();
            }
        }
    }
}
