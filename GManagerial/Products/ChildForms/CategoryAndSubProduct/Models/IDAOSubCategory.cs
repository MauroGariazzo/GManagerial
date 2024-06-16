using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms.CategorySubForm.Models
{
    internal interface IDAOSubCategory
    {
        void Insert(ISubCategory subcategory, ICategory category);
        List<ISubCategory> GetAll();
        Dictionary<string, ISubCategory> GetAllDictionaries();
        void Update(ISubCategory subCategory);
        void Delete(ISubCategory subCategory);
    }
}
