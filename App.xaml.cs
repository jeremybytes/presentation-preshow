﻿using CommandLine;
using System.Windows;
using Application = System.Windows.Application;

namespace preshow;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        string? imageFolder = "";
        int delay = 0;
        string? startTimeString = "00:00";
        DateTime startTime = DateTime.Now;
        string? titleScreen = "";
        string? url = "";

        CommandLine.Parser.Default.ParseArguments<Configuration>(e.Args)
            .WithParsed(c =>
            {
                imageFolder = c.ImageFolder;
                delay = c.Delay;
                startTimeString = c.StartTimeString;
                titleScreen = c.TitleScreen;
                url = c.URL;
            }).WithNotParsed(c =>
            {
                Environment.Exit(0);
            });

            if (startTimeString is not null && startTimeString != "00:00")
            {
                var time = DateTime.Parse(startTimeString);
                startTime = DateTime.Today + time.TimeOfDay;
            }

        Application.Current.MainWindow = 
            new MainWindow(imageFolder, delay, startTime, titleScreen, url);
        Application.Current.MainWindow.Show();
    }
}
