using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GManagerial.WareHouse.models
{
    internal interface IWarehouse
    {
        int ID
        {
            get;
            set;
        }

        string Warehouse_Name
        {
            get; set;
        }

        string Region
        {
            get; set;
        }

        string Province
        {
            get; set;
        }

        string City
        {
            get; set;
        }

        string ZipCode
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }

        string Description
        {
            get; set;
        }
    }
}
