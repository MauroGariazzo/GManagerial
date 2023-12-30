using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    class sharedLogic
    {
        private System.Windows.Forms.TreeView catTV;
        private TextBox category;
        private TextBox subCategory;
        private TreeNode parentNode;

        private char nec;
        private char isCatOrSub;
        public sharedLogic(TreeView catTV, TextBox categoryTB, TextBox subCategory, char nec, char isCatOrSub, TreeNode parentNode)
        { 
            this.catTV = catTV; 
            this.category = categoryTB;
            this.subCategory = subCategory;
            this.nec = nec;
            this.isCatOrSub = isCatOrSub;
            this.parentNode = parentNode;
        }

        public Boolean CatOrSubValidation()
        {
            if (this.isCatOrSub == 'c') //se è una categoria
            {
                if (category.Text == "")
                {
                    MessageBox.Show("Non puoi lasciare il campo vuoto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    if (!DoesCategoryExist() || (DoesCategoryExist() && this.nec == 'e'))
                    {
                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Categoria già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return false;
            }

            else //è una sottocategoria
            {
                if (subCategory.Text == "")
                {
                    MessageBox.Show("Non puoi lasciare il campo vuoto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    if (!DoesSubCategoryExist() || (DoesSubCategoryExist() && this.nec == 'e'))
                    {
                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Categoria già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return false;
            }
        }


        private bool DoesCategoryExist()
        {
            foreach (TreeNode node in catTV.Nodes)
            {
                if (node.Text == category.Text)
                {
                    return true; // Nodo con lo stesso nome trovato
                }
            }

            return false; // Nodo non trovato
        }


        private bool DoesSubCategoryExist()
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Text == subCategory.Text)
                {
                    return true; // Nodo con lo stesso nome trovato
                }
            }

            return false; // Nodo non trovato
        }
    }
} //subCategory
