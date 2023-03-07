namespace DSC.ParseTorrentName
{
    /// <summary>
    /// Options for a handler
    /// </summary>
    public class HandlerOptions
    {
        public static HandlerOptions Default => new HandlerOptions("string", null, true);

        /// <summary>
        /// Type of the value - Defaults to string
        /// Used for transformation from the result
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Override value used in transformation
        /// If a value is present, it will always be returned by the transformer
        /// </summary>
        public string? Value { get; }

        /// <summary>
        /// Indicates whether or not a handler should process if a value for a handler of the same name already exists
        /// </summary>
        public bool SkipIfAlreadyFound { get; }

        public HandlerOptions(string? type = null, string? value = null, bool? skipIfAlreadyFound = null)
        {
            Type = (type ?? Default.Type).Trim().ToLower();
            Value = value?.Trim().ToLower();
            SkipIfAlreadyFound = (skipIfAlreadyFound ?? Default.SkipIfAlreadyFound);
        }
    }
}
