namespace DSC.ParseTorrentName.Tests
{
    public class YearTests
    {
        [Theory]
        [InlineData("Dawn.of.the.Planet.of.the.Apes.2014.HDRip.XViD-EVO", "2014")]
        [InlineData("Hercules (2014) 1080p BrRip H264 - YIFY", "2014")]
        [InlineData("One Shot [2014] DVDRip XViD-ViCKY", "2014")]
        [InlineData("2012 2009 1080p BluRay x264 REPACK-METiS", "2009")]
        public void DetectYear(string title, string year)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(year, result[DefaultHandlerNames.Year]);
        }
    }
}
