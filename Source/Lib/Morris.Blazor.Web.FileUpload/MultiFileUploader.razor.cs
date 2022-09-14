using Microsoft.AspNetCore.Components.Forms;

namespace Morris.Blazor.Web.FileUpload;

public partial class MultiFileUploader
{
    private readonly List<FileUploadInfo> FileUploadInfos = new();

    private void AddFiles(InputFileChangeEventArgs e)
    {

        IReadOnlyList<IBrowserFile> files = e.GetMultipleFiles(maximumFileCount: int.MaxValue);
        for (int i = 0; i < files.Count; i++)
        {
            IBrowserFile browserFile = files[i];
            var fileUploadInfo = new FileUploadInfo(HtmlInputId: "theInput", HtmlInputFileIndex: i, browserFile);
            FileUploadInfos.Add(fileUploadInfo);
        }
    }
}