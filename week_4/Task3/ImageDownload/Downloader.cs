using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImageDownload
{   
    public class Downloader
    {
        public async Task DownloadImage(string url, string destinationFolder)
        {
            try
            {
                Uri uri = new Uri(url);
                string destinationFilePath = Path.Combine(destinationFolder, uri.Segments.Last());
                if (File.Exists(destinationFilePath))
                {
                    File.Delete(destinationFilePath);
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(url);
                    File.WriteAllBytes(destinationFilePath, fileBytes);
                    Console.WriteLine("Download is completed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to download File: " + e.Message);
            }
        }
    }
}
