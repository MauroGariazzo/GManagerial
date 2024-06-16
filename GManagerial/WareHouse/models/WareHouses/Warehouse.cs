using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models
{
    public class Warehouse:IWarehouse
    {
        private int _id;
        private string _name;
        private string _region;
        private string _province;
        private string _city;
        private string _zipCode;
        private string _address;
        private string _description;


        public Warehouse()
        {

        }
            
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Warehouse_Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }

                else
                {
                    throw new ArgumentException("Non puoi creare un magazzino senza nome");
                }
            }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
            }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
            }
        }

        public string Address
        {
            get { return _address; }
                        set
            {
                _address = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
