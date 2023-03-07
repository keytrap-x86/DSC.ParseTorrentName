namespace DSC.ParseTorrentName.Tests
{
    public class TitleTests
    {
        [Theory]
        [InlineData("La famille bélier", "La famille bélier")]
        [InlineData("La.famille.bélier", "La famille bélier")]
        [InlineData("Mr. Nobody", "Mr. Nobody")]
        [InlineData("doctor_who_2005.8x12.death_in_heaven.720p_hdtv_x264-fov", "doctor who")]
        public void DetectTitle(string title, string expectedTitle)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(expectedTitle, result[DefaultHandlerNames.Title]);
        }
    }
}
