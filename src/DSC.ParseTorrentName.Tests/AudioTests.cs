using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class AudioTests
    {
        [Theory]
        [InlineData("Nocturnal Animals 2016 VFF 1080p BluRay DTS HEVC-HD2", "dts")]
        [InlineData("Gold 2016 1080p BluRay DTS-HD MA 5 1 x264-HDH", "dts-hd")]
        [InlineData("The Vet Life S02E01 Dunk-A-Doctor 1080p ANPL WEB-DL AAC2 0 H 264-RTN", "aac")]
        [InlineData("Jimmy Kimmel 2017 05 03 720p HDTV DD5 1 MPEG2-CTL", "dd5.1")]
        [InlineData("A Dog's Purpose 2016 BDRip 720p X265 Ac3-GANJAMAN", "ac3")]
        [InlineData("Retroactive 1997 BluRay 1080p AC-3 HEVC-d3g", "ac3")]
        [InlineData("Tempete 2016-TrueFRENCH-TVrip-H264-mp3", "mp3")]
        [InlineData("Detroit.2017.BDRip.MD.GERMAN.x264-SPECTRE", "md")]
        [InlineData("Detroit.2017.BDRip..GERMAN.x264-SPECTRE", null)]
        public void DetectAudio(string title, string audio)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(audio, result[DefaultHandlerNames.Audio]);
        }
    }
}
