using CommandLine;

namespace XamlMultiLanguageEditor.Winform.Options;

public class Options
{
    [Option('l', "load", HelpText = "Load languages files at startup.")]
    public string? LoadTarget { get; set; }
}
