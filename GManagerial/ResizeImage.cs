using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GManagerial
{
  
        public static class CustomButton
        {
            public static Image ResizeImage(Image originalImage)            
            {
                int newWidth = 35;
                int newHeight = 35;

                Image resizedImage = new Bitmap(originalImage, newWidth, newHeight);

                return resizedImage;
            }


            public static Image ResizeIcons(Image originalIcon)
            {
                int newWidth = 30;
                int newHeight = 30;

                Image resizedIcon = new Bitmap(originalIcon, newWidth, newHeight);

                return resizedIcon;
            }

        }

}
