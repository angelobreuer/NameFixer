namespace NameFixer.Analyzer;

using System;
using System.IO;

/// <summary>
///     The default implementation for the <see cref="ISequenceAnalyzer"/> interface.
/// </summary>
public sealed class DefaultSequenceAnalyzer : ISequenceAnalyzer
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DefaultSequenceAnalyzer"/> class.
    /// </summary>
    public DefaultSequenceAnalyzer() : this(DefaultSeparators)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DefaultSequenceAnalyzer"/> class.
    /// </summary>
    /// <param name="separators">the separators</param>
    /// <exception cref="ArgumentNullException">
    ///     thrown if the specified <paramref name="separators"/> array is <see langword="null"/>.
    /// </exception>
    public DefaultSequenceAnalyzer(char[] separators)
        => Separators = separators ?? throw new ArgumentNullException(nameof(separators));

    /// <summary>
    ///     An array of characters used as the default parameter for the separators.
    /// </summary>
    public static char[] DefaultSeparators { get; }
        = new[] { ' ', '\t', '.', '-', '_' };

    /// <summary>
    ///     Gets the separators.
    /// </summary>
    public char[] Separators { get; }

    /// <inheritdoc/>
    public bool TryExtract(FileInfo file, string prefix, out int value)
    {
        var hasPrefix = !string.IsNullOrEmpty(prefix);
        var prefixLength = hasPrefix ? prefix.Length : 0;

        for (var index = 0; index < file.Name.Length; index++)
        {
            var prefixIndex = hasPrefix ? file.Name.IndexOf(prefix, index) + prefixLength : index;
            var part = file.Name.Substring(prefixIndex, file.Name.Length - prefixIndex);
            var partIndex = 0;

            for (; partIndex < part.Length && char.IsNumber(part[partIndex]); partIndex++)
            {
            }

            if (partIndex > 0)
            {
                // found number
                value = int.Parse(part.Substring(0, partIndex));
                return true;
            }
        }

        value = default;
        return false;
    }
}