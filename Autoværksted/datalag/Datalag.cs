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

                //SQL.Show(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Ingen kunder har id på 0 eller lavere");
        }

        public void DeleteKunde(int id)
        {
            if (id > 0)
            {
                string sqlcmd = string.Format("delete from Kunder where id={0}", id);

                //SQL.Delete(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Ingen kunder har id på 0 eller lavere");
        }

        //public void CreateBil(Bil bil)
        //{
        //    string regNr, maerke, model;
        //    int aargang, km, kundeid;

        //    regNr = bil.RegNR;
        //    maerke = bil.Maerke;
        //    model = bil.Model;
        //    aargang = bil.Aargang;
        //    km = bil.Km;
        //    kundeid = bil.KundeID;

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
        //}

    }
}
