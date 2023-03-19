# Jeremy's Presentation Preshow

This application cycles through images from a selected location along with a countdown timer.

## Purpose
In the waiting period before a live presentation, I like to show icebreaker pictures on the screen. In Windows 10 and prior, I used the built-in slideshow that was part of the Photos app. Sadly, there were some missing features in the Windows 11 version, so I created my own. [Repository: jeremybytes/SlideShow](https://github.com/jeremybytes/SlideShow).  

I decided to take this a step further. Instead of just cycling through pictures, I added an optional countdown timer as well as a way to add the presentation title slide to show periodically.

I use command-line parameters for configuration so that I can create shortcuts in advance that include the parameters for a particular presentation. This is particularly useful if I have multiple presentations on one day; I can create a separate shortcut for each presentation.

## Features
**Version 0.3.0**  
* New parameter "-u" to provide a URL to display at the bottom of the screen  

**Version 0.2.0**  
* Application defaults to full-screen
* Command-line parameter for image folder location
* Folder dialog pop-up if image folder location is empty or invalid
* Command-line parameter for slideshow delay interval
* Optional countdown timer (based on command-line parameter)
* Optional title slide (based on command-line parameter)

**Version 0.1.0** (from the original [SlideShow](https://github.com/jeremybytes/SlideShow) project)
* Dialog to choose folder with images
* Auto-sizes images to the window size
* Shuffles images into a random order
* Auto-advance set to 10 seconds (changeable in code)
* 'Space' to pause the auto-advance
* 'Enter' or 'Right Arrow' to manually advance
* 'Left Arrow' to go to previous
* "Esc" to exit
* Supports Logitech presentation remote ('Next' / 'PageUp')

*Note: the feature set is minimal for what my immediate needs. Potential features are listed below.*

## Usage
Command-line options:

```
  preshow.exe
    -f --folder  Image folder location (default: 'C:\\Users\\jerem\\Pictures\\Idle Album')  
    -d --delay   Number of seconds between slides (default: 10)
    -s --start   Start time for the presentation
    -t --title   Presentation title slide image location
    -u --url     URL to display at the bottom of the screen
```

Example shortcut target command-line with parameters:

```
C:\PreShow\preshow.exe -s 15:00 -t "C:\Development\Sessions\SDD2022\TITLE-a-tour-of-go-for-the-csharp-dev.png"
```

This starts the slideshow using 15:00 / 3:00 p.m. as the start time and the specified PNG file as the title slide. The default values for the image location and delay interval are used.

If the start time is in the past, the countdown will be hidden.

## Output Samples
![Sample Image with Countdown](/Images/preshow-sample1.png)

![Sample Title Slide with Countdown](/Images/preshow-sample2.png)

## Configuration
Defaults can be changed in the code in the "[Configuration.cs](https://github.com/jeremybytes/presentation-preshow/blob/main/Configuration.cs)" file.

```c#
    [Option(shortName: 'f', longName: "folder", Required = false, 
        HelpText = "Image folder location (default: 'C:\\Users\\jerem\\Pictures\\Idle Album')", 
        Default = "C:\\Users\\jerem\\Pictures\\Idle Album")]
    public string? ImageFolder { get; set; }

    [Option(shortName: 'd', longName: "delay", Required = false, 
        HelpText = "Number of seconds between slides (default: 10)", 
        Default = 10)]
    public int Delay { get; set; }
    ...
```
Update the "Default" attribute settings as desired.

*Note: If you remove the Default attribute for the ImageFolder, then the folder selection dialog will pop-up when the application starts.*

**launchSettings.json**  
Note that the application also has a launchSettings.json file where you can put command-line parameters that will be used when running the application from Visual Studio. I use these values for testing.

```json
{
  "profiles": {
    "preshow": {
      "commandName": "Project",
      "commandLineArgs": "-s 05:00 -t \"C:\\Development\\Sessions\\SDD2022\\TITLE-a-tour-of-go-for-the-csharp-dev.png\""
    }
  }
}
```

 The entire file can be removed, if desired.

## Potential Features

* Configuration file instead of or in addition to command-line parameters.
* UI / right-click menu
  * Change the delay interval
  * Pause the auto-advance
  * "Next" and "Previous"
* Windowed mode

If you find this application useful or have ideas for additional features, please let me know.
