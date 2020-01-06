namespace NameFixer
{
    using CommandLine;

    [Verb("sequence")]
    public sealed class SequenceCliOptions : GeneralCliOptions
    {
        [Option("dir", Default = "./")]
        public string Folder { get; set; }

        [Value(0, Required = true)]
        public string Format { get; set; }

        [Option('p', "padding", Default = 0)]
        public int Padding { get; set; }

        [Option("seq-prefix", Default = "")]
        public string SequencePrefix { get; set; }
    }
}