using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    internal partial class ImageForm : Form
    {
        static string pathImage;
        static public PictureBox pictureTemp = new PictureBox();
        static public Boolean delImage = false;

        private IProduct _product;

          public ImageForm(IProduct product)
          {

            InitializeComponent();
            this._product = product;
          }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            LoadImage();
        }


        private void LoadImage() 
        {
            if(_product.ResizedImage != null)
            { 
                pictureBox.Image = _product.Image;
                MessageLbl.Visible = false;
            }
        }


        private void ImageForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                _product.ResizedImage = Image.FromFile(files[0]);

                try
                {
                    UploadImage(files[0]);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Errore nel caricamento dell'immagine: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void UploadImage(string fileName)
        {
            if (IsImageFile(fileName))
            {
                _product.ResizedImage = Image.FromFile(fileName); //-->
                _product.ResizedImage.Tag = fileName;
                _product.Image = Image.FromFile(fileName); //-->
                _product.Image.Tag = fileName; //-->

                MessageLbl.Visible = false;
                pictureBox.Image = _product.ResizedImage;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            }

            else
            {
                ShowUnsupportedFormatMessage();
            }
        }


        private void ShowUnsupportedFormatMessage()
        {
            MessageBox.Show("Formato non supportato. Si prega di caricare solo immagini.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsImageFile(string fileName)
        {
            try
            {
                using (Image image = Image.FromFile(fileName))
                {
                    if (image.RawFormat.Equals(ImageFormat.Jpeg) || image.RawFormat.Equals(ImageFormat.Png) || image.RawFormat.Equals(ImageFormat.Bmp))
                    {
                        return true;
                    }
                }
            }

            catch
            {
                return false;
            }

            return false;
        }

        private void ImageForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File supportati|*.jpg;*.jpeg;*.png;*.bmp;|Tutti i file|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;

                if (IsImageFile(pathImage)) //OK
                {
                    UploadImage(pathImage);
                }

                else
                {
                    ShowUnsupportedFormatMessage();
                }

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare l'immagine?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _product.Image = null;
                    _product.ResizedImage = null;
                    pictureBox.Image = null;
                    MessageLbl.Visible = true;
                }
            }
        }


        static public string GetPath()
        {
            return pathImage;
        }
    }
}
