using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal class Category : ICategory
    {
        private int _id;
        private string categoryName;

        public Category()
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

        public string CategoryName {

            get { return categoryName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    categoryName = value;   
                }
            }
        }
    }
}
