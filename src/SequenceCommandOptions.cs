namespace NameFixer;

public sealed class SequenceCommandOptions
{
    /// <summary>
    ///     Gets or inits a value indicating whether the operation(s) should be simulated.
    /// </summary>
    public bool Simulate { get; init; }

    /// <summary>
    ///     Gets or inits a value indicating whether verbose output should be enabled.
    /// </summary>
    public bool Verbose { get; init; }

    /// <summary>
    ///     Gets or inits a value indicating whether the extension of the resulting file should
    ///     be preserved.
    /// </summary>
    public bool PreserveExtension { get; init; }

    /// <summary>
    ///     Gets or inits the directory where the files are in.
    /// </summary>
    public string Folder { get; init; }

    /// <summary>
    ///     Gets or inits the file format to rename files to.
    /// </summary>
    public string Format { get; init; }

    /// <summary>
    ///     Gets or inits the ordinal number padding.
    /// </summary>
    public int Padding { get; init; }

    /// <summary>
    ///     Gets or inits the prefix before the ordinal number to extract.
    /// </summary>
    public string SequencePrefix { get; init; }
}
