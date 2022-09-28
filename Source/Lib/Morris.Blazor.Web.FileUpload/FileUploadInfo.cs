using Microsoft.AspNetCore.Components.Forms;

namespace Morris.Blazor.Web.FileUpload;

public class FileUploadInfo
{
    public string HtmlInputId { get; } = "";
    public int HtmlInputFileIndex { get; }
    public IBrowserFile BrowserFile { get; }
    public FileUploadStatus Status { get; set; } = FileUploadStatus.Queued;
    public long TotalBytesUploaded { get; set; }
    public int Percent => (int)(TotalBytesUploaded * 100 / BrowserFile.Size);

    public FileUploadInfo(string htmlInputId, int htmlInputFileIndex, IBrowserFile browserFile)
    {
        HtmlInputId = htmlInputId ?? throw new ArgumentNullException(nameof(htmlInputId));
        HtmlInputFileIndex = htmlInputFileIndex;
        BrowserFile = browserFile ?? throw new ArgumentNullException(nameof(browserFile));
    }
}
