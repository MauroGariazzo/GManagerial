using System.Collections.Generic;


namespace GManagerial
{
    internal interface IDAOCustomer
    {
        int Insert(Customer customer);
        Dictionary<int, Customer> GetAll();
        void Update(Customer customer);
        void Delete(Customer customer);
        Dictionary<int, Customer> GetCutstomersSearch(string searchValue, string region, string province, string city, string query);

    }
}
