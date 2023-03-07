namespace DSC.ParseTorrentName.Tests
{
    public class RetailTests
    {
        [Theory]
        [InlineData("MONSTER HIGH: ELECTRIFIED (2017) Retail PAL DVD9 [EAGLE]", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectResolution(string title, string retail)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(retail, result[DefaultHandlerNames.Retail]);
        }
    }
}
