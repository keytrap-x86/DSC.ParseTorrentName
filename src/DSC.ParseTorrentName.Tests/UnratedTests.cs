namespace DSC.ParseTorrentName.Tests
{
    public class UnratedTests
    {
        [Theory]
        [InlineData("Identity.Thief.2013.Vostfr.UNRATED.BluRay.720p.DTS.x264-Nenuko", "True")]
        [InlineData("Charlie.les.filles.lui.disent.merci.2007.UNCENSORED.TRUEFRENCH.DVDRiP.AC3.Libe", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectUnrated(string title, string unrated)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(unrated, result[DefaultHandlerNames.Unrated]);
        }
    }
}
