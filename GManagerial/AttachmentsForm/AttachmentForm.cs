using GManagerial.AttachmentsForm;
using GManagerial.CustomerForm.ChildForms;
using GManagerial.CustomerMGM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial
{
    public partial class AttachmentForm : Form
    {
        static public List<ListViewItem> itemsToRemove = new List<ListViewItem>();

        private int countAttachmentsAccess;
        public int id_object;
        static public Boolean AttachmentsToDeleteExist = false;
        static public List<ListViewItem> TemporaryAttachments = new List<ListViewItem> { };
        static public List<ListViewItem> TemporaryAttachmentsFromDB = new List<ListViewItem> { };
        private char menuName;

        private string path;
        private int attachmentId;
        public AttachmentForm(int id_object, int countAttachmentsAccess, char menuName)
        {
            InitializeComponent();
            this.fileListView.LargeImageList = new ImageList();
            this.fileListView.LargeImageList.ImageSize = new Size(64, 64);
            this.id_object = id_object;
            this.countAttachmentsAccess = countAttachmentsAccess;
            this.menuName = menuName;
        }


        private void attachmentsPnl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))     // OK
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void attachmentsPnl_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();

                // Verifica se l'estensione del file è supportata (es. documenti e immagini)      OK
                if (IsSupportedFileExtension(extension))
                {
                    AttachmentGUI.AddIconsToListView(file, -1, fileListView);
                    AddItemToTemporaryAttachments(file, -1);
                }
                else
                {
                    ShowUnsupportedFormatMessage();
                }
            }
        }


        private bool IsSupportedFileExtension(string extension)
        {
            // Elenco delle estensioni di file supportate (documenti e immagini)
            string[] supportedExtensions = { ".doc", ".docx", ".pdf", ".txt", ".jpg", ".jpeg", ".png", ".bmp" };

            // Verifica se l'estensione del file è presente nell'elenco delle estensioni supportate                     ATTACHMENTSCLASS
            return supportedExtensions.Contains(extension);
        }

        private void ShowUnsupportedFormatMessage()
        {
            MessageBox.Show("Formato non supportato. Si prega di caricare solo documenti o immagini.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddItemToTemporaryAttachments(string file, int attachmentId)  //aggiunge il file alla lista temporary attachments che sono quelli caricati al momento
        {
            ListViewItem listItem = new ListViewItem(Path.GetFileName(file));
            listItem.ImageIndex = fileListView.LargeImageList.Images.Count - 1;     //ATTACHMENTSCLASS

            Tag tag = new Tag();
            tag.FilePath = file;
            tag.IdAttachment = attachmentId;
            listItem.Tag = tag;
            TemporaryAttachments.Add(listItem);
        }
        

        private void attachmentsPnl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move; // Impostazione dell'effetto di spostamento
            }
        }

        private void attachmentsPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float width = (float)1.0;
            Pen pen = new Pen(SystemColors.GrayText, width);
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }

        private void AttachmentForm_Load(object sender, EventArgs e)
        {
            LoadAttachments();
        }


        private void LoadAttachments()
        {
            if (countAttachmentsAccess == 1)
            {
                if (this.menuName == 'c')
                {
                    AttachmentClass.LoadCustAttFromDB(id_object, fileListView, ref path, ref attachmentId, TemporaryAttachmentsFromDB);
                }

                else if (this.menuName == 'p')
                {
                    AttachmentClass.LoadProdAttFromDB(id_object, fileListView, ref path, ref attachmentId, TemporaryAttachmentsFromDB);
                }
            }

            else
            {
                if (countAttachmentsAccess > 1 && id_object != -1)
                {
                    AttachmentGUI.LoadIconsFromTemporaryAttachmentsFromDB(TemporaryAttachmentsFromDB, fileListView);
                    LoadIconsFromTemporaryAttachments();
                }


                else
                {
                    LoadIconsFromTemporaryAttachments();
                }
            }
        }


        private void LoadIconsFromTemporaryAttachments()
        {
            foreach (ListViewItem item in TemporaryAttachments)
            {
                if (item.Tag is Tag tag)
                {
                    try
                    {
                        string filePath = tag.FilePath;
                        Icon fileIcon = Icon.ExtractAssociatedIcon(filePath);
                        fileListView.LargeImageList.Images.Add(fileIcon);
                    }
                    catch
                    {
                        Icon errorIcon = SystemIcons.Error;
                        fileListView.LargeImageList.Images.Add(errorIcon);
                    }

                    int imageIndex = fileListView.LargeImageList.Images.Count - 1;
                    ListViewItem listViewItem = new ListViewItem(item.Text);
                    listViewItem.ImageIndex = imageIndex;
                    listViewItem.Tag = tag;
                    fileListView.Items.Add(listViewItem);
                }
            }
        }

        private void FileDelete_Click(object sender, EventArgs e)
        {
            AttachmentsToDeleteExist = true;
            if (fileListView.Items.Count == 0 || fileListView.SelectedIndices.Count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare gli allegati selezionati?", "Conferma cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteItemsFromTemporaryAttachments();
                DeleteItemsFromTemporaryAttachmentsFromDB();
                DeleteFromListView();
            }
        }

        private void DeleteFromListView()
        {
            foreach (ListViewItem item in fileListView.SelectedItems)
            {
                itemsToRemove.Add(item);
            }

            foreach (ListViewItem item in itemsToRemove)
            {
                fileListView.Items.Remove(item);
            }
        }

        public void DeleteItemsFromTemporaryAttachments()
        {
            List<ListViewItem> temporaryAttachmentsCopy = new List<ListViewItem>(TemporaryAttachments);
            int skipped = 0;

            foreach (ListViewItem clickedItem in fileListView.SelectedItems)
            {
                if (clickedItem.Tag is Tag tag)
                {
                    if (tag.IdAttachment == -1)
                    {

                        int numOfDbItems = fileListView.Items.Count - TemporaryAttachments.Count;      //ATTACHMENTSCLASS
                        int clickedIndex = fileListView.SelectedIndices[0];

                        temporaryAttachmentsCopy.RemoveAt(clickedIndex - numOfDbItems + skipped);
                    }

                    else
                    {
                        skipped += 1;
                    }
                }
            }
            TemporaryAttachments = temporaryAttachmentsCopy;
        }


        public void DeleteItemsFromTemporaryAttachmentsFromDB()
        {

            List<ListViewItem> temporaryAttachmentsCopy = new List<ListViewItem>(TemporaryAttachmentsFromDB);

            foreach (ListViewItem clickedItem in fileListView.SelectedItems)
            {
                if (clickedItem.Tag is Tag tag)                                 //ATTACHMENTSCLASS
                {
                    if (tag.IdAttachment != -1)
                    {
                        int clickedIndex = fileListView.SelectedIndices[0];

                        temporaryAttachmentsCopy.RemoveAt(clickedIndex);
                    }
                }
            }
            TemporaryAttachmentsFromDB = temporaryAttachmentsCopy;
        }


        private void FileUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File supportati|*.jpg;*.jpeg;*.png;*.bmp;*.doc;*.docx;*.pdf;*.txt|Tutti i file|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;

                if (IsSupportedFileExtension(Path.GetExtension(file).ToLower())) //OK
                {
                    AttachmentGUI.AddIconsToListView(file, -1, fileListView);
                    AddItemToTemporaryAttachments(file, -1);
                }

                else
                {
                    ShowUnsupportedFormatMessage();
                }

            }

        }


        static public void TemporaryAttachmentsToDBProduct(char nec, int id_object)  //-> funzione per inserire gli allegati del prodotto
        {
            AttachmentClass.TemporaryAttachmentsToDBProduct(nec, id_object);  //da cancellare
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {

            if (fileListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedFileItem = fileListView.SelectedItems[0]; //OK
                Tag tag = selectedFileItem.Tag as Tag;
                OpenFile(tag.FilePath);
                
            }
            else
            {
                return;
            }
        }

        private void OpenFile(string filePath)
        {
            try
            {
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossibile aprire il file: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}