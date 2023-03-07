namespace DSC.ParseTorrentName.Tests
{
    public class SeasonTests
    {
        [Theory]
        [InlineData("The Simpsons S28E21 720p HDTV x264-AVS", "28")]
        [InlineData("breaking.bad.s01e01.720p.bluray.x264-reward", "1")]
        [InlineData("Dragon Ball Super S01 E23 French 1080p HDTV H264-Kesni", "1")]
        [InlineData("Doctor.Who.2005.8x11.Dark.Water.720p.HDTV.x264-FoV", "8")]
        [InlineData(" Orange Is The New Black Season 5 Episodes 1-10 INCOMPLETE (LEAKED)", "5")]
        public void DetectSeason(string title, string season)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(season, result[DefaultHandlerNames.Season]);
        }
    }
}
