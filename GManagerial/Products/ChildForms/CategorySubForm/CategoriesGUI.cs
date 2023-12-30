using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    class CategoriesGUI
    {
        private TreeView catTV;
        private ToolStripMenuItem subcategoryToolStripMenuItem;
        public CategoriesGUI(TreeView catTV, ToolStripMenuItem subcategoryToolStripMenuItem)
        { 
            this.catTV = catTV;
            this.subcategoryToolStripMenuItem = subcategoryToolStripMenuItem;
        }

        public void MouseDown(object sender, ContextMenuStrip newBtnMS)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
            {
                Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)


                buttonLocationOnParentControl.Y += button.Height;

                newBtnMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
            }
        }

        public void UploadSubCats()
        {
            if (catTV.SelectedNode != null && catTV.SelectedNode.Parent == null)
            {
                subcategoryToolStripMenuItem.Text = "Sottocategoria di " + catTV.SelectedNode.Text;
                subcategoryToolStripMenuItem.Enabled = true;
                subcategoryToolStripMenuItem.ForeColor = Color.Black;
            }

            else
            {
                if (catTV.SelectedNode != null && catTV.SelectedNode.Parent != null)
                {
                    subcategoryToolStripMenuItem.Text = "Sottocategoria di " + catTV.SelectedNode.Parent.Text;
                    subcategoryToolStripMenuItem.Enabled = true;
                    subcategoryToolStripMenuItem.ForeColor = Color.Black;
                }


                else
                {
                    subcategoryToolStripMenuItem.Enabled = false;
                    subcategoryToolStripMenuItem.ForeColor = Color.Gray;
                }
            }
        }

    }
}
