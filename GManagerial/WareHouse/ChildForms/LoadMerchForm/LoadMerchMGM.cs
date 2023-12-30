using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.ChildForms
{
    class LoadMerchMGM
    {
        //static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        /*static public void LoadMerch_Load(DataGridView LoadMerchDGV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT LoadStock_id, quantity, operation_date, p.Product_Name, Supplier_id, Warehouse_id" +
                    " FROM LoadStockTbl JOIN PRODUCTSTBL p ON LoadStockTbl.Product_id = p.Product_id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                LoadMerchDGV.DataSource = dataTable;
                LoadMerchDGV.AutoGenerateColumns = false;
            }

        }*/
    }
}
