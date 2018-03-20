using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Kunde
    {
        //Fields
        private string fornavn;
        private string efternavn;
        private string adresse;
        private string tlf;

        //Constructors(s)
        public Kunde() { }

        public Kunde(string fnavn, string enavn, string adr, string t)
        {
            fornavn = fnavn;
            efternavn = enavn;
            adresse = adr;
            tlf = t;
        }
        //Properties
        //henter field fornavn
        public string Fornavn {
            get { return fornavn; }
            set { fornavn = value; }
        }
        //henter field efternavn
        public string Efternavn {
            get { return efternavn; }
            set { efternavn = value; }
        }
        //henter field adresse
        public string Adresse {
            get { return adresse; }
            set { adresse = value; }
        }
        //henter field tlf
        public string Tlf {
            get { return tlf; }
            set { tlf = value; }
        }

        //Metode
        public bool IsFilled()
        {
            int fillCount = 0;

            if (!string.IsNullOrEmpty(fornavn) && fornavn.Length < 50)
                fillCount++;

            if (!string.IsNullOrEmpty(efternavn) && efternavn.Length < 50)
                fillCount++;

            if (!string.IsNullOrEmpty(adresse) && adresse.Length < 50)
                fillCount++;

            if (!string.IsNullOrEmpty(tlf) && tlf.Length < 12)
                fillCount++;

            return (fillCount == 4);
        }
    }
}
