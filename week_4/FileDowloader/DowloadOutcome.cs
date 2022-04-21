using System;

namespace FileDowloader
{
    public class DowloadOutcome
    {
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public TimeSpan TimeSpend { get; set; }
        public int ParallelDownloads { get; set; }

    }
}
