namespace NameFixer
{
    using System;
    using System.IO;
    using System.Linq;
    using CommandLine;
    using NameFixer.Analyzer;
    using NameFixer.Properties;

    internal sealed class Program
    {
        private static bool HandleSequenceVerb(SequenceCliOptions options, FileNameMap map)
        {
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

                map.Register(information.Info, fileName);
            }

            return true;
        }

        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<SequenceCliOptions>(args).MapResult(
                options => RenameAll(options, HandleSequenceVerb),
                errors => 1);
        }

        private static int RenameAll<TOptions>(
            TOptions options, Func<TOptions, FileNameMap, bool> mapFunction)
            where TOptions : GeneralCliOptions
        {
            var map = new FileNameMap();

            if (!mapFunction(options, map))
            {
                // failed to generate map
                Console.Error.WriteLine(Resources.MapGenerationFailed);
                return 4;
            }

            // the output to print the verbose output to
            var verboseOutput = options.Verbose ? Console.Out : null;

            if (options.Simulate)
            {
                Console.WriteLine(Resources.RunningSimulation);

                if (verboseOutput != null)
                {
                    map.Dump(verboseOutput);
                }
            }
            else
            {
                map.Apply(clear: true, verboseOutput);
            }

            // success
            return 0;
        }
    }
}