using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms.CategorySubForm.Models;
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

namespace GManagerial.Products.ChildForms
{
    internal partial class AddNewSubCategory : Form
    {
        private char _nec;
        private SubCategory _subCategory;
        private DBConnector _dbconnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        private DAOSubCategory _daoSubCategory;

        private Category _category;

        private AddInfoToSubCategoryObj _callbackSubCategory;
        public char Nec
        {
            get { return this._nec; }
            set { this._nec = value; }
        }

        public void SetSubCategoryCallBack(AddInfoToSubCategoryObj callbackSubCategory)
        {
            _callbackSubCategory = callbackSubCategory;
        }

        public AddNewSubCategory(SubCategory subCategory, Category category) //subcategory per il nuovo inserimento, la categoria invece mi serve per verificare se l'utente sta cercando di inserire una
        {                                                                    //sottocategoria già esistente nel db sotto una determinata categoria. es. inserire "lavatrice" sotto la categoria elettrodomestici
            InitializeComponent();                                          //se è già presente, stamperà un messaggio
            this._daoSubCategory = new DAOSubCategory(_dbconnector);
            this._subCategory = subCategory;
            this._category = category;  
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(subCcategoryTB.Text))
            {
                if (!CheckIfSubCategoryAlreadyExist())
                {
                    InsertOrUpdateDataToDB();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Sottocategoria già esistente", "Attenzione", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Non puoi lasciare il campo vuoto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckIfSubCategoryAlreadyExist()
        {
            if (_daoSubCategory.CheckIfSubCategoryAlreadyExist(subCcategoryTB.Text, _category))
            {
                return true;
            }
            return false;
        }

        private void InsertOrUpdateDataToDB()
        {
            if (_nec == 'n')
            {
                _subCategory = new SubCategory();
                _subCategory.SubCategoryName = subCcategoryTB.Text;
                _subCategory.SubCategoryName = subCcategoryTB.Text;
                _daoSubCategory.Insert(_subCategory, _category);
            }

            else
            {
                _subCategory.SubCategoryName = subCcategoryTB.Text;
                _daoSubCategory.Update(_subCategory);
            }


            this.Close();
        }

        private void AddNewSubCategory_Load(object sender, EventArgs e)
        {
            this.AddSubCategory.Text = "Inserisci sottocategoria";

            if (this._nec == 'e')
            {
                this.subCcategoryTB.Text = _subCategory.SubCategoryName;    
                this.subCcategoryTB.SelectionStart = subCcategoryTB.Text.Length;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewSubCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_callbackSubCategory != null)
            {
                _callbackSubCategory();
            }
        }
    }
}
