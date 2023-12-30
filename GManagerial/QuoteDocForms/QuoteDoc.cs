using GManagerial.QuoteDocForms.ChildForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    public partial class QuoteDoc : Form
    {

        string connectionString;
        public QuoteDoc()
        {
            InitializeComponent();
            this.connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        }

        private void QuoteDoc_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT q.idQuote, c.name, q.date, q.state, q.total, q.deposit FROM QUOTETBL q INNER JOIN CUSTOMERTBL c ON q.id_customer = c.id_customer";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);     // Crea un oggetto SqlDataAdapter per eseguire la query e riempire un oggetto DataTable
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);  // Riempie il DataTable con i dati dal database

                QuoteDgv.DataSource = dataTable;  // Imposta la fonte dati del DataGridView
            }
            LoadTable();
        }


        private void LoadTable()
        {
            QuoteDgv.Columns[0].HeaderText = "n°";
            QuoteDgv.Columns[1].HeaderText = "Cliente";
            QuoteDgv.Columns[2].HeaderText = "Data";
            QuoteDgv.Columns[3].HeaderText = "Stato";
            QuoteDgv.Columns[4].HeaderText = "Totale";
            QuoteDgv.Columns[5].HeaderText = "Acconto";
        }

        private void newDoc_Click(object sender, EventArgs e)
        {
            AddNewCustomer customer = new AddNewCustomer();
            customer.ShowDialog();

            if (customer.isCustomerCreated == true)
            {
                AddNewQuote quote = new AddNewQuote();
                quote.ShowDialog();
            }
        }
    }
    
}
