using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using GManagerial.Products.ChildForms;

namespace GManagerial.CustomerMGM
{
    class CustomerMGM
    {
        
        //static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";

        static public void Load(DataGridView CustomersDgv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT customer_id,name,id_tax,region,municip,province,address,telephone,mobile,email,cap FROM customerTbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Verifica se la colonna delle checkbox esiste già
                bool checkBoxColumnExists = false;
                foreach (DataGridViewColumn column in CustomersDgv.Columns)
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
                    CustomersDgv.Columns.Insert(0, checkBoxDataGridViewColumn);
                }

                // Imposta la sorgente dati prima di disabilitare la generazione automatica delle colonne
                CustomersDgv.DataSource = dataTable;

                // Disabilita la generazione automatica delle colonne
                CustomersDgv.AutoGenerateColumns = false;
            }
        }
        static public void editCustomer(TextBox denBox, TextBox mailBox, TextBox idTaxBox, ComboBox regionBox, ComboBox provBox, ComboBox municBox, TextBox AddressBox,
            TextBox telBox, TextBox pecBox, TextBox notesBox, TextBox CapBox, TextBox birthDateTB, TextBox mobileBox, int id_customer)
        {
            string query = "SELECT name, email, id_tax, region, province, municip, address, telephone, pec, notes, cap, birthDate, mobile FROM customerTbl WHERE id_customer = " + id_customer;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["birthDate"].ToString() != "")
                    {
                        birthDateTB.Text = reader["birthDate"].ToString().Substring(0, 10);
                    }

                    denBox.Text = reader["name"].ToString();
                    mailBox.Text = reader["email"].ToString();
                    idTaxBox.Text = reader["id_tax"].ToString();
                    regionBox.SelectedItem = reader["region"].ToString();

                    provBox.SelectedItem = reader["province"].ToString();
                    municBox.SelectedItem = reader["municip"].ToString();

                    AddressBox.Text = reader["address"].ToString();
                    telBox.Text = reader["telephone"].ToString();
                    pecBox.Text = reader["pec"].ToString();
                    notesBox.Text = reader["notes"].ToString();
                    CapBox.Text = reader["cap"].ToString();
                    
                    mobileBox.Text = reader["mobile"].ToString();
                }

                reader.Close();
                connection.Close();
            }
        }

        static public void registerCustomer(char nec, TextBox denBox, TextBox mailBox, TextBox idTaxBox, ComboBox regionBox, ComboBox provBox, ComboBox municBox, TextBox AddressBox,
            TextBox telBox, TextBox pecBox, TextBox notesBox, TextBox CapBox, TextBox birthDateTB, TextBox mobileBox, int id_customer)
        {
            string query = "";
            if (nec == 'n' || nec == 'c')
            {

                query = "INSERT INTO CUSTOMERTBL(name,id_tax,region,municip,province,address,telephone,mobile,email,cap,birthDate,pec,notes)"
                + "VALUES(@name,@id_tax,@region,@municip,@province,@address,@telephone,@mobile,@email,@cap,@birthDate,@pec,@notes)";
            }

            else if (nec == 'e')
            {
                query = "UPDATE CUSTOMERTBL SET name = @name, id_tax = @id_tax, region = @region, municip = @municip, province = @province, address = @address, telephone = @telephone, mobile = @mobile, email = @email, cap = @cap, birthDate = @birthDate, notes = @notes WHERE id_customer = " + id_customer;
            }

            else
            {
                query = "";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", denBox.Text);
                    command.Parameters.AddWithValue("@id_tax", idTaxBox.Text);
                    command.Parameters.AddWithValue("@region", regionBox.Text);
                    command.Parameters.AddWithValue("@municip", municBox.Text);
                    command.Parameters.AddWithValue("@province", provBox.Text);
                    command.Parameters.AddWithValue("@address", AddressBox.Text);
                    command.Parameters.AddWithValue("@telephone", telBox.Text);
                    command.Parameters.AddWithValue("@mobile", mobileBox.Text);
                    command.Parameters.AddWithValue("@email", mailBox.Text);
                    command.Parameters.AddWithValue("@cap", CapBox.Text);

                    if (birthDateTB.Text != "") { command.Parameters.AddWithValue("@birthDate", birthDateTB.Text); }
                    else { command.Parameters.AddWithValue("@birthDate", DBNull.Value); }
                  
                    command.Parameters.AddWithValue("@pec", pecBox.Text);
                    command.Parameters.AddWithValue("@notes", notesBox.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }

        static public void deleteCustomer(int idCustomer)
        {
            try
            {
                string deleteInvoiceQuery = "DELETE FROM invoicetbl WHERE id_customer = " + idCustomer;
                string deleteAttachmentQuery = "DELETE FROM ATTACHMENTSTBL WHERE ID_CUSTOMER = @idCustomer";
                string deletCustomQuery = "DELETE FROM customerTbl WHERE id_customer = " + idCustomer;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteInvoiceQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteAttachmentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idCustomer", idCustomer);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deletCustomQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception)
            {
                return;
            }
            
        }

        static public int maxIdCustomer()
        {
            int maxId = 0;
            string query = "SELECT MAX(id_customer) FROM customerTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();
                    maxId = Convert.ToInt32(result);
                }
            }
            return maxId;
        }

    }
}

