namespace NameFixer
{
    using CommandLine;

    /// <summary>
    ///     The CLI options for the sequence verb.
    /// </summary>
    [Verb("sequence")]
    public sealed class SequenceCliOptions : GeneralCliOptions
    {
        /// <summary>
        ///     Gets or sets the directory where the files are in.
        /// </summary>
        [Option("dir", Default = "./")]
        public string Folder { get; set; }

        /// <summary>
        ///     Gets or sets the file format to rename files to.
        /// </summary>
        [Value(0, Required = true)]
        public string Format { get; set; }

        /// <summary>
        ///     Gets or sets the ordinal number padding.
        /// </summary>
        [Option('p', "padding", Default = 0)]
        public int Padding { get; set; }

        /// <summary>
        ///     Gets or sets the prefix before the ordinal number to extract.
        /// </summary>
        [Option("seq-prefix", Default = "")]
        public string SequencePrefix { get; set; }
    }
}