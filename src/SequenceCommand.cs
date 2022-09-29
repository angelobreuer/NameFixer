namespace NameFixer;

using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using NameFixer.Analyzer;
using NameFixer.Properties;

/// <summary>
///     The CLI options for the sequence verb.
/// </summary>
public sealed class SequenceCommand : RootCommand
{
    private readonly Option<bool> _simulateOption = new(new[] { "--simulate", "-s" }, Resources.SimulateOptionDescription);
    private readonly Option<bool> _verboseOption = new(new[] { "--verbose", "-v" }, Resources.VerboseOptionDescription);
    private readonly Option<bool> _preserveExtensionOption = new(new[] { "--preserve-extension", "-e" }, Resources.PreserveExtensionOptionDescription);
    private readonly Option<string> _folderOption = new(new[] { "--dir", "-I" }, Resources.FolderOptionDescription);
    private readonly Option<int> _paddingOption = new(new[] { "--padding", "-p" }, getDefaultValue: () => 0, Resources.PaddingOptionDescription);
    private readonly Option<string> _sequencePrefixOption = new(new[] { "--seq-prefix", "-y" }, getDefaultValue: () => "", Resources.SequencePrefixOptionDescription);
    private readonly Argument<string> _formatArgument = new("Format", Resources.FormatOptionDescription);

    public SequenceCommand()
        : base(Resources.SequenceVerbDescription)
    {
        AddOption(_simulateOption);
        AddOption(_verboseOption);
        AddOption(_preserveExtensionOption);
        AddOption(_folderOption);
        AddOption(_paddingOption);
        AddOption(_sequencePrefixOption);
        AddArgument(_formatArgument);

        System.CommandLine.Handler.SetHandler(this, Run, _simulateOption, _verboseOption, _preserveExtensionOption, _folderOption, _paddingOption, _sequencePrefixOption, _formatArgument);
    }

    private static void Run(bool simulate, bool verbose, bool preserveExtension, string folder, int padding, string sequencePrefix, string format)
    {
        var options = new SequenceCommandOptions
        {
            Simulate = simulate,
            Verbose = verbose,
            PreserveExtension = preserveExtension,
            Folder = folder,
            Padding = padding,
            SequencePrefix = sequencePrefix,
            Format = format,
        };

        var map = new FileNameMap();
        var files = Directory.EnumerateFiles(options.Folder).Select(s => new FileInfo(s));
        var analyzers = new ISequenceAnalyzer[] { new DefaultSequenceAnalyzer() };
        var result = SequenceAnalyzer.AnalyzeSequence(files, analyzers, options.SequencePrefix);

        foreach (var information in result)
        {
            if (information.Ordinal is null)
            {
                Console.WriteLine(string.Format(Resources.CouldNotExtractOrdinal, information.Info.FullName));
                continue;
            }

            // register mappings
            var ordinalNumber = information.Ordinal.ToString().PadLeft(options.Padding, '0');
            var fileName = options.Format.Replace("{0}", ordinalNumber);

            map.Register(information.Info, fileName, options.PreserveExtension);
        }

        // the output to print the verbose output to
        var verboseOutput = options.Verbose ? Console.Out : null;

        if (options.Simulate)
        {
            Console.WriteLine(Resources.RunningSimulation);
            map.Dump(Console.Out);
        }
        else
        {
            map.Apply(clear: true, verboseOutput);
        }
    }
}