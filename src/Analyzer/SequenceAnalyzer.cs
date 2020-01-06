namespace NameFixer.Analyzer
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class SequenceAnalyzer
    {
        public static IEnumerable<FileSequenceInformation> AnalyzeSequence(IEnumerable<FileInfo> files, IEnumerable<ISequenceAnalyzer> analyzers, string prefix)
        {
            foreach (var file in files)
            {
                var ordinal = default(int);
                var available = analyzers.Any(s => s.TryExtract(file, prefix, out ordinal));

                // create file information
                yield return new FileSequenceInformation(file, available ? ordinal : default(int?));
            }
        }
    }
}