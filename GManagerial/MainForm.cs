using GManagerial.Products;
using GManagerial.Products.ChildForms;
using GManagerial.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GManagerial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Home.Image = CustomButton.ResizeImage(Home.Image);
            Warehouse.Image = CustomButton.ResizeImage(Warehouse.Image);
            Customers.Image = CustomButton.ResizeImage(Customers.Image);
            Exit.Image = CustomButton.ResizeImage(Exit.Image);
            Docs.Image = CustomButton.ResizeImage(Docs.Image);
            productsBtn.Image = CustomButton.ResizeImage(productsBtn.Image);
            SuppliersBtn.Image = CustomButton.ResizeImage(SuppliersBtn.Image);

            Screen currentScreen = Screen.FromControl(this); 
            this.Size = currentScreen.WorkingArea.Size; 

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Home_Click(sender, e);
        }

        private void Home_Click(object sender, EventArgs e)
        {
            //this.MenuName.Text = Home.Text;

        }

        /*private void OpenChildForm(Form ChildForm)
        {
            if (this.panelDesktop.Controls.Count > 0)
            {
                this.panelDesktop.Controls.RemoveAt(0);
            }

            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(ChildForm);
            ChildForm.Show();
        }*/

        private void Customers_Click(object sender, EventArgs e)
        {
            ChildFormLogic.ChildFormLogic.OpenChildForm(new CustomersForm(), this.panelDesktop);
        }



        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Docs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripButton button = sender as ToolStripButton;
                if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
                {
                    Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                    Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)


                    buttonLocationOnParentControl.Y += button.Height;

                    docsMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        private void preventiviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFormLogic.ChildFormLogic.OpenChildForm(new QuoteDoc(), this.panelDesktop);
        }

        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            ChildFormLogic.ChildFormLogic.OpenChildForm(new SupplierForm(), this.panelDesktop);

        }


        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            Screen currentScreen = Screen.FromControl(this);
            this.Size = currentScreen.WorkingArea.Size;
        }

        private void productsBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripButton button = sender as ToolStripButton;
                if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
                {
                    Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                    Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)


                    buttonLocationOnParentControl.Y += button.Height;

                    productCMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        private void productsItem_Click(object sender, EventArgs e)
        {
            ChildFormLogic.ChildFormLogic.OpenChildForm(new ProductsForm(), this.panelDesktop);
        }

        private void categorieSottocategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm categories = new CategoriesForm();
            categories.ShowDialog();
        }

        private void BrandItem_Click(object sender, EventArgs e)
        {
            BrandForm brands = new BrandForm();
            brands.ShowDialog();
        }

        private void Warehouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripButton button = sender as ToolStripButton;
                if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
                {
                    Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                    Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)


                    buttonLocationOnParentControl.Y += button.Height;

                    whCMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        private void WHsitItem_Click(object sender, EventArgs e)
        {
            ChildFormLogic.ChildFormLogic.OpenChildForm(new Warehouse(), this.panelDesktop);
        }
    }
}
