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
    public partial class AddNewCategory : Form
    {

        private System.Windows.Forms.TreeView catTV;
        private sharedLogic sl;
        private char nec;

        public AddNewCategory(System.Windows.Forms.TreeView catTV, char nec)
        {
            InitializeComponent();
            this.catTV = catTV;
            this.sl = new sharedLogic(catTV, categoryTB, null, nec, 'c', null);
            this.nec = nec;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (sl.CatOrSubValidation())
            {
                if (this.nec == 'n')
                {
                    CategoriesMGM.InsertCatInDB(categoryTB);
                }

                else
                {
                    TreeNode node = catTV.SelectedNode;
                    int idCategory = Convert.ToInt32(node.Tag);

                    CategoriesMGM.EditCat(idCategory, categoryTB);

                }
                catTV.Nodes.Clear();
                CategoriesMGM.LoadCatFromDB(catTV);
                this.Close();
            }
        }


        private void AddNewCategory_Load(object sender, EventArgs e)
        {
            this.AddCategoryOrSub.Text = "Inserisci categoria";
            if (this.nec == 'e')
            {
                this.categoryTB.Text = catTV.SelectedNode.Text;
                this.categoryTB.SelectionStart = categoryTB.Text.Length;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
