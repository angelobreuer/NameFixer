namespace NameFixer
{
    using CommandLine;
    using NameFixer.Properties;

    /// <summary>
    ///     The CLI options for the sequence verb.
    /// </summary>
    [Verb("sequence",
        HelpText = "SequenceVerbDescription",
        ResourceType = typeof(Resources))]
    public sealed class SequenceCliOptions : GeneralCliOptions
    {
        /// <summary>
        ///     Gets or sets the directory where the files are in.
        /// </summary>
        [Option("dir",
            Default = "./",
            HelpText = "FolderOptionDescription",
            ResourceType = typeof(Resources))]
        public string Folder { get; set; }

        /// <summary>
        ///     Gets or sets the file format to rename files to.
        /// </summary>
        [Value(0,
            Required = true,
            HelpText = "FormatOptionDescription",
            ResourceType = typeof(Resources))]
        public string Format { get; set; }

        /// <summary>
        ///     Gets or sets the ordinal number padding.
        /// </summary>
        [Option('p', "padding",
            Default = 0,
            HelpText = "PaddingOptionDescription",
            ResourceType = typeof(Resources))]
        public int Padding { get; set; }

        /// <summary>
        ///     Gets or sets the prefix before the ordinal number to extract.
        /// </summary>
        [Option("seq-prefix",
            Default = "",
            HelpText = "SequencePrefixOptionDescription",
            ResourceType = typeof(Resources))]
        public string SequencePrefix { get; set; }
    }
}