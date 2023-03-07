using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class ResolutionTests
    {
        [Theory]
        [InlineData("Annabelle.2014.1080p.PROPER.HC.WEBRip.x264.AAC.2.0-RARBG", "1080p")]
        [InlineData("doctor_who_2005.8x12.death_in_heaven.720p_hdtv_x264-fov", "720p")]
        [InlineData("UFC 187 PPV 720P HDTV X264-KYR", "720p")]
        [InlineData("The Smurfs 2 2013 COMPLETE FULL BLURAY UHD (4K) - IPT EXCLUSIVE", "4k")]
        public void DetectResolution(string title, string resolution)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(resolution, result[DefaultHandlerNames.Resolution]);
        }
    }
}
