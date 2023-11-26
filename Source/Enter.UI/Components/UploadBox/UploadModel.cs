// ReSharper disable once CheckNamespace
namespace Enter.Ui.Components;

public class UploadModel
{
    public string DataBase64 { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Extensions { get; set; } = string.Empty;
    public long Size { get; set; }
    public bool IsSent { get; set; } = false;
    public string ContentType { get; set; } = string.Empty;
    public string Url { get; set; }
}