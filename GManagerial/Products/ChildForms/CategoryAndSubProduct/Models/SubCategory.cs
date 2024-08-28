using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal class SubCategory : ISubCategory //??
    {
        private int _id;
        private string subCategoryName;

        public SubCategory() 
        {
            this._id = 1;
        }
        public int ID
        {
            get { return _id; }

            set
            {
                _id = value;
            }
        }
        public int CategoryId { get; set; }
        public string SubCategoryName
        {
            get { return subCategoryName; }

            set
            {
                if (value != null)
                {
                    subCategoryName = value;
                }

                else
                {
                    throw new ArgumentException("Non puoi lasciare il campo vuoto");
                }
            }
        }
    }
}
