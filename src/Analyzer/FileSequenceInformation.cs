namespace NameFixer.Analyzer
{
    using System;
    using System.IO;

    public readonly struct FileSequenceInformation
    {
        public FileSequenceInformation(FileInfo info, int? ordinal)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Ordinal = ordinal;
        }

        public FileInfo Info { get; }

        public int? Ordinal { get; }
    }
}