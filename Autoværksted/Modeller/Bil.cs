using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Bil
    {
        //Fields
        private string regNR;
        private string maerke;
        private string model;
        private int aargang;
        private int km;
        private int kundeID;

        //Properties

        //henter field regNR
        public string RegNR
        {
            get { return regNR; }
            set { regNR = value; }
        }

        //henter field maerke
        public string Maerke
        {
            get { return maerke; }
            set { maerke = value; }
        }

        //henter field model
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        //henter field aargang
        public int Aargang
        {
            get { return aargang; }
            set { aargang = value; }
        }

        //henter field km
        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        //henter field kundeID
        public int KundeID
        {
            get { return kundeID; }
            set { kundeID = value; }
        }
    }
}
