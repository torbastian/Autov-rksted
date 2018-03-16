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

        //Properties
        public string Fornavn {
            get { return fornavn; }
            set { fornavn = value; }
        }

        public string Efternavn {
            get { return efternavn; }
            set { efternavn = value; }
        }

        public string Adresse {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Tlf {
            get { return tlf; }
            set { tlf = value; }
        }

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
