using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Datalag
    {
        public void CreateKunde(string fnavn, string enavn, string adresse, string tlf)
        {
            if (fnavn.Length < 50 && enavn.Length < 50 && adresse.Length < 50 && tlf.Length < 12)
            {
                string sqlcmd = string.Format("insert into Kunder (fornavn, efternavn, adresse, tlf, oprettelsesdato) values ('{0}', '{1}', '{2}', '{3}', GETDATE())",
                                              fnavn, enavn, adresse, tlf);

                SQL.Create(sqlcmd);
            }
            else
                Console.WriteLine("Fejl!: Et input er for langt");
        }

    }
}
