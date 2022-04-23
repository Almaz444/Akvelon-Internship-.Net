using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageDownload
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Downloader downloader = new Downloader();
            string url = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png";
            Console.WriteLine("Kindly type name of folder on disc 'C' in order to save image.");
            string temp = Console.ReadLine();
            try
            {
                string folderName = @"C:\"+temp;
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                await downloader.DownloadImage(url, @"c:\" + temp);
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }
    }
}
