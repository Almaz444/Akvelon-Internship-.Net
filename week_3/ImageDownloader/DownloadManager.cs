using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace ImageDownloader
{
    public class DownloadManager
    {
        public JArray DownloadFile(string url)
        {
            JArray jArray = new JArray();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Console.WriteLine("Downloading of file is started.");
                    var jsonFile = webClient.DownloadString(url);
                    return jArray = JArray.Parse(jsonFile);
                }
                catch (WebException webException)
                {
                    Console.Write("There is web error: " + webException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("There is error: " + exception.Message);
                }
            }
            return jArray;
        }
        
        public List<Image> ConvertToList(JArray jArray)
        {
            List<Image> images = new List<Image>();
            if (jArray.Count > 0)
            {
                images = (jArray).Select(x => new Image
                {
                    AlbumId = (string)x["albumId"],
                    Id = (string)x["id"],
                    Title = (string)x["title"],
                    Url = (string)x["url"],
                    ThumbnailUrl = (string)x["thumbnailUrl"]
                }).ToList();
            }
            return images;
        }
       
        public void SaveImage(List<Image> images)
        {
            foreach (var image in images)
            {
                Thread thread = new Thread(() => Save(image));
                thread.Start();
            }
            Console.WriteLine("Downloading is completed. ");
        }
        private void Save(Image image)
        {
            Console.WriteLine("Downloading of image is started.");
            string thumbnailUrl = image.Url;
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(thumbnailUrl, image.Id + ".png");
            }
            catch (WebException webException)
            {
                Console.Write("There is web error: " + webException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("There is error: " + exception.Message);
            }
            
        }
    }
}
