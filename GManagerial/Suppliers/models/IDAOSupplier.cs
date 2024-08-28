using System.Collections.Generic;

namespace GManagerial
{
    internal interface IDAOSupplier
    {
        int Insert(Supplier supplier);
        Dictionary<int, Supplier> GetAll();
        void Update(Supplier supplier);
        void Delete(Supplier supplier, string query);
        Dictionary<int, Supplier> GetSuppliersSearch(string searchValue, string region, string province, string city, string query);

    }
}
