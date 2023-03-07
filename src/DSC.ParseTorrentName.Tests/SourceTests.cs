using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class SourceTests
    {
        [Theory]
        [InlineData("Nocturnal Animals 2016 VFF 1080p BluRay DTS HEVC-HD2", "bluray")]
        [InlineData("doctor_who_2005.8x12.death_in_heaven.720p_hdtv_x264-fov", "hdtv")]
        [InlineData("A Stable Life S01E01 DVDRip x264-Ltu", "dvdrip")]
        [InlineData("The Vet Life S02E01 Dunk-A-Doctor 1080p ANPL WEB-DL AAC2 0 H 264-RTN", "web-dl")]
        [InlineData("Brown Nation S01E05 1080p WEBRip x264-JAWN", "webrip")]
        [InlineData("Star Wars The Last Jedi 2017 TeleSync AAC x264-MiniMe", "telesync")]
        [InlineData("The.Shape.of.Water.2017.DVDScr.XVID.AC3.HQ.Hive-CM8", "dvdscr")]
        [InlineData("Cloudy With A Chance Of Meatballs 2 2013 720p PPVRip x264 AAC-FooKaS", "ppvrip")]
        [InlineData("The.OA.1x08.L.Io.Invisibile.ITA.WEBMux.x264-UBi.mkv", "webmux")]
        public void DetectSource(string title, string source)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(source, result[DefaultHandlerNames.Source]);
        }
    }
}
