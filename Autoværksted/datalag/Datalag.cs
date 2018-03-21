using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Autoværksted
{
    class Datalag
    {
        public Menu menu = new Menu();
        /// <summary>
        /// Kunder
        /// </summary>
        public void CreateKunde()
        {   //får fat i kunde info
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
                if (AreYouSure())
                    SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");
        }

        public void CreateKunde(Kunde kunde)
        {
            //Hvis variabler ikke følger regler, skriv fejl
            if (kunde.IsFilled())
            {
                //Lav en ny SQL kommando string ud fra variabler
                string sqlcmd = string.Format("insert into Kunder (fornavn, efternavn, adresse, tlf, oprettelsesdato) values ('{0}', '{1}', '{2}', '{3}', GETDATE())",
                                              kunde.Fornavn, kunde.Efternavn, kunde.Adresse, kunde.Tlf);
                //Kald på SQL.Create til at oprette kunden i databasen
                if (AreYouSure())
                    SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");
        }

        public void ShowKunde()
        {   //få fat i Id
            Console.Write("Indtast Kunde Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            //Hvis id > 0, vis kunde ud fra id
            if (id > 0)
            {
                Console.Clear();
                string sqlcmd = string.Format("select * from Kunder where id={0}", id);
                Console.WriteLine("Id, Fornavn, Efternavn, Adresse, Tlf, Oprettelsesdato");
                //Kald på sql laget for at læse
                SQL.Read(sqlcmd);

                sqlcmd = string.Format("select * from Biler where kunde_id={0}", id);
                Console.WriteLine("\nReg nr, Kunde Id, Mærke, Model, Årgang, Km, Brændstof, Kml, Oprettelsesdato");
                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void ShowKunde(int id)
        {   //Hvis id > 0, vis kunde ud fra id
            if (id > 0)
            {
                string sqlcmd = string.Format("select * from Kunder where id={0}", id);
                Console.WriteLine("Id, Fornavn, Efternavn, Adresse, Tlf, Oprettelsesdato");
                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void ShowKundeAll()
        {   //Vis alle kunder
            string sqlcmd = "select * from Kunder";
            Console.WriteLine("Id, Fornavn, Efternavn, Adresse, Tlf, Oprettelsesdato");
            SQL.Read(sqlcmd);
        }

        public void ShowKundeOrder()
        {   //Vis kunder i valgt rækkefølge
            Console.Clear();
            MenuItem[] Order = new MenuItem[]
            {
                new MenuItem("Efternavn"),
                new MenuItem("Fornavn"),
                new MenuItem("ID"),
                new MenuItem("Adresse"),
                new MenuItem("Oprettelses Dato"),
                new MenuItem("Tilbage")
            };

            string parameter = string.Empty;

            //Find et valid input ud fra brugerns input
            switch (menu.MenuSelector(Order, "Sorteret efter hvilket\n"))
            {
                case 0:
                    parameter = "efternavn";
                    break;

                case 1:
                    parameter = "fornavn";
                    break;

                case 2:
                    parameter = "id";
                    break;

                case 3:
                    parameter = "adresse";
                    break;

                case 4:
                    parameter = "oprettelsesdato";
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Ukendt input");
                    ShowKundeOrder();
                    break;
            }

            MenuItem[] AscDesc = new MenuItem[]
            {
                new MenuItem("Ascending"),
                new MenuItem("Descending")
            };

            string order = string.Empty;

            switch (menu.MenuSelector(AscDesc, "I hvilken rækkefølge\n"))
            {
                case 0:
                    order = "asc";
                    break;

                case 1:
                    order = "desc";
                    break;

                default:
                    break;
            }

            //Opret kommando og send den til sql laget
            string sqlcmd = string.Format("select * from Kunder Order by {0} {1}", parameter, order);
            Console.Clear();
            Console.WriteLine("Id, Fornavn, Efternavn, Adresse, Tlf, Oprettelsesdato");
            SQL.Read(sqlcmd);

    }

        public void DeleteKunde(int id)
        {
            //Hvis id > 0, slet kunde ud fra id
            if (id > 0)
            {
                string sqlcmd = string.Format("delete from Kunder where id= {0}", id);

                //Spørg om brugeren er sikker på sit input, hvis de er, kald på Sql.delete
                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void DeleteKunde()
        {
            ShowKundeAll();
            Console.Write("\nIndtast Kunde Id: ");
            int.TryParse(Console.ReadLine(), out int id);
            //Hvis id > 0, slet kunde ud fra id
            if (id > 0)
            {
                string sqlcmd = string.Format("delete from Kunder where id= {0}", id);

                //Hvis brugeren er sikker på sit input, hvis de er, kald på sql.delete
                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Ingen kunder har id på 0 eller lavere");
        }

        public void UpdateKunde()
        {
            Console.Clear();

            Console.WriteLine("\nIndtast kunde id: ");
            string kid = Console.ReadLine();

            int.TryParse(kid, out int id);

            //Hvis id < 0, Spørg hvad man vil ændre
            if (id > 0)
            {
                MenuItem[] Update = new MenuItem[]
                {
                    new MenuItem("Fornavn"),
                    new MenuItem("Efternavn"),
                    new MenuItem("Adresse"),
                    new MenuItem("Telefon"),
                    new MenuItem("Accepter"),
                    new MenuItem("Tilbage")
                };

                bool accept = false;
                List<string> choosen = new List<string>();

                while (!accept)
                {
                    switch (menu.MenuSelector(Update, "\nHvad vil du ændre?\n"))
                    {
                        case 0:
                            if (!choosen.Contains("Fornavn"))
                                choosen.Add("Fornavn");
                            else
                                choosen.Remove("Fornavn");
                            break;

                        case 1:
                            if (!choosen.Contains("Efternavn"))
                                choosen.Add("Efternavn");
                            else
                                choosen.Remove("Efternavn");
                            break;

                        case 2:
                            if (!choosen.Contains("Adresse"))
                                choosen.Add("Adresse");
                            else
                                choosen.Remove("Adresse");
                            break;

                        case 3:
                            if (!choosen.Contains("Telefon"))
                                choosen.Add("Telefon");
                            else
                                choosen.Remove("Telefon");
                            break;

                        case 4:
                            accept = true;
                            break;

                        case 5:
                            return;

                        default:
                            break;
                    }

                    Console.Write("Valgt: ");

                    foreach (string s in choosen)
                    {
                        Console.Write(s + ", ");
                    }
                }

                Kunde kunde = new Kunde();

                //Gå igennem alt i valgt og skriv data til en Kunde
                foreach (string c in choosen)
                {
                    switch (c.ToLower())
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

                        default:
                            Console.WriteLine("Ukendt Indput");
                            UpdateKunde();
                            break;
                    }
                }

                //Lav en liste over hvad der skal opdateres
                List<string> ToUpdate = new List<string>();

                //Hvis noget er ændret så sæt dem til ToUpdate listen
                if (!string.IsNullOrEmpty(kunde.Fornavn))
                    ToUpdate.Add(string.Format("fornavn = '{0}'", kunde.Fornavn));

                if (!string.IsNullOrEmpty(kunde.Efternavn))
                    ToUpdate.Add(string.Format("efternavn = '{0}'", kunde.Efternavn));

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

        /// <summary>
        /// Biler
        /// </summary>
        public void CreateBil()
        {   //Opret ny bil
            Bil bil = new Bil();
            Console.WriteLine("Indtast information for Bil");

            //Få bruger input
            Console.Write("Reg nr: ");
            bil.RegNR = Console.ReadLine().Trim().ToUpper();

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

            //Hvis data er fyldt ud, lav en ny bil i databasen
            if (bil.IsFilled())
            {
                string sqlcmd = string.Format("insert into Biler values ('{0}', {1}, '{2}', '{3}', {4}, {5}, '{6}', {7}, GETDATE())"
                                              , bil.RegNR, bil.KundeID, bil.Maerke, bil.Model, bil.Aargang, bil.Km, bil.Braendstof, bil.Kml);
                if (AreYouSure())
                    SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");
        }

        public void CreateBil(Bil bil)
        {   //Opret ny bil
            //Hvis data er fyldt ud, lav en ny bil i databasen
            if (bil.IsFilled())
            {
                string sqlcmd = string.Format("insert into Biler values ('{0}', {1}, '{2}', '{3}', {4}, {5}, '{6}', {7}, GETDATE())"
                                              , bil.RegNR, bil.KundeID, bil.Maerke, bil.Model, bil.Aargang, bil.Km, bil.Braendstof, bil.Kml);
                if (AreYouSure())
                    SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - I input");
        }

        public void ShowBil()
        {   //Spørg om reg nr, hvis den er valid, kør kommando
            Console.Write("Indtast reg nr: ");
            string regnr = Console.ReadLine();

            if (!string.IsNullOrEmpty(regnr))
            {
                Console.Clear();
                string sqlcmd = string.Format("select * from Biler where reg_nr= '{0}'", regnr);
                Console.WriteLine("Reg nr, Kunde Id, Mærke, Model, Årgang, Km, Brændstof, Kml, Oprettelsesdato");
                SQL.Read(sqlcmd);

                Console.WriteLine("\nId, Fornavn, Efternavn, Adresse, Tlf, Oprettelsesdato");
                sqlcmd = string.Format("select Kunder.* From Kunder Inner Join biler on Kunder.id = biler.kunde_id where reg_nr = '{0}'", regnr);
                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void ShowBil(string regnr)
        {   //Vis bil efter regnr
            if (!string.IsNullOrEmpty(regnr))
            {
                string sqlcmd = string.Format("select * from Biler where reg_nr= '{0}'", regnr);
                Console.WriteLine("Reg nr, Kunde Id, Mærke, Model, Årgang, Km, Brændstof, Kml, Oprettelsesdato");
                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void ShowBilAll()
        {   //Vis alle biler
            string sqlcmd = "select * from Biler";
            Console.WriteLine("Reg nr, Kunde Id, Mærke, Model, Årgang, Km, Brændstof, Kml, Oprettelsesdato");
            SQL.Read(sqlcmd);
        }

        public void ShowBilOrder()
        {   //Vis biler efter en bruger bestemt order
            Console.Clear();

            MenuItem[] Order = new MenuItem[]
            {
                new MenuItem("Reg nr"),
                new MenuItem("Kunde id"),
                new MenuItem("Mærke"),
                new MenuItem("Model"),
                new MenuItem("Årgang"),
                new MenuItem("Km"),
                new MenuItem("Kml"),
                new MenuItem("Brændstof"),
                new MenuItem("Oprettelses Dato"),
                new MenuItem("Tilbage")
            };

            string parameter = string.Empty;

            switch (menu.MenuSelector(Order, "Sorteret efter hvilket\n"))
            {
                case 0:
                    parameter = "reg_nr";
                    break;

                case 1:
                    parameter = "kunde_id";
                    break;

                case 2:
                    parameter = "maerke";
                    break;

                case 3:
                    parameter = "model";
                    break;

                case 4:
                    parameter = "aargang";
                    break;

                case 5:
                    parameter = "km";
                    break;

                case 6:
                    parameter = "kml";
                    break;

                case 7:
                    parameter = "braendstof";
                    break;

                case 8:
                    parameter = "oprettelsesdato";
                    break;

                case 9:
                    return;

                default:
                    Console.WriteLine("Ukendt input");
                    ShowBilOrder();
                    break;
            }

            string order = string.Empty;

            MenuItem[] AscDesc = new MenuItem[]
            {
                new MenuItem("Ascending"),
                new MenuItem("Descending")
            };

            switch (menu.MenuSelector(AscDesc, "I hvilken rækkefølge\n"))
            {
                case 0:
                    order = "asc";
                    break;

                case 1:
                    order = "desc";
                    break;

                default:
                    order = "asc";
                    break;
            }

            //Lav og kør kommando
            string sqlcmd = string.Format("select * from Biler Order by {0} {1}", parameter, order);
            Console.Clear();
            Console.WriteLine("Reg nr, Kunde Id, Mærke, Model, Årgang, Km, Brændstof, Kml, Oprettelsesdato");
            SQL.Read(sqlcmd);

        }

        public void DeleteBil(string regnr)
        {   //slet bil efter regnr
            if (!string.IsNullOrEmpty(regnr))
            {
                string sqlcmd = string.Format("delete from Biler where reg_nr={0}", regnr);

                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void DeleteBil()
        {   //Slet bil efter regnr input
            ShowBilAll();

            Console.Write("\nIndtast reg nr: ");
            string regnr = Console.ReadLine();

            if (!string.IsNullOrEmpty(regnr))
            {
                string sqlcmd = string.Format("delete from Biler where reg_nr={0}", regnr);

                if (AreYouSure())
                    SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl! - Tom regnr");
        }

        public void UpdateBil()
        {
            ShowBilAll();
            Console.Clear();
            //Opdater bil efter bruger input
            Console.Write("\nIndtast reg nr: ");
            string regnr = Console.ReadLine();

            if (!string.IsNullOrEmpty(regnr))
            {   //Find ud af hvad brugeren vil ændre
                ShowBil(regnr);

                MenuItem[] Update = new MenuItem[]
                {
                    new MenuItem("Reg nr"),
                    new MenuItem("Kunde Id"),
                    new MenuItem("Mærke"),
                    new MenuItem("Model"),
                    new MenuItem("Årgang"),
                    new MenuItem("Km"),
                    new MenuItem("Brændstof"),
                    new MenuItem("Kml"),
                    new MenuItem("Accepter"),
                    new MenuItem("Tilbage")
                };

                bool accept = false;
                List<string> choosen = new List<string>();

                while (!accept)
                {
                    switch (menu.MenuSelector(Update, "Hvad vil du ændre?\n"))
                    {
                        case 0:
                            if (!choosen.Contains("Reg_nr"))
                                choosen.Add("Reg_nr");
                            else
                                choosen.Remove("Reg_nr");
                            break;

                        case 1:
                            if (!choosen.Contains("Kunde_Id"))
                                choosen.Add("Kunde_Id");
                            else
                                choosen.Remove("Kunde_Id");
                            break;

                        case 2:
                            if (!choosen.Contains("Maerke"))
                                choosen.Add("Maerke");
                            else
                                choosen.Remove("Maerke");
                            break;

                        case 3:
                            if (!choosen.Contains("Model"))
                                choosen.Add("Model");
                            else
                                choosen.Remove("Model");
                            break;

                        case 4:
                            if (!choosen.Contains("Aargang"))
                                choosen.Add("Aargang");
                            else
                                choosen.Remove("Aargang");
                            break;

                        case 5:
                            if (!choosen.Contains("Km"))
                                choosen.Add("Km");
                            else
                                choosen.Remove("Km");
                            break;

                        case 6:
                            if (!choosen.Contains("Braendstof"))
                                choosen.Add("Braendstof");
                            else
                                choosen.Remove("Braendstof");
                            break;

                        case 7:
                            if (!choosen.Contains("Kml"))
                                choosen.Add("Kml");
                            else
                                choosen.Remove("Kml");
                            break;

                        case 8:
                            accept = true;
                            break;

                        case 9:
                            return;

                        default:
                            break;
                    }

                    Console.Write("Valgt: ");

                    foreach (string s in choosen)
                    {
                        Console.Write(s + ", ");
                    }
                }

                Bil bil = new Bil();

                foreach (string c in choosen)
                {
                    switch (c.ToLower())
                    {
                        case "reg_nr":
                            Console.WriteLine("Indtast nyt Regnr");
                            bil.RegNR = Console.ReadLine().Trim();
                            break;

                        case "kunde_id":
                            Console.WriteLine("Indtast nyt Kunde ID");
                            bil.KundeID = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "maerke":
                            Console.WriteLine("Indtast nyt mærke");
                            bil.Maerke = Console.ReadLine().Trim();
                            break;

                        case "model":
                            Console.WriteLine("Indtast ny Model");
                            bil.Model = Console.ReadLine().Trim();
                            break;

                        case "aargang":
                            Console.WriteLine("Indtast ny årgang");
                            bil.Aargang = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "km":
                            Console.WriteLine("Indtast ny km");
                            bil.Km = Convert.ToInt16(Console.ReadLine().Trim());
                            break;

                        case "braendstof":
                            Console.WriteLine("Indtast nyt Brændstof");
                            bil.Braendstof = Console.ReadLine();
                            break;

                        case "kml":
                            Console.WriteLine("Indtast ny kml");
                            float.TryParse(Console.ReadLine(), out float kml);
                            bil.Kml = kml;
                            break;

                        default:
                            UpdateBil();
                            break;
                    }

                }

                List<string> ToUpdate = new List<string>();

                //Dette finder ud af hvad der skal ændres
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

                //Skriv kommandoen
                for (int i = 0; i < ToUpdate.Count; i++)
                {
                    sqlcmd += ToUpdate[i];

                    if (i < (ToUpdate.Count - 1))
                        sqlcmd += ", ";
                }

                sqlcmd += string.Format(" where reg_nr = '{0}'", regnr);
                SQL.Update(sqlcmd);
            }
        }

        /// <summary>
        /// InnerJoin
        /// </summary>
        public void InnerJoinAll()
        {   //Få fat i alle Kunder og biller som er linket
            string sqlcmd = "select id, fornavn, efternavn, reg_nr, maerke, model" +
                            " From Kunder" +
                            " Inner join biler on Kunder.id = biler.kunde_id";

            Console.WriteLine("Id, Fornavn, Efternavn, Reg nr, Mærke, Model");
            SQL.Read(sqlcmd);
        }

        public void InnerJoinKundeId()
        {   //Få fat i alle biler en bestemt kunde har
            Console.Write("Indtast Kunde id: ");
            string id = Console.ReadLine();
            string sqlcmd = string.Format("select id, fornavn, efternavn, reg_nr, maerke, model" +
                            " From Kunder" +
                            " Inner join biler on Kunder.id = biler.kunde_id" +
                            " Where id = {0}", id);

            Console.WriteLine("Id, Fornavn, Efternavn, Reg Nr, Mærke, Model");
            SQL.Read(sqlcmd);
        }

        public void InnerJoinRegNr()
        {   //Få fat i kunden en bestemt bil har
            Console.Write("Indtast Reg nr: ");
            string regnr = Console.ReadLine().ToUpper();
            string sqlcmd = string.Format("select id, fornavn, efternavn, bil.*" +
                            " From Kunder" +
                            " Inner join biler on Kunder.id = biler.kunde_id" +
                            " Where reg_nr = '{0}'", regnr);

            Console.WriteLine("Id, Fornavn, Efternavn, Reg Nr, Mærke, Model");
            SQL.Read(sqlcmd);
        }

        public void InnerJoinAutoRecord()
        {
            Console.Write("Indtast besøg id: ");
            string bId = Console.ReadLine();
            string sqlcmd = string.Format("select Vaerkstedsophold.id, Kunder.id, Kunder.fornavn, Kunder.efternavn, Biler.*" +
                                          "From((Vaerkstedsophold " +
                                          "inner join Kunder on Vaerkstedsophold.id = kunder.id)" +
                                          "inner join Biler on Vaerkstedsophold.fk_reg_nr = Biler.reg_nr); ");

            Console.WriteLine("Besøg Id, Kunde Id, Fornavn, Efternavn, Reg nr, Kunde Id, Mærke, Årgang, Km, Brændstof, Kml, Oprettelses Dato");
            SQL.Read(sqlcmd);
        }

        /// <summary>
        /// AutoVærksted
        /// </summary>
        public void NewAutoRecord()
        {   //Opret ny værksteds ophold
            string afleverings_dato = "null", hentnings_dato = "null", damage = "null", diagnose = "null", comment = "null";
            Console.Write("Opret nyt værksteds besøg\nIndtast Kunde id: ");
            string id = Console.ReadLine();

            Console.Write("\nIndtast Reg nr: ");
            string regnr = Console.ReadLine().ToUpper();

            MenuItem[] Choice = new MenuItem[]
            {
                new MenuItem("Aflever bil"),
                new MenuItem("Hent Bil"),
                new MenuItem("Eftersyn"),
                new MenuItem("Tilbage")
            };

            Console.Clear();

            switch (menu.MenuSelector(Choice, "Fortag valg\n"))
            {
                case 0:
                    afleverings_dato = "GETDATE()";
                    Console.Write("\nIndtast Kunde Kommentar: ");
                    comment = Console.ReadLine();

                    Console.Write("\nIndtast Diagnose: ");
                    diagnose = Console.ReadLine();

                    Console.Write("\nIndtast Skadeomfang: ");
                    damage = Console.ReadLine();
                    break;

                case 1:
                    if (string.IsNullOrEmpty(afleverings_dato))
                    {
                        Console.WriteLine("Der er ikke en afleveret en Bil med RegNr: {0}, i Værkstedet ", regnr);
                    }
                    else
                    {
                        Console.WriteLine("\nIndtast nuværende Skadeomfang");
                        damage = Console.ReadLine();
                        afleverings_dato = "null";
                        hentnings_dato = "GETDATE()";
                    }
                    break;

                case 2:
                    break;

                case 3:
                    return;

                default:
                    return;
            }

            if (string.IsNullOrEmpty(diagnose))
            {
                comment = "null";
                damage = "null";
            }

            string sqlcmd = string.Format("insert into Vaerkstedsophold (oprettelsesdato, kunde_id, fk_reg_nr, " +
                                          "aflevering_dato, hentning_dato, skade, diagnose, kunde_kommentar) " +
                                          "values (GETDATE(), {0}, '{1}', {2}, {3}, '{4}', '{5}', '{6}')",
                                          id, regnr, afleverings_dato, hentnings_dato, damage, diagnose, comment);

            SQL.Create(sqlcmd);
        }

        public void ShowAutoRecord()
        {   //Vis værksteds ophold
            Console.Write("Vis værksteds besøg\nIndtast besøg id: ");
            string id = Console.ReadLine();

            string sqlcmd = string.Format("select * from vaerkstedsophold where id= {0}", id);

            Console.WriteLine("Id, Fornavn, Efternavn, Reg Nr, Mærke, Model");
            SQL.Read(sqlcmd);
        }

        public void ShowAutoRecordAll()
        {   //Vis alle værksteds ophold
            string sqlcmd = string.Format("select * from vaerkstedsophold");
            Console.WriteLine("Id, Fornavn, Efternavn, Reg Nr, Mærke, Model");
            SQL.Read(sqlcmd);
        }


        public void DeleteAutoRecord()
        {   //Slet værksteds ophold
            Console.Write("Slet værksteds besøg\nIndtast besøg id: ");
            string id = Console.ReadLine();

            string sqlcmd = string.Format("delete from vaerkstedsophold where id= {0}", id);
            SQL.Delete(sqlcmd);
        }
        

        /// <summary>
        /// Diverse
        /// </summary>
        private bool AreYouSure()
        {   //Er du sikker metode, spørg om brugeren er sikker på sit input
            Console.WriteLine("Er du sikker? Y/N");
            if (Console.ReadLine().ToLower() == "y")
                return true;
            else
                return false;
        }
    }
}
