using System.IO;

namespace preshow;

public static class ImageLocator
{
    public static List<string> GetImagesFromLocation(string folder)
    {
        var files = Directory.EnumerateFiles(folder, "*.*");
        return files.Where(IsImage).ToList();
    }

    public static readonly List<string> ImageExtensions =
        [ ".JPG", ".JPEG", ".BMP", ".GIF", ".PNG" ];

    private static bool IsImage(string file)
    {
        return ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant());
    }
}
