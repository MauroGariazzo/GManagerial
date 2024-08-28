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
    public delegate void AddInfoToSubCategoryObj();
    public partial class CategoriesForm : Form
    {
        private CategoriesGUI cGUI;
        private AddNewCategory _addNewCategory;
        private AddNewSubCategory _addNewSubCategory;
        private int selectedNodeIndex;
       
        ////////////////////////////////////////////////////

        private Dictionary<string, ICategory> _categories;
        private Dictionary<string, ISubCategory> _subCategories;


        private DAOCategory _daoCategory;
        private DAOSubCategory _daoSubCategory;

        private Category _category;
        private SubCategory _subCategory;

        private DBConnector _dBConnector;
        private CategoryUpdate _callbackForCategoryCB;
        private SubCategoryUpdate _callbackForSubCategoryCB;

        public CategoriesForm()
        {
            InitializeComponent();
            cGUI = new CategoriesGUI(catTV, subcategoryToolStripMenuItem);
            this._dBConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

            this._daoCategory = new DAOCategory(this._dBConnector);
            this._daoSubCategory = new DAOSubCategory(this._dBConnector);

            this._categories = _daoCategory.GetAllDictionaries();
        }

        public void SetCategoryCallBack(CategoryUpdate callback)
        {
            _callbackForCategoryCB = callback;
        }

        internal void SetSubCategoryCallBack(SubCategoryUpdate callback)
        {
            _callbackForSubCategoryCB = callback;
        }
        private void newBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cGUI.MouseDown(sender, newBtnMS);
            }

            cGUI.UploadSubCats();  
        }


        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _category = new Category();
            _addNewCategory = new AddNewCategory(_category);
            _addNewCategory.Nec = 'n';
            _addNewCategory.SetCategoryCallBack(OnCategoriesLoad);
            _addNewCategory.ShowDialog(); 
        }

        private void sottocategoriaToolStripMenuItem_Click(object sender, EventArgs e)  //nuovo
        {
            _subCategory = new SubCategory();
            
            if(catTV.SelectedNode.Parent != null)
            {
                _category = catTV.SelectedNode.Parent.Tag as Category;
            }

            else
            {
                _category = catTV.SelectedNode.Tag as Category;
            }

            _addNewSubCategory = new AddNewSubCategory(_subCategory, _category);        
            
            _addNewSubCategory.SetSubCategoryCallBack(OnCategoriesLoad);
            _addNewSubCategory.Nec = 'n';

            SetTreeViewIndex();
            _addNewSubCategory.ShowDialog();
         
            catTV.Nodes[selectedNodeIndex].ExpandAll();
            catTV.SelectedNode = catTV.Nodes[selectedNodeIndex];
        }

        private void SetTreeViewIndex()
        {
            if (catTV.SelectedNode.Parent == null)
            {
                selectedNodeIndex = catTV.SelectedNode.Index;
            }

            else
            {
                selectedNodeIndex = catTV.SelectedNode.Parent.Index;
            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            OnCategoriesLoad();
        }

        private void OnCategoriesLoad()
        {
            catTV.Nodes.Clear();  
            _categories = this._daoCategory.GetAllDictionaries();
            _subCategories = this._daoSubCategory.GetAllDictionaries(); 

            foreach (Category category in _categories.Values)
            {
                if(category.ID == 1)
                {
                    continue;
                }

                TreeNode node = new TreeNode(category.CategoryName);
                node.Tag = category;
                catTV.Nodes.Add(node);

                foreach (SubCategory subCategory in _subCategories.Values)
                {
                    if(subCategory.CategoryId == category.ID)
                    {
                        TreeNode subNode = new TreeNode(subCategory.SubCategoryName);
                        subNode.Tag = subCategory;
                        node.Nodes.Add(subNode);
                    }
                }
            }
        }

        private void editBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (catTV.SelectedNode.Parent == null)
            {
                _category = (Category)catTV.SelectedNode.Tag;
                _addNewCategory = new AddNewCategory(_category);
                _addNewCategory.Nec = 'e';
                _addNewCategory.SetCategoryCallBack(OnCategoriesLoad);
                _addNewCategory.ShowDialog();     
            }

            else
            {
                _subCategory = (SubCategory)catTV.SelectedNode.Tag;
                _category = (Category)catTV.SelectedNode.Parent.Tag;

                _addNewSubCategory = new AddNewSubCategory(_subCategory, _category);
                _addNewSubCategory.Nec = 'e';
                _addNewSubCategory.SetSubCategoryCallBack(OnCategoriesLoad);

                _addNewSubCategory.ShowDialog();  
            }

            //catTV.SelectedNode = catTV.Nodes[selectedNodeIndex];
            //catTV.Nodes[selectedNodeIndex].ExpandAll();
        }


        private void deleteBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if(catTV.SelectedNode != null)
            {

                if(catTV.SelectedNode.Parent == null) //è una categoria
                {
                    DeleteCategories();
                }

                else //è una sottocategoria
                {
                    DialogResult result = MessageBox.Show("Vuoi cancellare l'elemento selezionato?", "Conferma", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        _subCategory = catTV.SelectedNode.Tag as SubCategory;
                        _daoSubCategory.Delete(_subCategory);
                        _category = catTV.SelectedNode.Parent.Tag as Category;
                        OnCategoriesLoad();

                    }
                }
            }
        }


        private void DeleteCategories()
        {
            _category = catTV.SelectedNode.Tag as Category;

            if (catTV.SelectedNode.Nodes.Count > 0)
            {
                DialogResult result = MessageBox.Show("L'elemento selezionato ha delle sottocategorie, se cancelli la categoria verranno cancellate anche le sottocategorie", "Conferma", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    _daoSubCategory.DeleteAllSubcategories(_category);
                    _daoCategory.Delete(_category);
                    OnCategoriesLoad();
                }  
            }

            else
            {
                DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Conferma", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    _daoCategory.Delete(_category);
                    OnCategoriesLoad();
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void CategoriesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_callbackForCategoryCB != null)
            {
                _callbackForCategoryCB();
                _callbackForSubCategoryCB(_category);
            }
        }

    }
}
