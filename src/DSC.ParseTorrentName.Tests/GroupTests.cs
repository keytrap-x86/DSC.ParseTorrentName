namespace DSC.ParseTorrentName.Tests
{
    public class GroupTests
    {
        [Theory]
        [InlineData("Nocturnal Animals 2016 VFF 1080p BluRay DTS HEVC-HD2", "HD2")]
        [InlineData("Gold 2016 1080p BluRay DTS-HD MA 5 1 x264-HDH", "HDH")]
        [InlineData("Hercules (2014) 1080p BrRip H264 - YIFY", "YIFY")]
        [InlineData("Western - L'homme qui n'a pas d'étoile-1955.Multi.DVD9", null)]
        public void DetectGroup(string title, string group)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(group, result[DefaultHandlerNames.Group]);
        }
    }
}
