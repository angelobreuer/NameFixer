namespace NameFixer.Analyzer;

using System.IO;

/// <summary>
///     An interface for a sequence analyzer.
/// </summary>
public interface ISequenceAnalyzer
{
    /// <summary>
    ///     Extracts the sequence number for the specified <paramref name="file"/>.
    /// </summary>
    /// <param name="file">the file information</param>
    /// <param name="prefix">the sequence number prefix</param>
    /// <param name="value">the sequence number for the file</param>
    /// <returns>a value indicating whether a value could be extracted from the file</returns>
    bool TryExtract(FileInfo file, string prefix, out int value);
}