using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal interface IDAOCategory
    {
        void Insert(ICategory category);
        List<ICategory> GetAll();
        Dictionary<string, ICategory> GetAllDictionaries();
        void Update(ICategory category);
        void Delete(ICategory category);
    }
}
