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
    public partial class AddNewSubCategory : Form
    {
        private System.Windows.Forms.TreeView catTV;
        private sharedLogic sl;
        private char nec;
        private TreeNode parentNode;

        public AddNewSubCategory(System.Windows.Forms.TreeView catTV, char nec, TreeNode parentNode)
        {
            InitializeComponent();
            this.catTV = catTV;
            this.parentNode = parentNode;
            this.sl = new sharedLogic(catTV, null, subCcategoryTB, nec, 's', parentNode);
            this.nec = nec; 
            
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (sl.CatOrSubValidation())
            { 
                TreeNode parentNode = catTV.SelectedNode;

                if (parentNode.Parent != null)
                {
                    parentNode = parentNode.Parent; 
                }

                if (this.nec == 'n')
                {
                    CategoriesMGM.SubCatInDB(subCcategoryTB, Convert.ToInt32(parentNode.Tag));
                }

                else
                {
                    TreeNode node = catTV.SelectedNode;
                    int idSubCategory = Convert.ToInt32(node.Tag);

                    CategoriesMGM.EditSubCat(idSubCategory, subCcategoryTB);
                }

                catTV.Nodes.Clear();

                CategoriesMGM.LoadCatFromDB(catTV);

                this.Close();
            } 

            else
            {
                subCcategoryTB.Text = null;
            }
        }

        private void AddNewSubCategory_Load(object sender, EventArgs e)
        {
            this.AddSubCategory.Text = "Inserisci sottocategoria";

            if (this.nec == 'e')
            {
                this.subCcategoryTB.Text = catTV.SelectedNode.Text;
                this.subCcategoryTB.SelectionStart = subCcategoryTB.Text.Length;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
