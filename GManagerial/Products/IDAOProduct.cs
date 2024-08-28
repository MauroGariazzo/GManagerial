using GManagerial.Products;
using GManagerial;
using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal interface IDAOProduct
    {
    int Insert(Product product);
    Dictionary<int,Product> GetAll();
    void Update(Product product);
    void Delete(Product product, string deleteQuery);
    Dictionary<int, Product> GetProductsSearch(string searchValues, string category, string subcategory, string brand, string query, Supplier supplier);
}
