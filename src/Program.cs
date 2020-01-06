namespace NameFixer
{
    using System;
    using System.IO;
    using System.Linq;
    using CommandLine;
    using NameFixer.Analyzer;
    using NameFixer.Properties;

    /// <summary>
    ///     A class that contains the main-entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        ///     Generates the map for the sequence verb.
        /// </summary>
        /// <param name="options">the options</param>
        /// <param name="map">the map</param>
        /// <returns>a value indicating whether the map could be generated</returns>
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

                map.Register(information.Info, fileName, options.PreserveExtension);
            }

            return true;
        }

        /// <summary>
        ///     Runs the application.
        /// </summary>
        /// <param name="args">the CLI arguments</param>
        /// <returns>the process exit code to return</returns>
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<SequenceCliOptions>(args).MapResult(
                options => RenameAll(options, HandleSequenceVerb),
                errors => 1);
        }

        /// <summary>
        ///     Renames all files.
        /// </summary>
        /// <typeparam name="TOptions">the type of the options</typeparam>
        /// <param name="options">the options</param>
        /// <param name="mapFunction">the map generation function</param>
        /// <returns>the exit code</returns>
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
                map.Dump(Console.Out);
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