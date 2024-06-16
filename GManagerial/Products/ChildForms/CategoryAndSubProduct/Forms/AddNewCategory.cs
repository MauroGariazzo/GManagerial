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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GManagerial.Products.ChildForms
{
    internal partial class AddNewCategory : Form
    {
        private char _nec; 
        //private DBConnector _dbconnector = new DBConnector("Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True");
        private DBConnector _dbconnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

        private Category _category;
        private DAOCategory _daocategory;
        private CategoryUpdate _callbackCategory;

        public AddNewCategory(Category category)
        {
            InitializeComponent();
            this._category = category;
            this._daocategory = new DAOCategory(this._dbconnector);  
        }

        public char Nec
        {
            get { return _nec; }
            set { _nec = value; }
        }

        public void SetCategoryCallBack(CategoryUpdate categoryUpdate)
        {
            _callbackCategory = categoryUpdate;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(categoryTB.Text))
            {
               
                if(!CheckIfCategoryAlreadyExist())
                {
                    InsertOrUpdateDataToDB();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Categoria già esistente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

            else
            {
                MessageBox.Show("Non puoi lasciare il campo vuoto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool CheckIfCategoryAlreadyExist()
        {
            if(_daocategory.CheckIfCategoryAlreadyExist(categoryTB.Text))
            {
                return true;
            }
            return false;
        }

        private void InsertOrUpdateDataToDB()
        {
            if (_nec == 'n')
            {           
                _category.CategoryName = categoryTB.Text;
                _daocategory.Insert(_category);
            }

            else
            {
                _category.CategoryName = categoryTB.Text;
                _daocategory.Update(_category);
            }
        }

        private void AddNewCategory_Load(object sender, EventArgs e)
        {
            this.AddCategoryOrSub.Text = "Inserisci categoria";
            if (_nec == 'e')
            {
                this.categoryTB.Text = _category.CategoryName;
                this.categoryTB.SelectionStart = categoryTB.Text.Length;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            _callbackCategory();
        }
    }
}
