using System;

namespace FileDowloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png";
            Downloader downloader = new Downloader();
            var result = downloader.Download(url,4 );
            Console.Write("Performing some task... ");
            Console.WriteLine($"Location: {result.FilePath}");
            Console.WriteLine($"Size: {result.FileSize} bytes");
            Console.WriteLine($"Time taken: {result.TimeSpend.Milliseconds} ms");
            Console.WriteLine($"Parallel: {result.ParallelDownloads}");
            Console.WriteLine("Done.");

        }

    }
}
