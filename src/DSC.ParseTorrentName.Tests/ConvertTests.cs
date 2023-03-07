namespace DSC.ParseTorrentName.Tests
{
    public class ConvertTests
    {
        [Theory]
        [InlineData("Better.Call.Saul.S03E04.CONVERT.720p.WEB.h264-TBS", "True")]
        [InlineData("Have I Got News For You S53E02 EXTENDED 720p HDTV x264-QPEL", null)]
        public void DetectConvert(string title, string convert)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(convert, result[DefaultHandlerNames.Convert]);
        }
    }
}
