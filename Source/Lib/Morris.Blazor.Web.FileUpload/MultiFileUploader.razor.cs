using Microsoft.AspNetCore.Components.Forms;

namespace Morris.Blazor.Web.FileUpload;

public partial class MultiFileUploader
{
    private readonly List<IBrowserFile> BrowserFiles = new();

    private void AddFiles(InputFileChangeEventArgs e)
    {
        foreach(IBrowserFile file in e.GetMultipleFiles(maximumFileCount: int.MaxValue))
            BrowserFiles.Add(file);
    }
}