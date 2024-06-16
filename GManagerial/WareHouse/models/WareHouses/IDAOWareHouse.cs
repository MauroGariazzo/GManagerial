using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models
{
    internal interface IDAOWareHouse
    {
        int Insert(Warehouse wareHouse);
        Dictionary<int, Warehouse> GetAll();
        void Update(Warehouse wareHouse);
        void Delete(Warehouse wareHouse);
    }
}
