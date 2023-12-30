using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    class IFCommonLogic
    {
        static public void resetAndClean(ref int countIconForm)
        {
            countIconForm = 0;
            ImageForm.pictureTemp = new PictureBox();
            ImageForm.delImage = false;
        }

        static public void checkImage(char nec, int Product_ID)
        {
            if (nec == 'n' || nec == 'c')
            {
                if(ImageForm.pictureTemp.Image != null)
                {
                    ImageMGM.InsertImageToDB(ImageForm.GetPath(), ProductsMGM.maxIdProduct());
                }
               
            }

            else if(nec != 'n' || nec != 'c')
            {
                if (ImageForm.pictureTemp.Image != null)
                {
                    ImageMGM.InsertImageToDB(ImageForm.GetPath(), Product_ID);
                }
            }
        }
    }
}
