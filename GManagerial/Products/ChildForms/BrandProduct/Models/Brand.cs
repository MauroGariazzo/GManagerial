using GManagerial.DBConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    internal class Brand:IBrand
    {
        private string _name;
        private int _id;
        
        public Brand()
        {
            this._id = 1;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int ID 
        {
            get { return _id; }
            set
            { _id = value; }
        }
    }
}
