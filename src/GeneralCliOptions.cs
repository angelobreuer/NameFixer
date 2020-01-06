namespace NameFixer
{
    using CommandLine;

    public abstract class GeneralCliOptions
    {
        [Option('s', "simulate")]
        public bool Simulate { get; set; }
    }
}