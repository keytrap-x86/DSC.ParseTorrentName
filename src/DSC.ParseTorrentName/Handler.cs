using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSC.ParseTorrentName
{
    public class Handler
    {
        public string HandlerName { get; }
        public Regex? Regex { get; }
        public Func<Dictionary<string, string>, Handler, int?>? Func { get; }
        public HandlerOptions Options { get; }

        /// <summary>
        /// Creates a handler using the RegEx method
        /// </summary>
        /// <param name="handlerName">Name of the handler in the results</param>
        /// <param name="regex">RegEx value that is used for matching</param>
        /// <param name="options">Handler options</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Handler(string handlerName, Regex regex, HandlerOptions? options = null)
        {
            if (string.IsNullOrWhiteSpace(handlerName))
                throw new ArgumentNullException(nameof(handlerName));

            if (regex == null)
                throw new ArgumentNullException(nameof(regex));

            HandlerName = handlerName.Trim().ToLower();
            Regex = regex;
            Options = options ?? HandlerOptions.Default;
        }

        /// <summary>
        /// Creates a handler using the Func method
        /// </summary>
        /// <param name="handlerName">Name of the handler in the results</param>
        /// <param name="func">Function to execute</param>
        /// <param name="options">Handler options</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Handler(string handlerName, Func<Dictionary<string, string>, Handler, int?> func, HandlerOptions? options = null)
        {
            if (string.IsNullOrWhiteSpace(handlerName))
                throw new ArgumentNullException(nameof(handlerName));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            HandlerName = handlerName.Trim().ToLower();
            Func = func;
            Options = options ?? HandlerOptions.Default;
        }

        /// <summary>
        /// Executes the handler using the Regex first then the Func mehtod
        /// </summary>
        /// <param name="title">Raw input title</param>
        /// <param name="result">Reference to the results dictionary used</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int? Execute(string title, ref Dictionary<string, string> result)
        {
            if (Regex == null && Func == null)
                throw new InvalidOperationException($"RegEx and Func are null. Unsure how to execut handler {HandlerName}.");

            if (result.ContainsKey(HandlerName) && Options.SkipIfAlreadyFound)
                return null;

            // Invoke RegEx method
            if (Regex != null)
            {
                var match = Regex.Match(title);
                if (match.Success)
                {
                    var matchedGroup = match.Groups[match.Groups.Count > 1 ? 1 : 0];
                    if (matchedGroup != null)
                    {
                        var value = string.IsNullOrEmpty(Options.Value) ? Transform(matchedGroup.Value) : Options.Value;
                        result.Add(HandlerName, value);

                        return matchedGroup.Index - 1;
                    }
                }
            }

            // Invoke function method
            if (Func != null)
            {
                return Func.Invoke(result, this);
            }

            return null;
        }

        /// <summary>
        /// Transforms the Handler value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string Transform(string value)
        {
            var val = value ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(Options?.Type))
            {
                switch (Options.Type.ToLower().Trim())
                {
                    case "lowercase":
                        return val.ToLower();

                    case "uppercase":
                        return val.ToUpper();

                    case "int":
                    case "integer":
                        return int.Parse(val).ToString();

                    case "bool":
                    case "boolean":
                        return true.ToString();
                }
            }

            return val;
        }
    }
}
