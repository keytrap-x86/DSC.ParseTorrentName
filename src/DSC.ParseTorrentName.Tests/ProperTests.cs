using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class ProperTests
    {
        [Theory]
        [InlineData("Into the Badlands S02E07 PROPER 720p HDTV x264-W4F", "True")]
        [InlineData("Bossi-Reality-REAL PROPER-CDM-FLAC-1999-MAHOU", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectProper(string title, string language)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(language, result[DefaultHandlerNames.Proper]);
        }
    }
}
