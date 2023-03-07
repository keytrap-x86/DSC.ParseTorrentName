using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class CodecTests
    {
        [Theory]
        [InlineData("Nocturnal Animals 2016 VFF 1080p BluRay DTS HEVC-HD2", "hevc")]
        [InlineData("doctor_who_2005.8x12.death_in_heaven.720p_hdtv_x264-fov", "x264")]
        [InlineData("The Vet Life S02E01 Dunk-A-Doctor 1080p ANPL WEB-DL AAC2 0 H 264-RTN", "h264")]
        [InlineData("Gotham S03E17 XviD-AFG", "xvid")]
        [InlineData("Jimmy Kimmel 2017 05 03 720p HDTV DD5 1 MPEG2-CTL", "mpeg2")]
        [InlineData("Jimmy Kimmel 2017 05 03 720p HDTV DD5 1 -CTL", null)]
        public void DetectCodec(string title, string codec)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(codec, result[DefaultHandlerNames.Codec]);
        }
    }
}
