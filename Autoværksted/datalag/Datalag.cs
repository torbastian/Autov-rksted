using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Datalag
    {
        public void CreateKunde(Kunde kunde)
        {
            //Opret og set variabler
            string fnavn, enavn, adresse, tlf;

            fnavn = kunde.Fornavn;
            enavn = kunde.Efternavn;
            adresse = kunde.Adresse;
            tlf = kunde.Tlf;

            //Hvis variabler ikke følger regler, skriv fejl
            if (fnavn.Length < 50 && enavn.Length < 50 && adresse.Length < 50 && tlf.Length < 12)
            {
                //Lav en ny SQL kommando string ud fra variabler
                string sqlcmd = string.Format("insert into Kunder (fornavn, efternavn, adresse, tlf, oprettelsesdato) values ('{0}', '{1}', '{2}', '{3}', GETDATE())",
                                              fnavn, enavn, adresse, tlf);
                //Kald på SQL.Create til at oprette kunden i databasen
                SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Et input er for langt");
        }

        public void ShowKunde(int id)
        {
            if (id > 0)
            {
                string sqlcmd = string.Format("select * from Kunder where id={0}", id);

                SQL.Read(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Ingen kunder har id på 0 eller lavere");
        }

        public void ShowKundeAll()
        {
            string sqlcmd = "select * from Kunder";
            SQL.Read(sqlcmd);
        }

        public void DeleteKunde(int id)
        {
            if (id > 0)
            {
                string sqlcmd = string.Format("delete from Kunder where id={0}", id);

                SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Ingen kunder har id på 0 eller lavere");
        }

        public void UpdateKunde(int id)
        {
            if (id < 0)
            {
                ShowKunde(id);
                Console.WriteLine("Hvad vil du ændre? - Indtast de følgende\n" +
                                  "Fornavn" +
                                  "Efternavn" +
                                  "Adresse" +
                                  "Telefon");

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

                List<string> ToUpdate = new List<string>();

                if (!string.IsNullOrEmpty(kunde.Fornavn))
                    ToUpdate.Add(string.Format("fornavn = '{0}'", kunde.Fornavn));

                if (!string.IsNullOrEmpty(kunde.Efternavn))
                    ToUpdate.Add(string.Format("efternavn = '{0}", kunde.Efternavn));

                if (!string.IsNullOrEmpty(kunde.Adresse))
                    ToUpdate.Add(string.Format("adresse = '{0}'", kunde.Adresse));

                if (!string.IsNullOrEmpty(kunde.Tlf))
                    ToUpdate.Add(string.Format("tlf = '{0}'", kunde.Tlf));

                string sqlUpdateString = "Update Kunder Set ";

                for (int i = 0; i < ToUpdate.Count; i++)
                {
                    sqlUpdateString += ToUpdate[i];

                    if (i < (ToUpdate.Count - 1))
                        sqlUpdateString += ", ";
                }

                sqlUpdateString += " where id = " + id.ToString();

                SQL.Update(sqlUpdateString);
            }
        }

        public void CreateBil(Bil bil)
        {
            string regNr, maerke, model, braendstof;
            int aargang, km, kundeid;
            float kml;

            regNr = bil.RegNR;
            maerke = bil.Maerke;
            model = bil.Model;
            braendstof = bil.Braendstof;
            aargang = bil.Aargang;
            km = bil.Km;
            kml = bil.Kml;
            kundeid = bil.KundeID;

            /*
             * private string regNR;
        private string maerke;
        private string model;
        private int aargang;
        private int km;
        private int kundeID;
             * create table Biler (
                reg_nr nvarchar(8) primary key,
                kunde_id int foreign key references Kunder(id),
                maerke nvarchar(50) not null,
                model nvarchar(50) not null,
                aargang int not null check(aargang > 1900),
                km int check(km >= 0),
                braendstof nvarchar(30) not null,
                km_l float not null,
                oprettelsesdato date not null
                )
            */
            }

        }
}
