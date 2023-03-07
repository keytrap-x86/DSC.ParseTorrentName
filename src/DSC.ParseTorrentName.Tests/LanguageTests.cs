namespace DSC.ParseTorrentName.Tests
{
    public class LanguageTests
    {
        [Theory]
        [InlineData("Deadpool 2016 1080p BluRay DTS Rus Ukr 3xEng HDCL", "rus")]
        [InlineData("VAIANA: MOANA (2017) NL-Retail [2D] EAGLE", "nl")]
        [InlineData("De Noodcentrale S02E05 FLEMISH 540p WEBRip AAC H 264", "flemish")]
        [InlineData("Yo-Kai Watch S01E71 DUBBED 720p HDTV x264-W4F", "dubbed")]
        [InlineData("The Intern 2015 TRUEFRENCH 720p BluRay x264-PiNKPANTERS", "truefrench")]
        [InlineData("After Earth 2013 VFF BDrip x264 YJ", "vff")]
        [InlineData("127.Heures.FRENCH.DVDRip.AC3.XViD-DVDFR", "french")]
        [InlineData("Color.Of.Night.Unrated.DC.VostFR.BRrip.x264", "vostfr")]
        [InlineData("Le Labyrinthe 2014 Multi-VF2 1080p BluRay x264-PopHD", "multi-vf2")]
        [InlineData("Maman, j'ai raté l'avion 1990 VFI 1080p BluRay DTS x265-HTG", "vfi")]
        [InlineData("South.Park.S21E10.iTALiAN.FiNAL.AHDTV.x264-NTROPiC", "ita")]
        [InlineData("South.Park.S21E10.FiNAL.AHDTV.x264-NTROPiC", null)]
        public void DetectLanguage(string title, string language)
        {
            var result = Parser.Default.Parse(title);
            Assert.Equal(language, result[DefaultHandlerNames.Language]);
        }
    }
}
