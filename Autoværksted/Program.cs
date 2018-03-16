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
            Datalag lag = new Datalag();

            Console.WriteLine("Dette program kan Dette program kan oprette, slette og updatere en Kunde database og en Bil database\nSamt beregne hvornår bilen har været/skal på værksted");
            
            int hvadvildu = 0, kunder = 0, biler = 0, vaerksted = 0;
            Console.WriteLine("\nTryk 1 for Kunder\nTryk 2 for Biler\nTryk 3 for Værksted");
            hvadvildu = Convert.ToInt16(Console.ReadLine());
            switch (hvadvildu)
            {
                case 1:
                    Console.WriteLine("Du har valgt Kunder");
                    kunder = Convert.ToInt16(Console.ReadLine());
                    switch(kunder)
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
                            lag.ShowKunde();
                            break;
                        case 5:
                            Console.WriteLine("Kundeoversigt");
                            //lag.ShowKundeAll();
                            break;
                        default:
                            break;
                    }


                    break;
                case 2:
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


                    break;
                case 3:
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



                    break;
                default:
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
