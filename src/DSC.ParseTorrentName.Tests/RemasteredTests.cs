using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class RemasteredTests
    {
        [Theory]
        [InlineData("The Fifth Element 1997 REMASTERED MULTi 1080p BluRay HDLight AC3 x264 Zone80", "True")]
        [InlineData("Predator 1987 REMASTER MULTi 1080p BluRay x264 FiDELiO", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectRemastered(string title, string remastered)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(remastered, result[DefaultHandlerNames.Remastered]);
        }
    }
}
