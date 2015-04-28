using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace ClipboardToPng8
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (Clipboard.ContainsImage()) {
                var d = DateTime.Now;
                //var tname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                //    "ClipBoard.temp.png");
                var fname = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) , 
                    "ClipBoard." + d.ToString("yyyy.MM.dd.HH.mm.ss") + ".png");
                
                var img = Clipboard.GetImage();
                var bmp = new Bitmap(img);
                //img.Save(fname);

                var image = new  ImageMagick.MagickImage(bmp);
                //image.ColorType = ImageMagick.ColorType.Palette;
                //image.Resize(new ImageMagick.MagickImage.Geometry("50%"));
                
                image.Write("png8:" + fname);

                Console.WriteLine("Saved image as:" + Environment.NewLine + fname);
            }
            else
            {
                Console.WriteLine("Error: no image in clipboard");
            }
            Console.ReadKey();
        }
    }
}