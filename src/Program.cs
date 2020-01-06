namespace NameFixer
{
    using System;
    using System.IO;
    using System.Linq;
    using CommandLine;
    using NameFixer.Analyzer;

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
                    Console.WriteLine($"Warning could not extract ordinal number: {information.Info.FullName}, skipping file...");
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
                Console.Error.WriteLine("Failed to generate file name map.");
                return 4;
            }

            if (options.Simulate)
            {
                Console.WriteLine("Running simulation...");
                map.Dump(Console.Out);
            }
            else
            {
                map.Apply(clear: true, Console.Out);
            }

            // success
            return 0;
        }
    }
}