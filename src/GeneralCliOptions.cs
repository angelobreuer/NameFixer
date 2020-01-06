namespace NameFixer
{
    using CommandLine;

    public abstract class GeneralCliOptions
    {
        [Option('s', "simulate")]
        public bool Simulate { get; set; }

        [Option('v', "verbose")]
        public bool Verbose { get; set; }
    }
}