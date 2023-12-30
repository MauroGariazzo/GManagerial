using GManagerial.CustomerForm.ChildForms;
using GManagerial.CustomerMGM;
using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.AttachmentsForm
{
    class AFCommonLogic
    {
        static public void checkAttachments(Boolean AttachmentFormExist, int object_id, Char nec, List<object> attachmentRow, char formName)
        {
            if (AttachmentFormExist)
            {

                if (AttachmentForm.AttachmentsToDeleteExist)
                {
                    foreach (ListViewItem attachment in AttachmentForm.itemsToRemove)
                    {
                        if (formName == 'p')
                        {
                            AttachmentClass.DeleteFileFromDBProduct(attachment, object_id);
                        }

                        else if (formName == 'c')
                        {
                            AttachmentClass.DeleteFileFromDBCustomer(attachment, object_id);
                        }
                    }
                }


                if (AttachmentForm.TemporaryAttachments.Count > 0)
                {
                    if (nec == 'n')
                    {
                        if (formName == 'p')
                        {
                            AttachmentClass.TemporaryAttachmentsToDBProduct(nec, ProductsMGM.maxIdProduct());
                        }

                        else if (formName == 'c')
                        {
                            AttachmentClass.TemporaryAttachmentsToDBCustomer(nec, Customer.maxIdCustomer());
                        }
                    }

                    else if (nec == 'e')
                    {
                        if (formName == 'p')
                        {
                            AttachmentClass.TemporaryAttachmentsToDBProduct(nec, object_id);
                        }

                        else if (formName == 'c')
                        {
                            AttachmentClass.TemporaryAttachmentsToDBCustomer(nec, object_id);
                        }
                    }
                }

            }

            if (nec == 'c' && attachmentRow != null)
            {
                if (attachmentRow.Count > 0)
                {
                    if (formName == 'p')
                    {
                        AttachmentClass.CopiedAttachmentsToDBProduct(attachmentRow, ProductsMGM.maxIdProduct());
                    }

                    else if (formName == 'c')
                    {
                        AttachmentClass.CopiedAttachmentsToDBCustomer(attachmentRow, Customer.maxIdCustomer());
                    }
                }
            }
           
        }

        static public void resetAndCleanVars(ref Boolean AttachmentFormExist, ref int countAttachmentsAccess, List<int> attachmentsToDeleteIndex)
        {
            AttachmentFormExist = false;
            countAttachmentsAccess = 0;
            attachmentsToDeleteIndex.Clear();
            AttachmentForm.TemporaryAttachments.Clear();
            AttachmentForm.TemporaryAttachmentsFromDB.Clear();
            AttachmentForm.AttachmentsToDeleteExist = false;
        }


        
    }
}
