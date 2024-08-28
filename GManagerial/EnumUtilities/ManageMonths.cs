using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.EnumUtilities
{
    internal class ManageMonths
    {
        public enum Months
        {
            Gennaio = 1,
            Febbraio = 2,
            Marzo = 3,
            Aprile = 4,
            Maggio = 5,
            Giugno = 6,
            Luglio = 7,
            Agosto = 8,
            Settembre = 9,
            Ottobre = 10,
            Novembre = 11,
            Dicembre = 12
        }

        public static string GetNameMonth(int numberMonth)
        {
            if (Enum.IsDefined(typeof(Months), numberMonth))
            {
                return ((Months)numberMonth).ToString();
            }
            throw new ArgumentException("Numero del mese non valido");
        }

        public static int GetNumberMonth(string nameMonth)
        {
            if (Enum.TryParse(nameMonth, true, out Months meseEnum))
            {
                return (int)meseEnum;
            }
            throw new ArgumentException("Nome del mese non valido");
        }
    }
}
