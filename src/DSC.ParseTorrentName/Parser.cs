using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSC.ParseTorrentName
{
    /// <summary>
    /// Parses torrent names to extract data
    /// </summary>
    public class Parser
    {
        public static Parser Default => new Parser(true);

        private List<Handler> _handlers = new List<Handler>();

        public Parser(bool applyDefaultHandlers)
        {
            if (applyDefaultHandlers)
            {
                _handlers.AddRange(Constants.DefaultHandlers);
            }
        }

        public Parser()
            : this(true) { }

        /// <summary>
        /// Parses the title to extract data using the provided handlers
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ParserResult Parse(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            if (_handlers.Count == 0)
                throw new Exception("No handlers have been added to the parser");

            int endOfTitle = title.Length;
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var handler in _handlers)
            {
                var titleIndex = handler.Execute(title, ref result);
                if (titleIndex.HasValue && titleIndex.Value < endOfTitle)
                {
                    endOfTitle = titleIndex.Value;
                }
            }

            result.Add(DefaultHandlerNames.Title, CleanTitle(title.Substring(0, endOfTitle)));
            return new ParserResult(result);
        }

        public void AddHandler(Handler handler)
        {
            _handlers.Add(handler);
        }

        private string CleanTitle(string title)
        {
            var cleanedTitle = title + "";

            if (!cleanedTitle.Contains(" ") && cleanedTitle.Contains("."))
            {
                cleanedTitle = cleanedTitle.Replace(".", " ");
            }

            cleanedTitle = cleanedTitle.Replace('_', ' ');
            cleanedTitle = Regex.Replace(cleanedTitle, @"([(_]|- )$", string.Empty).Trim();

            return cleanedTitle.Trim();
        }
    }
}
