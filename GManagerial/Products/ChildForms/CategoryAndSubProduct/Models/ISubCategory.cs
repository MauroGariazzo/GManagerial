using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal interface ISubCategory
    {
        int ID { get; set; }   
        int CategoryId { get; set; }    
        string SubCategoryName { get; set; }    
    }
}
