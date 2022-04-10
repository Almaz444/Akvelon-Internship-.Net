using ImageDownloader;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace ImageDownloaderTests
{
    public class DownloaderManagerTest
    {
        [Fact]
        public void DownloadFile_WhenCallMethod_ReturnJArray()
        {
            // arrange
            string url = " https://jsonplaceholder.typicode.com/photos";
            DownloadManager manager = new DownloadManager();
            JArray result = manager.DownloadFile(url);
            // act
            JArray action = manager.DownloadFile(url);
            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void DownloadFile_WhenPassFalseArgument_ReturnCountZero()
        {
            // arrange
            string url = "test";
            DownloadManager manager = new DownloadManager();
            JArray jArray = manager.DownloadFile(url);
            int result = 0;
            // act
            JArray actionArray = manager.DownloadFile(url);
            int action = actionArray.Count;
            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void ConvertToList_WhenCallMethod_ReturnSameCount()
        {
            // arrange
            string url = " https://jsonplaceholder.typicode.com/photos";
            DownloadManager manager = new DownloadManager();
            JArray array = manager.DownloadFile(url);
            List<Image> images = manager.ConvertToList(array);
            int result = images.Count;
            // act
            List<Image> actionImages = manager.ConvertToList(array);
            int action = actionImages.Count;
            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void ConvertToList_WhenPassEmptyJArray_ReturnZeroCount()
        {
            // arrange
            DownloadManager manager = new DownloadManager();
            JArray array = new JArray();
            List<Image> images = manager.ConvertToList(array);
            int result = 0;
            // act
            List<Image> actionImages = manager.ConvertToList(array);
            int action = actionImages.Count;
            // assert
            Assert.Equal(result, action);
        }
    }
}
