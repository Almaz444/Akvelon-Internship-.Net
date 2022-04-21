using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileDowloader
{
    public  class Downloader
    {
        public  DowloadOutcome Download(string url, int numberOfParallelDownloads = 0, bool validateSSL = false)
        {
            if (!validateSSL)
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }
            Uri uri = new Uri(url);
            string destinationFilePath = GetSolutionFSPath() + @"\Files\" + uri.Segments.Last();
            if (numberOfParallelDownloads <= 0)
            {
                numberOfParallelDownloads = Environment.ProcessorCount;
            }
            long fileSize = GetFileSize(url);
            DowloadOutcome outcome = new DowloadOutcome();
            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append))
            {
                ConcurrentDictionary<int, string> tempFilesDictionary = new ConcurrentDictionary<int, string>();
                //calculate the size of chunks based on desired number of parallel downloads
                List<Range> listOfChunks = CalculateChunkSize(fileSize, numberOfParallelDownloads);
                DateTime timeStart = DateTime.Now;
                int parallelCount = 0;
                //initiate download of each chunk in parallel and save to a separate file
                Parallel.ForEach(listOfChunks, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads }, readRange =>
                {
                    HttpWebRequest httpWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.AddRange(readRange.Start, readRange.End);
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            httpWebResponse.GetResponseStream().CopyTo(fileStream);
                            tempFilesDictionary.TryAdd(readRange.Id, tempFilePath);
                        }
                    }
                    parallelCount++;
                });
                outcome.FileSize = fileSize;
                outcome.FilePath = destinationFilePath;
                outcome.ParallelDownloads = parallelCount;
                outcome.TimeSpend= DateTime.Now.Subtract(timeStart);
                foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
                {
                    byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                    destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                    File.Delete(tempFile.Value);
                }
                return outcome;
            }
        }
        protected static string GetSolutionFSPath()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
        private static long GetFileSize(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "HEAD";
            long result = -1;
            using (WebResponse resp = request.GetResponse())
            {
                if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
                {
                    result = ContentLength;
                }
            }
            return result;
        }
        private static List<Range> CalculateChunkSize(long fileSize, int parallelCount)
        {
            List<Range> ranges = new List<Range>();
            int index = 1;
            for (int chunk = 0; chunk < parallelCount - 1; chunk++)
            {
                var range = new Range()
                {
                    Id = index,
                    Start = chunk * (fileSize / parallelCount),
                    End = ((chunk + 1) * (fileSize / parallelCount)) - 1,
                    SubFileName = "Part_" + index
                };
                ranges.Add(range);
                index++;
            }
            ranges.Add(new Range()
            {
                Id = index,
                Start = ranges.Any() ? ranges.Last().End + 1 : 0,
                End = fileSize - 1,
                SubFileName = "Part_Last"
            });
            return ranges;
        }
    }
}
