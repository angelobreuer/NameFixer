namespace NameFixer.Analyzer
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    ///     An utility class used to scan sequences in file names.
    /// </summary>
    public static class SequenceAnalyzer
    {
        /// <summary>
        ///     Analyzes a sequence in the specified <paramref name="files"/>.
        /// </summary>
        /// <param name="files">the files to analyze</param>
        /// <param name="analyzers">the analyzers to use</param>
        /// <param name="prefix">the prefix</param>
        /// <returns>the sequence information</returns>
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