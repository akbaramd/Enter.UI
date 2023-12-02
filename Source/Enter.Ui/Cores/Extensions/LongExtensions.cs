namespace Enter.Ui.Cores.Extensions;

public static class LongExtensions
{
    public static string ToByteSizeString(this long size)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        while (size >= 1024 && order < sizes.Length - 1) {
            order++;
            size = size/1024;
        }

// Adjust the format string to your preferences. For example "{0:0.#}{1}" would
// show a single decimal place, and no space.
        string result = String.Format("{0:0.##} {1}", size, sizes[order]);

        return result;
    }
}