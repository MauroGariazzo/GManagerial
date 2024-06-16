using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal interface ICategory
    {
        int ID { get; set; }    
        string CategoryName { get; set; }   
    }
}
