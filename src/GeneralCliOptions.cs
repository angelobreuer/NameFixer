namespace NameFixer
{
    using CommandLine;
    using NameFixer.Properties;

    /// <summary>
    ///     Represents the abstraction for the CLI options.
    /// </summary>
    public abstract class GeneralCliOptions
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the operation(s) should be simulated.
        /// </summary>
        [Option('s', "simulate",
            HelpText = "SimulateOptionDescription",
            ResourceType = typeof(Resources))]
        public bool Simulate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether verbose output should be enabled.
        /// </summary>
        [Option('v', "verbose",
            HelpText = "VerboseOptionDescription",
            ResourceType = typeof(Resources))]
        public bool Verbose { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the extension of the resulting file should
        ///     be preserved.
        /// </summary>
        [Option('e', "preserve-extension",
            HelpText = "PreserveExtensionOptionDescription",
            ResourceType = typeof(Resources))]
        public bool PreserveExtension { get; set; }
    }
}