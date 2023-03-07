using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class HardecodedTests
    {
        [Theory]
        [InlineData("Ghost In The Shell 2017 1080p HC HDRip X264 AC3-EVO", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectHardcoded(string title, string hardcoded)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(hardcoded, result[DefaultHandlerNames.Hardcoded]);
        }
    }
}
