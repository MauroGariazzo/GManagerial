using GManagerial.DBConnectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace GManagerial.Products.ChildForms
{
    internal partial class BrandInfoForm : Form
    {
        private char _nec;
        private Brand _brand;
        private DAOBrand _daoBrand;
        private DBConnector _dbconnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
      
        public char Nec
        {
            get { return _nec; }  

            set
            {
                if (value == 'n' || value == 'e')
                {
                    _nec = value;
                }

                else 
                {
                    MessageBox.Show("Qualcosa è andato storto =(");
                }
            } 
        }
        public BrandInfoForm()
        {
            this._daoBrand = new DAOBrand(this._dbconnector);  //costruttore new
            this._brand = new Brand();
            InitializeComponent();
        }

        public BrandInfoForm(Brand brand)
        {
            this._daoBrand = new DAOBrand(this._dbconnector);  
            this._brand = brand;
            InitializeComponent();
        }


        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(brandTB.Text))
            {
               if (!CheckIfBrandAlreadyExist())
               {
                   InsertOrUpdateDataToDB();
                   this.Close();
               }

               else
               {
                   MessageBox.Show("Brand già esistente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
            }

             else
             {
                   MessageBox.Show("Non puoi lasciare il campo vuoto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
        }

        private bool CheckIfBrandAlreadyExist()
        {
            if (_daoBrand.CheckIfBrandAlreadyExist(brandTB.Text))
            {
                return true;
            }
            return false;
        }

        private void InsertOrUpdateDataToDB()
        {
            if (_nec == 'n')
            {
                _brand = new Brand();

                CheckIfBrandAlreadyExist();
                
                _brand.Name = brandTB.Text; 
                _daoBrand.Insert(_brand);
            }

            else
            {
                _brand.Name = brandTB.Text;
                _daoBrand.Update(_brand);
            }
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBrand_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(nec.ToString());
            if (this._nec == 'e')
            {
                brandTB.Text = _brand.Name;
            }
        }
    }
}
