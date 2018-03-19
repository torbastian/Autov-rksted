using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Datalag
    {
        //Kunder
        public void CreateKunde()
        {
            Kunde kunde = new Kunde();
            Console.WriteLine("Indtast information for kunde");

            Console.Write("Fornavn: ");
            kunde.Fornavn = Console.ReadLine().Trim();

            Console.Write("\nEfternavn: ");
            kunde.Efternavn = Console.ReadLine().Trim();

            Console.Write("\nAdresse: ");
            kunde.Adresse = Console.ReadLine();

            Console.Write("\nTlf nr: ");
            kunde.Tlf = Console.ReadLine().Trim();

            //Hvis variabler ikke følger regler, skriv fejl
            if (kunde.IsFilled())
            {
                //Lav en ny SQL kommando string ud fra variabler
                string sqlcmd = string.Format("insert into Kunder (fornavn, efternavn, adresse, tlf, oprettelsesdato) values ('{0}', '{1}', '{2}', '{3}', GETDATE())",
                                              kunde.Fornavn, kunde.Efternavn, kunde.Adresse, kunde.Tlf);
                //Kald på SQL.Create til at oprette kunden i databasen
                SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");
        }

        public void ShowKunde(int id)
        { //Test
            //Hvis id > 0, vis kunde ud fra id
            if (id > 0)
            {
                string sqlcmd = string.Format("select * from Kunder where id={0}", id);

                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void ShowKundeAll()
        {
            //Vis alle kunder
            string sqlcmd = "select * from Kunder";
            SQL.Read(sqlcmd);
        }

        public void ShowKundeOrder()
        {

            Console.WriteLine("I hvilken ordre?\n" +
                              "Efternavn\n" +
                              "Fornavn\n" +
                              "ID\n" +
                              "Adresse\n" +
                              "Oprettelses Dato (Dato)");

            string parameter = string.Empty;
            string read = Console.ReadLine().ToLower().Trim();

            switch (read)
            {
                case "efternavn":
                    parameter = read;
                    break;

                case "fornavn":
                    parameter = read;
                    break;

                case "id":
                    parameter = read;
                    break;

                case "adresse":
                    parameter = read;
                    break;

                case "dato":
                    parameter = "oprettelsesdato";
                    break;

                case "oprettelsesdato":
                    parameter = read;
                    break;

                default:
                    Console.WriteLine("Ukendt input");
                    ShowKundeOrder();
                    break;
            }

            string order = "asc";

            read = string.Empty;

            Console.WriteLine("Ascending (asc) eller Descending (dec)");

            read = Console.ReadLine().ToLower();

            if (read == "asc" || read == "ascending")
                order = "asc";
            else if (read == "dec" || read == "descending")
                order = "dec";

            string sqlcmd = string.Format("select * from Kunder Order by {0} {1}", parameter, order);
            SQL.Read(sqlcmd);
        }

        public void DeleteKunde(int id)
        {
            //Hvis id > 0, slet kunde ud fra id
            if (id > 0)
            {
                string sqlcmd = string.Format("delete from Kunder where id={0}", id);

                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void UpdateKunde(int id)
        {
            //Hvis id < 0, Spørg hvad man vil ændre
            if (id < 0)
            {
                ShowKunde(id);
                Console.WriteLine("Hvad vil du ændre? - Indtast de følgende\n" +
                                  "Fornavn\n" +
                                  "Efternavn\n" +
                                  "Adresse\n" +
                                  "Telefon\n");

                string[] valgt = Console.ReadLine().Split();

                Kunde kunde = new Kunde();

                foreach (string v in valgt)
                {
                    switch (v.ToLower())
                    {
                        case "fornavn":
                            Console.WriteLine("Indtast nyt fornavn");
                            kunde.Fornavn = Console.ReadLine().Trim();
                            break;

                        case "efternavn":
                            Console.WriteLine("Indtast nyt efternavn");
                            kunde.Efternavn = Console.ReadLine().Trim();
                            break;

                        case "adresse":
                            Console.WriteLine("Indtast ny adresse");
                            kunde.Adresse = Console.ReadLine().Trim();
                            break;

                        case "telefon":
                            Console.WriteLine("Indtast nyt Telefon nr");
                            kunde.Tlf = Console.ReadLine().Trim();
                            break;

                        case "tlf":
                            Console.WriteLine("Indtast nyt Telefon nr");
                            kunde.Tlf = Console.ReadLine().Trim();
                            break;

                        default:
                            break;
                    }
                }

                //Lav en liste over hvad der skal opdateres
                List<string> ToUpdate = new List<string>();

                if (!string.IsNullOrEmpty(kunde.Fornavn))
                    ToUpdate.Add(string.Format("fornavn = '{0}'", kunde.Fornavn));

                if (!string.IsNullOrEmpty(kunde.Efternavn))
                    ToUpdate.Add(string.Format("efternavn = '{0}", kunde.Efternavn));

                if (!string.IsNullOrEmpty(kunde.Adresse))
                    ToUpdate.Add(string.Format("adresse = '{0}'", kunde.Adresse));

                if (!string.IsNullOrEmpty(kunde.Tlf))
                    ToUpdate.Add(string.Format("tlf = '{0}'", kunde.Tlf));

                string sqlcmd = "Update Kunder Set ";

                //for hver ting der skal opdateres, tilføj parametre, og hvis det ikke er den sidste parametre tilføj ", "
                for (int i = 0; i < ToUpdate.Count; i++)
                {
                    sqlcmd += ToUpdate[i];

                    if (i < (ToUpdate.Count - 1))
                        sqlcmd += ", ";
                }

                //Gør kommandoen færdig og kør den
                sqlcmd += " where id = " + id.ToString();

                SQL.Update(sqlcmd);
            }
        }

        //Biler
        public void CreateBil()
        {
            Bil bil = new Bil();
            Console.WriteLine("Indtast information for Bil");

            Console.Write("Reg nr: ");
            bil.RegNR = Console.ReadLine().Trim();

            Console.Write("\nMaerke: ");
            bil.Maerke = Console.ReadLine().Trim();

            Console.Write("\nModel: ");
            bil.Model = Console.ReadLine().Trim();

            Console.Write("\nBrændstof: ");
            bil.Braendstof = Console.ReadLine().Trim();

            Console.Write("\nAargang: ");
            int.TryParse(Console.ReadLine().Trim(), out int aargang);
            bil.Aargang = aargang;

            Console.Write("\nKm: ");
            int.TryParse(Console.ReadLine().Trim(), out int km);
            bil.Km = km;

            Console.Write("\nKml: ");
            float.TryParse(Console.ReadLine().Trim(), out float kml);
            bil.Kml = kml;

            Console.Write("\nKunde Id: ");
            int.TryParse(Console.ReadLine().Trim(), out int kid);
            bil.KundeID = kid;

            if(bil.IsFilled())
            {
                string sqlcmd = string.Format("insert into Biler values {0}, {1}, {2}, {3}, {4}, {5}, {6}, GETDATE()"
                                              , bil.RegNR, bil.KundeID, bil.Maerke, bil.Model, bil.Aargang, bil.Km, bil.Braendstof, bil.Kml);

                SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");

        }

        public void ShowBil(string regnr)
        {
            if (!string.IsNullOrEmpty(regnr))
            {
                string sqlcmd = string.Format("select * from Biler where reg_nr={0}", regnr);

                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void ShowBilAll()
        {
            string sqlcmd = "select * from Biler";

            SQL.Read(sqlcmd);
        }

        public void ShowBilOrder()
        {

            Console.WriteLine("I hvilken ordre?\n" +
                              "kunde id (id)\n" +
                              "mærke (maerke)\n" +
                              "model\n" +
                              "Årgang (aargang)\n" +
                              "KM\n" +
                              "Oprettelses Dato (Dato)");

            string parameter = string.Empty;
            string read = Console.ReadLine().ToLower().Trim();

            switch (read)
            {
                case "efternavn":
                    parameter = read;
                    break;

                case "fornavn":
                    parameter = read;
                    break;

                case "id":
                    parameter = read;
                    break;

                case "adresse":
                    parameter = read;
                    break;

                case "dato":
                    parameter = "oprettelsesdato";
                    break;

                case "oprettelsesdato":
                    parameter = read;
                    break;

                default:
                    Console.WriteLine("Ukendt input");
                    ShowKundeOrder();
                    break;
            }

            string order = "asc";

            read = string.Empty;

            Console.WriteLine("Ascending (asc) eller Descending (dec)");

            read = Console.ReadLine().ToLower();

            if (read == "asc" || read == "ascending")
                order = "asc";
            else if (read == "dec" || read == "descending")
                order = "dec";

            string sqlcmd = string.Format("select * from Biler Order by {0} {1}", parameter, order);
            SQL.Read(sqlcmd);
        }

        public void DeleteBil(string regnr)
        {
            if (!string.IsNullOrEmpty(regnr))
            {
                string sqlcmd = string.Format("delete from Biler where reg_nr={0}", regnr);

                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void UpdateBil(string regnr)
        {
            if (!string.IsNullOrEmpty(regnr))
            {
                ShowBil(regnr);
                Console.WriteLine("Hvad vil du ændre? - Indtast de følgende\n" +
                                  "Regnr\n" +
                                  "KundeId\n" +
                                  "Mærke\n" +
                                  "Model\n" +
                                  "Årgang\n" +
                                  "Km\n" +
                                  "Brændstof\n" +
                                  "Kml\n");

                string[] valgt = Console.ReadLine().Split();

                Bil bil = new Bil();

                foreach (string v in valgt)
                {
                    switch (v.ToLower())
                    {
                        case "regnr":
                            Console.WriteLine("Indtast nyt Regnr");
                            bil.RegNR = Console.ReadLine().Trim();
                            break;

                        case "kundeid":
                            Console.WriteLine("Indtast nyt Kunde ID");
                            bil.KundeID = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "mærke":
                            Console.WriteLine("Indtast nyt mærke");
                            bil.Maerke = Console.ReadLine().Trim();
                            break;

                        case "model":
                            Console.WriteLine("Indtast ny Model");
                            bil.Model = Console.ReadLine().Trim();
                            break;

                        case "årgang":
                            Console.WriteLine("Indtast ny årgang");
                            bil.Aargang = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "km":
                            Console.WriteLine("Indtast ny km");
                            bil.Km = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "brændstof":
                            Console.WriteLine("Indtast nyt Brændstof");
                            bil.Braendstof = Console.ReadLine();
                            break;

                        case "kml":
                            Console.WriteLine("Indtast ny kml");
                            float.TryParse(Console.ReadLine(), out float kml);
                            bil.Kml = kml;
                            break;
                        default:
                            break;
                    }
                }

                List<string> ToUpdate = new List<string>();

                if (!string.IsNullOrEmpty(bil.RegNR))
                    ToUpdate.Add(string.Format("reg_nr = '{0}'", bil.RegNR));

                if (bil.KundeID > 0)
                    ToUpdate.Add(string.Format("Kunde_id = '{0}", bil.KundeID));

                if (!string.IsNullOrEmpty(bil.Maerke))
                    ToUpdate.Add(string.Format("maerke = '{0}'", bil.Maerke));

                if (!string.IsNullOrEmpty(bil.Model))
                    ToUpdate.Add(string.Format("model = '{0}'", bil.Model));

                if (bil.Aargang > 1900)
                    ToUpdate.Add(string.Format("aargang = '{0}'", bil.Aargang));

                if (bil.Km >= 0)
                    ToUpdate.Add(string.Format("km = '{0}'", bil.Km));

                if (!string.IsNullOrEmpty(bil.Braendstof))
                    ToUpdate.Add(string.Format("braendstof = '{0}'", bil.Braendstof));

                if (bil.Kml > 0)
                    ToUpdate.Add(string.Format("kml = '{0}'", bil.Kml));

                string sqlcmd = "Update Biler Set ";

                for (int i = 0; i < ToUpdate.Count; i++)
                {
                    sqlcmd += ToUpdate[i];

                    if (i < (ToUpdate.Count - 1))
                        sqlcmd += ", ";
                }

                sqlcmd += " where reg_nr = " + regnr;

                SQL.Update(sqlcmd);
            }
        }

        //Innerjoin
        public void InnerJoin()
        {

        }

        //diverse
        public bool AreYouSure()
        {
            Console.WriteLine("Er du sikker? Y/N");
            if (Console.ReadLine().ToLower() == "y")
                return true;
            else
                return false;
        }
    }
}
