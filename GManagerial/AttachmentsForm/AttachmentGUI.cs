using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.AttachmentsForm
{
     class AttachmentGUI
    {
        static public void AddIconsToListView(string file, int attachmentId, System.Windows.Forms.ListView fileListView) //AGGIUNGE l'icona nella listview
        {
            try
            {
                Icon fileIcon = Icon.ExtractAssociatedIcon(file);
                fileListView.LargeImageList.Images.Add(fileIcon);

                ListViewItem listItem = new ListViewItem(Path.GetFileName(file));
                listItem.ImageIndex = fileListView.LargeImageList.Images.Count - 1;

                Tag tag = new Tag();
                tag.FilePath = file;
                tag.IdAttachment = attachmentId;
                listItem.Tag = tag;

                fileListView.Items.Add(listItem);
            }

            catch (Exception)
            {
                Icon errorIcon = SystemIcons.Error;
                fileListView.LargeImageList.Images.Add(errorIcon);

                ListViewItem errorItem = new ListViewItem(Path.GetFileName(file));
                errorItem.ImageIndex = fileListView.LargeImageList.Images.Count - 1;

                Tag tag = new Tag();
                tag.FilePath = file;
                tag.IdAttachment = attachmentId;
                errorItem.Tag = tag;

                fileListView.Items.Add(errorItem);
            }
        }

        static public void LoadIconsFromTemporaryAttachmentsFromDB(List<ListViewItem> TemporaryAttachmentsFromDB, ListView fileListView)
        {
            /*ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(64, 64);

            foreach (ListViewItem item in TemporaryAttachmentsFromDB)
            {
                if (item.Tag is Tag tag)
                {
                    string filePath = tag.FilePath;

                    Icon fileIcon;
                    try
                    {
                        fileIcon = Icon.ExtractAssociatedIcon(filePath);
                    }
                    catch (Exception)
                    {
                        // L'icona non può essere estratta, quindi utilizziamo un'icona di errore
                        fileIcon = SystemIcons.Error;
                    }

                    imageList.Images.Add(fileIcon);

                    ListViewItem listViewItem = new ListViewItem(item.Text);
                    listViewItem.Tag = tag;
                    listViewItem.ImageIndex = imageList.Images.Count - 1;

                    fileListView.Items.Add(listViewItem);
                }

                fileListView.LargeImageList = imageList;
            }*/

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(64, 64);

            foreach (ListViewItem item in TemporaryAttachmentsFromDB)
            {
                if (item.Tag is Tag tag)
                {
                    string filePath = tag.FilePath;

                    Icon fileIcon;

                    if(tag.fileIcon == null)
                    {
                        fileIcon = SystemIcons.Error;
                    }

                    else
                    {
                        fileIcon = tag.fileIcon;
                    }

                    imageList.Images.Add(fileIcon);

                    ListViewItem listViewItem = new ListViewItem(item.Text);
                    listViewItem.Tag = tag;
                    listViewItem.ImageIndex = imageList.Images.Count - 1;

                    fileListView.Items.Add(listViewItem);
                }

                fileListView.LargeImageList = imageList;
            }
        }

        public static void AddItemToTemporaryAttachmentsFromDB(Tag tag, List<ListViewItem> TemporaryAttachmentsFromDB)
        {
            ListViewItem listItem = new ListViewItem(Path.GetFileName(tag.FilePath));
            listItem.ImageIndex = 0; // Inserisci l'indice corretto in base alle tue esigenze effettive

            listItem.Tag = tag;
            TemporaryAttachmentsFromDB.Add(listItem);
        }
    }

    
}
