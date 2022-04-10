using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ImageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = " https://jsonplaceholder.typicode.com/photos";
            DownloadManager manager = new DownloadManager();
            JArray file = manager.DownloadFile(url);
            List<Image> images = manager.ConvertToList(file);
            manager.SaveImage(images);
        }
    }
}
