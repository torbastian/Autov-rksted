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
            //Kunde k1 = new Kunde();
            //k1.Fornavn = "Test";
            //k1.Efternavn = "Tester";
            //k1.Adresse = "Testvej 47";
            //k1.Tlf = "12345678";

            Datalag lag = new Datalag();
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

            Console.ReadKey();
        }
    }
}
