using Xunit;

namespace DSC.ParseTorrentName.Tests
{
    public class MainTests
    {
        [Fact]
        public void SonsOfAnarchy()
        {
            string title = "sons.of.anarchy.s05e10.480p.BluRay.x264-GAnGSteR";

            var result = Parser.Default.Parse(title);
            Assert.Equal("sons of anarchy", result[DefaultHandlerNames.Title]);
            Assert.Equal("480p", result[DefaultHandlerNames.Resolution]);
            Assert.Equal("5", result[DefaultHandlerNames.Season]);
            Assert.Equal("10", result[DefaultHandlerNames.Episode]);
            Assert.Equal("bluray", result[DefaultHandlerNames.Source]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
            Assert.Equal("GAnGSteR", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void ColorOfNight()
        {
            string title = "Color.Of.Night.Unrated.DC.VostFR.BRrip.x264";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Color Of Night", result[DefaultHandlerNames.Title]);
            Assert.Equal("True", result[DefaultHandlerNames.Unrated]);
            Assert.Equal("vostfr", result[DefaultHandlerNames.Language]);
            Assert.Equal("brrip", result[DefaultHandlerNames.Source]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
        }

        [Fact]
        public void DaVinciCode()
        {
            string title = "Da Vinci Code DVDRip";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Da Vinci Code", result[DefaultHandlerNames.Title]);
            Assert.Equal("dvdrip", result[DefaultHandlerNames.Source]);
        }

        [Fact]
        public void SomeGirls()
        {
            string title = "Some.girls.1998.DVDRip";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Some girls", result[DefaultHandlerNames.Title]);
            Assert.Equal("dvdrip", result[DefaultHandlerNames.Source]);
            Assert.Equal("1998", result[DefaultHandlerNames.Year]);
        }

        [Fact]
        public void EcritDansLeCiel()
        {
            string title = "Ecrit.Dans.Le.Ciel.1954.MULTI.DVDRIP.x264.AC3-gismo65";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Ecrit Dans Le Ciel", result[DefaultHandlerNames.Title]);
            Assert.Equal("dvdrip", result[DefaultHandlerNames.Source]);
            Assert.Equal("1954", result[DefaultHandlerNames.Year]);
            Assert.Equal("multi", result[DefaultHandlerNames.Language]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
            Assert.Equal("ac3", result[DefaultHandlerNames.Audio]);
            Assert.Equal("gismo65", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void AfterTheFallOfNewYork()
        {
            string title = "2019 After The Fall Of New York 1983 REMASTERED BDRip x264-GHOULS";

            var result = Parser.Default.Parse(title);
            Assert.Equal("2019 After The Fall Of New York", result[DefaultHandlerNames.Title]);
            Assert.Equal("bdrip", result[DefaultHandlerNames.Source]);
            Assert.Equal("True", result[DefaultHandlerNames.Remastered]);
            Assert.Equal("1983", result[DefaultHandlerNames.Year]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
            Assert.Equal("GHOULS", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void GhostInTheShell()
        {
            string title = "Ghost In The Shell 2017 720p HC HDRip X264 AC3-EVO";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Ghost In The Shell", result[DefaultHandlerNames.Title]);
            Assert.Equal("hdrip", result[DefaultHandlerNames.Source]);
            Assert.Equal("True", result[DefaultHandlerNames.Hardcoded]);
            Assert.Equal("2017", result[DefaultHandlerNames.Year]);
            Assert.Equal("720p", result[DefaultHandlerNames.Resolution]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
            Assert.Equal("ac3", result[DefaultHandlerNames.Audio]);
            Assert.Equal("EVO", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void RogueOne()
        {
            string title = "Rogue One 2016 1080p BluRay x264-SPARKS";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Rogue One", result[DefaultHandlerNames.Title]);
            Assert.Equal("bluray", result[DefaultHandlerNames.Source]);
            Assert.Equal("2016", result[DefaultHandlerNames.Year]);
            Assert.Equal("1080p", result[DefaultHandlerNames.Resolution]);
            Assert.Equal("x264", result[DefaultHandlerNames.Codec]);
            Assert.Equal("SPARKS", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void Desperation()
        {
            string title = "Desperation 2006 Multi Pal DvdR9-TBW1973";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Desperation", result[DefaultHandlerNames.Title]);
            Assert.Equal("dvd", result[DefaultHandlerNames.Source]);
            Assert.Equal("2006", result[DefaultHandlerNames.Year]);
            Assert.Equal("multi", result[DefaultHandlerNames.Language]);
            Assert.Equal("R9", result[DefaultHandlerNames.Region]);
            Assert.Equal("TBW1973", result[DefaultHandlerNames.Group]);
        }

        [Fact]
        public void Maman()
        {
            string title = "Maman, j'ai raté l'avion 1990 VFI 1080p BluRay DTS x265-HTG";

            var result = Parser.Default.Parse(title);
            Assert.Equal("Maman, j'ai raté l'avion", result[DefaultHandlerNames.Title]);
            Assert.Equal("bluray", result[DefaultHandlerNames.Source]);
            Assert.Equal("1990", result[DefaultHandlerNames.Year]);
            Assert.Equal("dts", result[DefaultHandlerNames.Audio]);
            Assert.Equal("1080p", result[DefaultHandlerNames.Resolution]);
            Assert.Equal("vfi", result[DefaultHandlerNames.Language]);
            Assert.Equal("x265", result[DefaultHandlerNames.Codec]);
            Assert.Equal("HTG", result[DefaultHandlerNames.Group]);
        }
    }
}
