using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Products.ChildForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Supplier
{
    class SupplierMGM
    {
        //static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        public SupplierMGM() { }

        static public void LoadSuppliers(DataGridView SupplierDGV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier_ID,Company_Name, City FROM SuppliersTbl WHERE SUPPLIER_ID != 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                bool checkBoxColumnExists = false;
                foreach (DataGridViewColumn column in SupplierDGV.Columns)
                {
                    if (column.Name == "chkColumn")
                    {
                        checkBoxColumnExists = true;
                        break;
                    }
                }

                if (!checkBoxColumnExists)
                {
                    DataGridViewCheckBoxColumn checkBoxDataGridViewColumn = new DataGridViewCheckBoxColumn();
                    checkBoxDataGridViewColumn.Name = "chkColumn";
                    checkBoxDataGridViewColumn.HeaderText = "";
                    
                    SupplierDGV.Columns.Insert(0, checkBoxDataGridViewColumn);
                }

                SupplierDGV.DataSource = dataTable;
                SupplierDGV.AutoGenerateColumns = false;


            }
        }

      

        static public void registerSupplier(char nec, System.Windows.Forms.TextBox Company_Name, System.Windows.Forms.TextBox idTaxBox,
            System.Windows.Forms.ComboBox regionBox, System.Windows.Forms.ComboBox municBox, System.Windows.Forms.ComboBox provBox,
            System.Windows.Forms.TextBox AddressBox, System.Windows.Forms.TextBox telBox, System.Windows.Forms.TextBox mobileBox,
            System.Windows.Forms.TextBox mailBox, System.Windows.Forms.TextBox CapBox, System.Windows.Forms.TextBox pecBox, System.Windows.Forms.TextBox notesBox,
            System.Windows.Forms.TextBox VAT_Number, System.Windows.Forms.TextBox Receiver_Code, int idSupplier)
        {
            string query = "";

            if (nec == 'n' || nec == 'c')
            {
                query = "INSERT INTO SUPPLIERSTBL(Company_Name, Tax_Code, VAT_Number, Receiver_Code, Region, Province, City, Postal_Code, Address," 
                    + "Phone, Mobile, Email, PEC, Notes)"

                + "VALUES(@Company_Name, @Tax_Code, @VAT_Number, @Receiver_Code, @Region, @Province, @City, @Postal_Code, @Address, @Phone, @Mobile," +
                " @Email, @PEC, @Notes)";
            }

            else if (nec == 'e')
            {
                 query = "UPDATE SUPPLIERSTBL SET Company_Name = @Company_Name, Tax_Code = @Tax_Code, Region = @Region, City = @City, Province = @Province,"
                 + "Address = @Address, Phone = @Phone, Mobile = @Mobile, Email = @Email, Postal_Code = @Postal_Code, Notes = @Notes, VAT_Number = @VAT_Number," +
                 "Receiver_Code = @Receiver_Code WHERE Supplier_ID = " + idSupplier;
            }

            else
            {
                query = "";
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Company_Name", Company_Name.Text);
                    command.Parameters.AddWithValue("@Tax_Code", idTaxBox.Text);
                    command.Parameters.AddWithValue("@Region", regionBox.Text);
                    command.Parameters.AddWithValue("@City", municBox.Text);
                    command.Parameters.AddWithValue("@Province", provBox.Text);
                    command.Parameters.AddWithValue("@Address", AddressBox.Text);
                    command.Parameters.AddWithValue("@Phone", telBox.Text);
                    command.Parameters.AddWithValue("@Mobile", mobileBox.Text);
                    command.Parameters.AddWithValue("@Email", mailBox.Text);
                    command.Parameters.AddWithValue("@Postal_Code", CapBox.Text);
                    command.Parameters.AddWithValue("@PEC", pecBox.Text);
                    command.Parameters.AddWithValue("@Notes", notesBox.Text);
                    command.Parameters.AddWithValue("@VAT_Number", VAT_Number.Text);
                    command.Parameters.AddWithValue("@Receiver_Code", Receiver_Code.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }

        static public void editSupplier(System.Windows.Forms.TextBox companyTB, System.Windows.Forms.TextBox mailBox, System.Windows.Forms.TextBox idTaxBox,
            System.Windows.Forms.ComboBox regionBox, System.Windows.Forms.ComboBox provBox, System.Windows.Forms.ComboBox municBox, System.Windows.Forms.TextBox AddressBox,
            System.Windows.Forms.TextBox telBox, System.Windows.Forms.TextBox pecBox, System.Windows.Forms.TextBox notesBox, System.Windows.Forms.TextBox CapBox,
            System.Windows.Forms.TextBox mobileBox, System.Windows.Forms.TextBox receiver_Code, System.Windows.Forms.TextBox VAT_n, int idSupplier)
        {
            string query = "SELECT Company_Name, Tax_Code, VAT_Number, Receiver_Code, Region, Province, City, Postal_Code, Address, Phone, Mobile, " +
                "Email, Pec, Notes FROM SuppliersTbl WHERE Supplier_ID = " + idSupplier;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    companyTB.Text = reader["Company_Name"].ToString();
                    mailBox.Text = reader["Email"].ToString();
                    idTaxBox.Text = reader["Tax_Code"].ToString();
                    regionBox.SelectedItem = reader["Region"].ToString();

                    provBox.SelectedItem = reader["Province"].ToString();
                    municBox.SelectedItem = reader["City"].ToString();

                    AddressBox.Text = reader["Address"].ToString();
                    telBox.Text = reader["Phone"].ToString();
                    pecBox.Text = reader["Pec"].ToString();
                    notesBox.Text = reader["Notes"].ToString();
                    CapBox.Text = reader["Postal_Code"].ToString();
                
                    mobileBox.Text = reader["Mobile"].ToString();
                    receiver_Code.Text = reader["Receiver_Code"].ToString();
                    VAT_n.Text = reader["VAT_Number"].ToString();

                }

                reader.Close();
                connection.Close();
            }
        }

        static public void deleteSupplier(int Supplier_ID)
        {
            try
            {
                //string deleteInvoiceQuery = "DELETE FROM invoicetbl WHERE id_customer = " + idCustomer;
                string deletePriceSupplier = "DELETE FROM Product_Prices WHERE SUPPLIER_ID = @SUPPLIER_ID";
                string deleteAttachmentQuery = "DELETE FROM ATTACHMENTSTBL WHERE Supplier_ID = @SUPPLIER_ID";
                string deletSupplierQuery = "DELETE FROM SUPPLIERSTBL WHERE Supplier_ID = " + Supplier_ID;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deletePriceSupplier, connection))
                    {
                        command.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteAttachmentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deletSupplierQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

        }

        static public string ObtainCompanyName(int supplier_id)
        {
            string companyName = "";
            string query = "SELECT Company_Name FROM SUPPLIERSTBL WHERE supplier_id = " + supplier_id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    companyName = reader["Company_Name"].ToString();
                }

                reader.Close();

            }
            return companyName;
        }
    }
}
