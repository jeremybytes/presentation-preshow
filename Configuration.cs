using CommandLine;

namespace preshow;

public class Configuration
{
    [Option(shortName: 'f', longName: "folder", Required = false, 
        HelpText = "Image folder location (default: 'C:\\Users\\jerem\\Pictures\\Idle Album')", 
        Default = "C:\\Users\\jerem\\Pictures\\Idle Album")]
    public string? ImageFolder { get; set; }

    [Option(shortName: 'd', longName: "delay", Required = false, 
        HelpText = "Number of seconds between slides (default: 10)", 
        Default = 10)]
    public int Delay { get; set; }

    [Option(shortName: 's', longName: "start", Required = false, 
        HelpText = "Start time for the presentation", 
        Default = "00:00")]
    public string? StartTimeString { get; set; }

    [Option(shortName: 't', longName: "title", Required = false, 
        HelpText = "Presentation title slide image location", 
        Default = "")]
    public string? TitleScreen { get; set; }

    [Option(shortName: 'u', longName: "url", Required = false,
        HelpText = "URL to overlay",
        Default = "")]
    public string? URL { get; set; }
}
