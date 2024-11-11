using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

internal class Program
{
    private static void Main(string[] args)
    {
        string directoryPath = @"C:\vsprog\lessons2\ExceptionsOOP2\bin\Debug\net7.0\FolderWithImage";
        string[] filePaths = Directory.GetFiles(directoryPath);
        Regex regexExtForImage = new Regex(@"(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase);

        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            if (regexExtForImage.IsMatch(Path.GetExtension(fileName)))
            {
                try
                {
                    using (Bitmap bitmap = new Bitmap(filePath))
                    {
                        var img = Image.FromFile(filePath);

                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);

                        string newFileName = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(fileName) + "-mirrored.gif");

                        bitmap.Save(newFileName, System.Drawing.Imaging.ImageFormat.Gif);
                        Console.WriteLine($"Файл створено i збережено успішно, як <<{Path.GetFileName(newFileName)}>>.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Файл {fileName} має проблеми: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Файл {fileName} не є зображенням");
            }
        }
    }
}
