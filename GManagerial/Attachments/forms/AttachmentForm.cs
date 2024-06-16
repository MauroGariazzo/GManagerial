using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GManagerial.Attachments;
using GManagerial.DBConnectors;

namespace GManagerial
{
    internal partial class AttachmentForm : Form
    {
        private Attachment _attachment;
        private IAttachmentParent _attachmentParent; //può essere un prodotto, un cliente o un fornitore

        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        private DAOObjectAttachments _daoObjectAttachments;
        private static int _tempID = -1;  //varaiabile statica per l'id negativo degli allegati temporanei
        private int _idObj; //id prodotto, id customer, id supplier
        
        
        static public int TempID
        {
            //get { return _tempID; }
            set { _tempID = value; }
        }

        public AttachmentForm(IAttachmentParent _attachmentParent, int idObj)
        {
            InitializeComponent();
            this._attachmentParent = _attachmentParent;
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_PRODUCT, AttachmentQuery.INSERT_PRODUCT, AttachmentQuery.DELETE_PRODUCT);
            this._idObj = idObj;

            fileListView.LargeImageList = new ImageList();
            fileListView.LargeImageList.ImageSize = new Size(64, 64);
        }


        private void attachmentsPnl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))     // OK
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void attachmentsPnl_DragDrop(object sender, DragEventArgs e) //inserimento nuovi allegati
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {

                // Verifica se l'estensione del file è supportata (es. documenti e immagini)      OK
                if (IsSupportedFileExtension(Path.GetExtension(filePath).ToLower()))
                {
                    UploadFile(filePath);
                }

                else
                {
                    ShowUnsupportedFormatMessage();
                }
            }
        }


        private Attachment CreateAttachmentObj(string filePath, string extension)
        {
            Attachment attachment = new Attachment();

            //Icon fileIcon = Icon.ExtractAssociatedIcon(filePath);
            //Image image = new Bitmap(fileIcon.ToBitmap());
            System.Drawing.Icon image = Icon.ExtractAssociatedIcon(filePath);

            string fileName = Path.GetFileName(filePath);

            attachment.Path = filePath;
            attachment.Icon = image;
            attachment.Extension = extension;
            attachment.FileName = fileName;
            attachment.AttachmentObjID = _tempID; //id temporaneo per allegati che non sono ancora registrati e non sappiamo ancora se verranno registrati
            attachment.ObjectID = _idObj;
            return attachment;
        }

        private ListViewItem CreateListViewItem(string filePath)
        {
            ListViewItem item = new ListViewItem(Path.GetFileName(filePath));
            item.Tag = _tempID;

            Icon fileIcon = Icon.ExtractAssociatedIcon(filePath);
            fileListView.LargeImageList.Images.Add(fileIcon);
            item.ImageIndex = fileListView.LargeImageList.Images.Count - 1;

            return item;
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
            LoadAttachmentsFromDB();
        }


        private void LoadAttachmentsFromDB()
        {
            foreach (Attachment attachment in _attachmentParent.Attachments.Values)
            {
                ListViewItem listViewItem = new ListViewItem(attachment.FileName);

                try
                {
                    listViewItem.Tag = attachment.AttachmentObjID;
                    fileListView.Items.Add(listViewItem);

                    //Icon fileIcon = Icon.ExtractAssociatedIcon(attachment.Path);
                    Icon fileIcon = attachment.Icon;                    
                    fileListView.LargeImageList.Images.Add(fileIcon);
                    listViewItem.ImageIndex = fileListView.LargeImageList.Images.Count - 1;
                }

                catch(System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Il file è stato spostato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fileListView.LargeImageList.Images.Add(SystemIcons.Error);
                    listViewItem.ImageIndex = fileListView.LargeImageList.Images.Count - 1;
                }

                catch
                {
                    MessageBox.Show("Errore generico", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FileDelete_Click(object sender, EventArgs e)
        {
            if (fileListView.Items.Count == 0 || fileListView.SelectedIndices.Count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare gli allegati selezionati?", "Conferma cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.ListView.SelectedListViewItemCollection itemsToDelete = fileListView.SelectedItems;
                DeleteItems(itemsToDelete);
            }
        }

        private void DeleteItems(System.Windows.Forms.ListView.SelectedListViewItemCollection itemsToDelete)
        {
            foreach(ListViewItem item in itemsToDelete)
            {
                if ((int)item.Tag < 0)  //lista temporanea
                {
                    _attachmentParent.Attachments.Remove((int)item.Tag);
                    _attachmentParent.TempAttachments.Remove((int)item.Tag);
                     fileListView.Items.Remove(item);
                }

                else
                {
                    //viene dalla lista del DB
                    IAttachment attachment = _attachmentParent.Attachments[(int)item.Tag];
                    _attachmentParent.AttachmentsToDelete.Add((int)item.Tag, attachment); //aggiungi file da eliminare
                    fileListView.Items.Remove(item);    
                }

                _attachmentParent.Attachments.Remove((int)item.Tag);

            }
        }


        private void UploadFile(string filePath)
        {
            _attachment = CreateAttachmentObj(filePath, Path.GetExtension(filePath).ToLower());
            _attachmentParent.Attachments.Add(_tempID, _attachment);
            _attachmentParent.TempAttachments.Add(_tempID, _attachment);
            ListViewItem item = CreateListViewItem(filePath);
            fileListView.Items.Add(item);
            _tempID--;

        }

        private void FileUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File supportati|*.jpg;*.jpeg;*.png;*.bmp;*.doc;*.docx;*.pdf;*.txt|Tutti i file|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (IsSupportedFileExtension(Path.GetExtension(filePath).ToLower())) //OK
                {
                    UploadFile(filePath);
                }

                else
                {
                    ShowUnsupportedFormatMessage();
                }

            }

        }

        private void FileOpen_Click(object sender, EventArgs e)
        {

            if (fileListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedFileItem = fileListView.SelectedItems[0]; //OK
                int id_attachment = Convert.ToInt32(selectedFileItem.Tag);
                IAttachment attachment = _attachmentParent.Attachments[id_attachment];

                try
                {
                    OpenFile(attachment.Path);
                }

                catch (System.ComponentModel.Win32Exception)
                {
                    byte[] pdfData = attachment.FileData;

                    if (pdfData != null)
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");                        
                        File.WriteAllBytes(tempFilePath, pdfData);           
                        Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleziona prima un elemento","Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }

        private void OpenFile(string filePath)
        {
           //try
            //{
                Process.Start(filePath);
            //}
            /*catch (Exception ex)
            {
                MessageBox.Show($"Impossibile aprire il file: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }


    }
}