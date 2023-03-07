using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DSC.ParseTorrentName
{
    internal class Constants
    {
        /// <summary>
        /// Default handlers
        /// </summary>
        public static ReadOnlyCollection<Handler> DefaultHandlers => new ReadOnlyCollection<Handler>(_defaultHandlers);

        private static readonly List<Handler> _defaultHandlers = new List<Handler>
        {
            new Handler(DefaultHandlerNames.Year, new Regex(@"(?!^)[([]?((?:19[0-9]|20[012])[0-9])[)\]]?"), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Resolution, new Regex(@"([0-9]{3,4}[pi])", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Resolution, new Regex(@"(4k)", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Extended, new Regex(@"EXTENDED"), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Convert, new Regex(@"CONVERT"), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Hardcoded, new Regex(@"HC|HARDCODED"), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Proper, new Regex(@"(?:REAL.)?PROPER"), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Repack, new Regex(@"REPACK|RERIP"), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Retail, new Regex(@"\bRetail\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Remastered, new Regex(@"\bRemaster(?:ed)?\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Unrated, new Regex(@"\bunrated|uncensored\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "boolean")),
            new Handler(DefaultHandlerNames.Region, new Regex(@"R[0-9]")),
            new Handler(DefaultHandlerNames.Container, new Regex(@"\b(MKV|AVI|MP4)\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\b(?:HD-?)?CAM\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\b(?:HD-?)?T(?:ELE)?S(?:YNC)?\b", RegexOptions.IgnoreCase), new HandlerOptions(value: "telesync")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bHD-?Rip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bBRRip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bBDRip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bDVDRip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bDVD(?:R[0-9])?\b", RegexOptions.IgnoreCase), new HandlerOptions(value: "dvd")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bDVDscr\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\b(?:HD-?)?TVRip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bTC\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bPPVRip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bR5\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bVHSSCR\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bBluray\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bWEB-?DL\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\bWEB-?Rip\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\b(?:DL|WEB|BD|BR)MUX\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"\b(DivX|XviD)\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Source, new Regex(@"HDTV", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Codec, new Regex(@"dvix|mpeg2|divx|xvid|[xh][-. ]?26[45]|avc|hevc", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Codec, (results, handler) => {if (results.ContainsKey(DefaultHandlerNames.Codec)) {results[DefaultHandlerNames.Codec] = Regex.Replace(results[DefaultHandlerNames.Codec], @"[ .-]", string.Empty);}return null;}, new HandlerOptions(skipIfAlreadyFound: false)),
            new Handler(DefaultHandlerNames.Audio, new Regex(@"MD|MP3|mp3|FLAC|Atmos|DTS(?:-HD)?|TrueHD"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Audio, new Regex(@"Dual[- ]Audio", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Audio, new Regex(@"AC-?3(?:\.5\.1)?", RegexOptions.IgnoreCase), new HandlerOptions(value: "ac3")),
            new Handler(DefaultHandlerNames.Audio, new Regex(@"DD5[. ]?1", RegexOptions.IgnoreCase), new HandlerOptions(value: "dd5.1")),
            new Handler(DefaultHandlerNames.Audio, new Regex(@"AAC(?:[. ]?2[. ]0)?"), new HandlerOptions(value: "aac")),
            new Handler(DefaultHandlerNames.Group, new Regex(@"- ?([^\-. ]+)$")),
            new Handler(DefaultHandlerNames.Season, new Regex(@"S([0-9]{1,2}) ?E[0-9]{1,2}", RegexOptions.IgnoreCase), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Season, new Regex(@"([0-9]{1,2})x[0-9]{1,2}"), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Season, new Regex(@"(?:Saison|Season)[. _-]?([0-9]{1,2})", RegexOptions.IgnoreCase), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Episode, new Regex(@"S[0-9]{1,2} ?E([0-9]{1,2})", RegexOptions.IgnoreCase), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Episode, new Regex(@"[0-9]{1,2}x([0-9]{1,2})"), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Episode, new Regex(@"[ée]p(?:isode)?[. _-]?([0-9]{1,3})", RegexOptions.IgnoreCase), new HandlerOptions(type: "integer")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bRUS\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bNL\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bFLEMISH\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bGERMAN\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bDUBBED\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\b(ITA(?:LIAN)?|iTALiAN)\b"), new HandlerOptions(value: "ita")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bFR(?:ENCH)?\b"), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bTruefrench|VF(?:[FI])\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bVOST(?:(?:F(?:R)?)|A)?|SUBFRENCH\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
            new Handler(DefaultHandlerNames.Language, new Regex(@"\bMULTi(?:Lang|-VF2)?\b", RegexOptions.IgnoreCase), new HandlerOptions(type: "lowercase")),
        };
    }
}
