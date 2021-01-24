using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace laba4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Directory.GetFiles(@"C:\Users\Денис\Desktop\Uni\ООП\laba4_2\files\");
            string[] names = Directory.GetFiles(@"C:\Users\Денис\Desktop\Uni\ООП\laba4_2\files\").Select(Path.GetFileName).ToArray();
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(arr[i])))
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(arr[i]);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        bitmap.Save(@"C:\Users\Денис\Desktop\Uni\ООП\laba4_2\files\" + names[i].Split('.')[0] + "-mirrored.gif", ImageFormat.Gif);
                        Console.WriteLine("New photo has been created and saved.");
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Damaged file.");
                }
            }
            Console.ReadKey();
        }
    }
}