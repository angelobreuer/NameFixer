using System.CommandLine;
using NameFixer;

await new SequenceCommand()
    .InvokeAsync(args)
    .ConfigureAwait(false);