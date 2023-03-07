using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class ExtendedTests
    {
        [Theory]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", "True")]
        [InlineData("Better.Call.Saul.S03E04.CONVERT.720p.WEB.h264-TBS", null)]
        public void DetectExtended(string title, string extended)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(extended, result[DefaultHandlerNames.Extended]);
        }
    }
}
