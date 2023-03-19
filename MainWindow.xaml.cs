using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace preshow;

public partial class MainWindow : Window
{
    private List<string> images = new();
    private int currentIndex = 0;
    private readonly DispatcherTimer timer;
    private readonly DispatcherTimer countdownTimer;

    public MainWindow(string imageFolder, int delay, DateTime startTime, string titleScreen, string url)
    {
        InitializeComponent();

        timer = new DispatcherTimer();
        timer.Tick += (s, e) => ShowNextImage();

        countdownTimer = new DispatcherTimer();
        countdownTimer.Interval = new TimeSpan(100);
        countdownTimer.Tick += (s, e) =>
        {
            if (startTime < DateTime.Now)
            {
                countDown.Visibility = Visibility.Collapsed;
                countdownTimer.Stop();
            }
            countDown.Text = $"Time to Start: {startTime - DateTime.Now:hh\\:mm\\:ss}";
        };

        urlDisplay.Text = url;

        Loaded += (s, e) =>
        {
            if (string.IsNullOrEmpty(imageFolder) ||
                !Directory.Exists(imageFolder))
            {
                var dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageFolder = dlg.SelectedPath;
                }
                else
                {
                    Close();
                    return;
                }
            }
            images = ImageLocator.GetImagesFromLocation(imageFolder);
            images.Shuffle();

            if (!string.IsNullOrEmpty(titleScreen) &&
                File.Exists(titleScreen))
            {
                images.InsertItems(titleScreen, 10);
            }
            ShowImage(0);

            timer.Interval = new System.TimeSpan(0, 0, delay);
            timer.Start();
            countdownTimer.Start();
        };
    }

    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Space:
                Pause();
                break;
            case Key.Next:
            case Key.Right:
            case Key.Enter:
                ShowNextImage();
                break;
            case Key.Left:
            case Key.PageUp:
                ShowPreviousImage();
                break;
            case Key.Escape:
                Close();
                break;
            default:
                break;
        }
    }

    private void Pause()
    {
        if (timer.IsEnabled)
            timer.Stop();
        else
            timer.Start();
    }

    private void ShowImage(int index)
    {
        var image = Image.FromFile(images[index]) as Bitmap;
        var imageSource = image?.ToWpfBitmap();
        targetImage.Source = imageSource;
    }

    private void ShowNextImage()
    {
        currentIndex++;
        if (currentIndex >= images.Count) currentIndex = 0;
        ShowImage(currentIndex);
    }

    private void ShowPreviousImage()
    {
        if (currentIndex > 0) currentIndex--;
        ShowImage(currentIndex);
    }
}
