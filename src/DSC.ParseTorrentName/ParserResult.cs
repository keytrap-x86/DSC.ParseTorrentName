using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace DSC.ParseTorrentName
{
    public class ParserResult : IReadOnlyDictionary<string, string>
    {
        private ReadOnlyDictionary<string, string> _results;

        public ParserResult(Dictionary<string, string> results)
        {
            _results = new ReadOnlyDictionary<string, string>(results);
        }

        public string? GetTitle()
        {
            return this[DefaultHandlerNames.Title];
        }

        public string? this[string handlerName]
        {
            get
            {
                handlerName = handlerName.ToLower().Trim();

                if (_results.ContainsKey(handlerName))
                {
                    return _results[handlerName];
                }

                return null;
            }
        }

        public int Count => _results.Count;

        public IEnumerable<string> Keys => _results.Keys;

        public IEnumerable<string> Values => _results.Values;

        public bool ContainsKey(string key) => _results.ContainsKey(key);

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) => _results.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _results.GetEnumerator();

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _results.GetEnumerator();
    }
}
