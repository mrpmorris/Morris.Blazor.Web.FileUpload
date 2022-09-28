using Microsoft.AspNetCore.Components.Forms;

namespace Morris.Blazor.Web.FileUpload;

public partial class MultiFileUploader
{
    private readonly List<FileUploadInfo> FileUploadInfos = new();
    private readonly List<string> InputControlIds = new();
    private int NextInputId;

    private string CurrentInputControlId => InputControlIds[InputControlIds.Count - 1];
    private IEnumerable<string> HiddenInputControlIds => InputControlIds.Take(InputControlIds.Count - 1);

    protected override void OnInitialized()
    {
        base.OnInitialized();
        AddInputControl();
    }

    private void AddFiles(InputFileChangeEventArgs e)
    {
        IReadOnlyList<IBrowserFile> files = e.GetMultipleFiles(maximumFileCount: int.MaxValue);
        for (int i = 0; i < files.Count; i++)
        {
            IBrowserFile browserFile = files[i];
            var fileUploadInfo = new FileUploadInfo(HtmlInputId: "theInput", HtmlInputFileIndex: i, browserFile);
            FileUploadInfos.Add(fileUploadInfo);
        }
        AddInputControl();
    }


    private void AddInputControl()
    {
        NextInputId++;
        InputControlIds.Add($"InputFileId{NextInputId}");
    }

    private async Task Test()
    {
        byte[] buffer = new byte[4096];
        foreach (FileUploadInfo file in FileUploadInfos)
        {
            using var source = file.BrowserFile.OpenReadStream(long.MaxValue);
            Console.WriteLine($"Reading {file.BrowserFile.Name}");
            await source.ReadAsync(buffer);
        }
    }
}