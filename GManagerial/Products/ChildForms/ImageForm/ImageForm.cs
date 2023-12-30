using GManagerial.AttachmentsForm;
using GManagerial.CustomerForm.ChildForms;
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
    public partial class ImageForm : Form
    {
        static string pathImage;
        static public PictureBox pictureTemp = new PictureBox();
        static public Boolean delImage = false;
        private int countIconFormAccess;
        private int product_id;
          public ImageForm(int countIconFormAccess, int product_id)
          {
            InitializeComponent();
            this.countIconFormAccess = countIconFormAccess;
            this.product_id = product_id;
          }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            //FormLogicGUI.ActDea(MessageLbl, true);
            //pictureBox = ImageMGM.LoadImage();
            LoadImage();
        }


        private void LoadImage() 
        {
            if(countIconFormAccess == 1)
            {
                ImageMGM.LoadImage(pictureBox, product_id, pictureTemp);
                checkNullImage();
            }

            else
            {
                pictureBox.Image = pictureTemp.Image;
                checkNullImage();
            }
        }


        private void checkNullImage()
        {
            if (pictureBox.Image != null)
            {
                FormLogicGUI.ActDea(MessageLbl, false);
            }
        }

        private void ImageForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                pathImage = files[0]; // Prendi il percorso del primo file trascinato

                try
                {
                    UploadImage(pathImage);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Errore nel caricamento dell'immagine: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void UploadImage(string imagePath)
        {
            if (IsImageFile(imagePath))
            {
                pictureTemp.Image = Image.FromFile(imagePath);
                pictureTemp.SizeMode = PictureBoxSizeMode.Zoom; // Imposta il PictureBoxSizeMode su Zoom
                pictureBox.Image = pictureTemp.Image;
                FormLogicGUI.ActDea(MessageLbl, false);

                //ImageMGM.InsertImageToDB(imagePath, object_id);
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

        private bool IsImageFile(string filePath)
        {
            try
            {
                using (Image image = Image.FromFile(filePath))
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
                DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare l'immagine?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) 
                { 
                    this.pictureBox.Image = null;
                    pictureTemp.Image = null;
                    FormLogicGUI.ActDea(MessageLbl, true);
                    delImage = true;
                    //ImageMGM.deleteImage(product_id);
                }
            }
              
        }


        static public string GetPath()
        {
            return pathImage;
        }
    }
}
