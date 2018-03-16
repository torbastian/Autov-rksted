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
        private int id;
        private string fornavn;
        private string efternavn;
        private string adresse;
        private string tlf;

        //Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

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
    }
}
