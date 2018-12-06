using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CAS2018.myUtilities.Media
{
    public static class Images
    {
        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                System.Windows.Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }

        public static ImageSource ToImageSource(Bitmap bitmap)
        {
            BitmapSource bitmapsource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap
                (
                    bitmap.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );
            return bitmapsource;
        }
    }
}
