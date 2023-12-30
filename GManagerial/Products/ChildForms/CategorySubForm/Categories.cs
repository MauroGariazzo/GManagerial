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
    public partial class Categories : Form
    {
        private CategoriesGUI cGUI;
        private char nec;
        private AddNewCategory anc;
        private AddNewSubCategory ans;
        private char IsCatOrSub;
        private int index;
        public Categories()
        {
            InitializeComponent();
            cGUI = new CategoriesGUI(catTV, subcategoryToolStripMenuItem); 

        }
        private void newBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.nec = 'n';
            if (e.Button == MouseButtons.Left)
            {
                cGUI.MouseDown(sender, newBtnMS);
            }

            cGUI.UploadSubCats();
        }


        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anc = new AddNewCategory(catTV, 'n');       
            anc.ShowDialog(); 
        }

        private void sottocategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catTV.SelectedNode.Parent != null)
            {
                ans = new AddNewSubCategory(catTV, 'n', catTV.SelectedNode.Parent);
            }

            else
            {
                ans = new AddNewSubCategory(catTV, 'n', catTV.SelectedNode);
            }

            ans.ShowDialog();

            catTV.SelectedNode = catTV.Nodes[index];
            catTV.Nodes[index].ExpandAll();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            CategoriesMGM.LoadCatFromDB(catTV);   
        }

        private void editBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.nec = 'e';

            if (IsCatOrSub == 'c')
            {
                anc = new AddNewCategory(catTV, 'e');
                anc.ShowDialog();
                
            }

            else if (IsCatOrSub == 's')
            {
                if (catTV.SelectedNode.Parent != null)
                {
                    ans = new AddNewSubCategory(catTV, 'e', catTV.SelectedNode.Parent);
                }

                else
                {
                    ans = new AddNewSubCategory(catTV, 'e', catTV.SelectedNode);
                }

                ans.ShowDialog();  
            }

            else
            {
                anc = new AddNewCategory(catTV, 'e');
                anc.ShowDialog();
            }

            catTV.SelectedNode = catTV.Nodes[index];
            catTV.Nodes[index].ExpandAll();
        }

    
        private void catTV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                IsCatOrSub = 'c';
                index = catTV.Nodes.IndexOf(e.Node);
            }
            else
            {
                IsCatOrSub = 's';
            }
        }

        private void deleteBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if(catTV.SelectedNode != null)
            {
                TreeNode selectedNode = catTV.SelectedNode;

                if (selectedNode.Parent == null) // è il nodo padre
                {
                    deleteCategories(selectedNode);
                }

                else
                {
                    DeleteSelectedSubCategory();
                }
            }
        }

        private void deleteCategories(TreeNode selectedNode)
        {
            if (selectedNode.Nodes.Count > 0)   //se sono presenti sottonodi
            {
                DialogResult result = MessageBox.Show(
                "Questa categoria contiene delle sottocategorie, proseguendo cancellerai anche queste.\n Vuoi procedere?",
                "Conferma",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    DeleteAllSC();
                    CategoriesMGM.DeleteCat(Convert.ToInt32(catTV.SelectedNode.Tag));

                    catTV.Nodes.Clear();
                    CategoriesMGM.LoadCatFromDB(catTV);
                }
            }

            else
            {
                DialogResult result = MessageBox.Show(
                "Sei sicuro di voler cancellare questa categoria?.\n Vuoi procedere?",
                "Conferma",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    CategoriesMGM.DeleteCat(Convert.ToInt32(catTV.SelectedNode.Tag));
                    catTV.Nodes.Clear();
                    CategoriesMGM.LoadCatFromDB(catTV);
                }

            }
        }

        private void DeleteSelectedSubCategory()
        {
            DialogResult result = MessageBox.Show(
                "Sei sicuro di voler cancellare questa sottocategoria?.\n Vuoi procedere?",
                "Conferma",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                CategoriesMGM.DeleteSub(Convert.ToInt32(catTV.SelectedNode.Tag));  //cancellare il singolo sottonodo

                catTV.Nodes.Clear();
                CategoriesMGM.LoadCatFromDB(catTV);

                catTV.SelectedNode = catTV.Nodes[index];
                catTV.Nodes[index].ExpandAll();
            }
        }

        private void DeleteAllSC()    //ciclare su tutti i sottonodi di una categoria selezionata
        {
            foreach (TreeNode subTree in catTV.SelectedNode.Nodes)
            {
                CategoriesMGM.DeleteSub(Convert.ToInt32(subTree.Tag));
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
