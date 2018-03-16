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






            int updatekunde = 0;
            Console.WriteLine("Her kan du skifte dine kunde oplysninger");
            Console.WriteLine("Indtast dit Kunde id");

            Console.WriteLine("\nTryk 1 for Fornavn, Tryk 2 for Efternavn, Tryk 3 for Adresse, Tryk 4 for Tlf Nr, Tryk 5 for at Anulere");
            updatekunde = Convert.ToInt16(Console.ReadKey());

            switch (updatekunde)
            {
                case 1:
                    Console.WriteLine("Fornavn vil blive skiftet!");
                    Console.Write("Hvad er dit nye Fornavn: ");
                    break;
                case 2:
                    Console.WriteLine("Efternavn vil blive skiftet!");
                    Console.Write("Hvad er dit nye Efternavn: ");
                    break;
                case 3:
                    Console.WriteLine("Adresse vil blive skiftet!");
                    Console.Write("Hvad er din nye Adresse: ");
                    break;
                case 4:
                    Console.WriteLine("Telefon Nr. vil blive skiftet!");
                    Console.Write("Hvad er dit nye tlf Nr: ");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


            //Kunde k4 = new Kunde();
            //k4.Fornavn = "Test";
            //k4.Efternavn = "Tester";
            //k4.Adresse = "Testvej 47";
            //k4.Tlf = "12345678";
            //Console.WriteLine(k4.Fornavn + k4.Efternavn + k4.Adresse + k4.Tlf);
            //Datalag lag = new Datalag();
            //lag.CreateKunde(k1);
            //Datalag lag = new Datalag();
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

            //Console.ReadKey();
        }
    }
}
