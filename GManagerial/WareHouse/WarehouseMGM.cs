using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.WareHouse
{
    class WarehouseMGM
    {
        //static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";

        //warehouse combobox names
        static public void LoadWareHouseNamesForComboBox(System.Windows.Forms.ComboBox cbWarehouse)
        {
            cbWarehouse.Items.Clear();

            string query = "SELECT Warehouse_id, Warehouse_Name FROM WAREHOUSETBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ItemTag item = new ItemTag();    
                                item.Tag = reader.GetInt32(0);
                                item.Text = reader.GetString(1);

                                cbWarehouse.Items.Add(item);
                            }


                        }
                            connection.Close();  
                    }
                }
                
            }
        }

        //creazione magazzino
        static public void CreateWareHouseQuery(System.Windows.Forms.TextBox whName, System.Windows.Forms.ComboBox regionCB,
            System.Windows.Forms.ComboBox provCB, System.Windows.Forms.ComboBox municCB,
            System.Windows.Forms.TextBox addressTB, System.Windows.Forms.TextBox zip_code, char nec, int warehouse_id = 0)
        {
            string query = "";

            if (nec == 'e')
            {
                query = "UPDATE WAREHOUSETBL SET Warehouse_Name = @Warehouse_Name, region = @region, " +
                    "province = @province, municip = @municip, address = @address, zip_code = @zip_code" +
                    " WHERE Warehouse_id = " + warehouse_id;
            }
            else
            {
                query = "INSERT INTO WAREHOUSETBL(Warehouse_Name, region, province, municip, address, zip_code)" +
                    "VALUES(@Warehouse_Name, @region, @province, @municip, @address, @zip_code)";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Warehouse_Name", whName.Text);
                    command.Parameters.AddWithValue("@region", regionCB.Text);
                    command.Parameters.AddWithValue("@province", provCB.Text);
                    command.Parameters.AddWithValue("@municip", municCB.Text);
                    command.Parameters.AddWithValue("@address", addressTB.Text);
                    command.Parameters.AddWithValue("@zip_code", zip_code.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        static public void PhysicalWareHouse_Load(ListBox lbWarehouse)
        {
            lbWarehouse.Items.Clear();  

            string query = "SELECT Warehouse_id, Warehouse_Name FROM WareHouseTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemTag item = new ItemTag();
                    item.Tag = reader.GetInt32(0);
                    item.Text = reader.GetString(1);
                    lbWarehouse.Items.Add(item);
                }
            }
        }

        //modifica magazzino
        static public void EditWareHouse(System.Windows.Forms.TextBox WHname, System.Windows.Forms.ComboBox regionBox,
            System.Windows.Forms.ComboBox provBox, System.Windows.Forms.ComboBox municBox, System.Windows.Forms.TextBox AddressBox,
            System.Windows.Forms.TextBox CapBox, int Warehouse_id)
        {
            string query = "SELECT Warehouse_Name, region, province, municip," +
                " address, zip_code, Description FROM WareHouseTbl WHERE Warehouse_id = " + Warehouse_id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    WHname.Text = reader["Warehouse_Name"].ToString();

                    regionBox.SelectedItem = reader["region"].ToString();
                    provBox.SelectedItem = reader["province"].ToString();
                    municBox.SelectedItem = reader["municip"].ToString();
                    AddressBox.Text = reader["address"].ToString();
                    CapBox.Text = reader["zip_code"].ToString();

                }

                reader.Close();
                connection.Close();
            }
        }

        //elimina magazzino
        static public void DeleteWareHouse(int Warehouse_id)
        {
            string deleteLS = "DELETE FROM LOADSTOCKTBL WHERE WAREHOUSE_ID = " + Warehouse_id;
            string deleteWH = "DELETE FROM WAREHOUSETBL WHERE Warehouse_id = " + Warehouse_id;
            string deletePR = "DELETE FROM WAREHOUSEPRODUCT WHERE WAREHOUSE_ID = " + Warehouse_id;
            //cancellare tutti i movimenti(ordini, carichi e impegni)

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(deletePR, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(deleteLS, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(deleteWH, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            
        }
    }
    
}
