namespace DSC.ParseTorrentName.Tests
{
    public class RepackTests
    {
        [Theory]
        [InlineData("Silicon Valley S04E03 REPACK HDTV x264-SVA", "True")]
        [InlineData("Expedition Unknown S03E14 Corsicas Nazi Treasure RERIP 720p HDTV x264-W4F", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectRepack(string title, string repacked)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(repacked, result[DefaultHandlerNames.Repack]);
        }
    }
}
