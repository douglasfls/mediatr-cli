using CommandLine;

namespace GenericCli;

public class BaseOptions
{
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}