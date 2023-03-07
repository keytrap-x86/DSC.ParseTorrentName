namespace DSC.ParseTorrentName.Tests
{
    public class ContainerTests
    {
        [Theory]
        [InlineData("Kevin Hart What Now (2016) 1080p BluRay x265 6ch -Dtech mkv", "mkv")]
        [InlineData("The Gorburger Show S01E05 AAC MP4-Mobile", "mp4")]
        [InlineData("[req]Night of the Lepus (1972) DVDRip XviD avi", "avi")]
        [InlineData("[req]Night of the Lepus (1972) DVDRip XviD", null)]
        public void DetectContainer(string title, string container)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(container, result[DefaultHandlerNames.Container]);
        }
    }
}
