using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial
{
    internal interface ICustomer
    {
        int ID { get; set; }
        string Name { get; set; }
        string IdTax { get; set; }
        string Email { get; set; }
        string Pec { get; set; }    
        string Telephone { get; set; }
        string Mobile { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string ZipCode { get; set; }
        string Province { get; set; }
        string Notes { get; set; }
        string BirthDate { get; set; }

        //dizionario con dei documenti


    }
}
