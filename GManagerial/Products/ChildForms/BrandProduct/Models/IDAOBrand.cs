using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal interface IDAOBrand
    {
        void Insert(IBrand brand);
        List<IBrand> GetAll();
        Dictionary <string, IBrand> GetAllDictionaries();
        void Update(IBrand brand);
        void Delete(IBrand brand);  
    }
}
