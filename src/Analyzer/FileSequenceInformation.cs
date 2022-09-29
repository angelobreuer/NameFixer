namespace NameFixer.Analyzer;

using System;
using System.IO;

/// <summary>
///     Contains information about a file in a file name sequence.
/// </summary>
public readonly struct FileSequenceInformation
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileSequenceInformation"/> struct.
    /// </summary>
    /// <param name="info">the file information</param>
    /// <param name="ordinal">the ordinal sequence number</param>
    /// <exception cref="ArgumentNullException">
    ///     thrown if the specified file <paramref name="info"/> is <see langword="null"/>.
    /// </exception>
    public FileSequenceInformation(FileInfo info, int? ordinal)
    {
        Info = info ?? throw new ArgumentNullException(nameof(info));
        Ordinal = ordinal;
    }

    /// <summary>
    ///     Gets the file information.
    /// </summary>
    public FileInfo Info { get; }

    /// <summary>
    ///     Gets the ordinal sequence number.
    /// </summary>
    public int? Ordinal { get; }
}