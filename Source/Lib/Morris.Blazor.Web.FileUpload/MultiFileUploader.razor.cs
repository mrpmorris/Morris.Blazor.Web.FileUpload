using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Morris.Blazor.Web.FileUpload.Services;

namespace Morris.Blazor.Web.FileUpload;

public partial class MultiFileUploader
{
    private readonly List<FileUploadInfo> FileUploadInfos = new();
    private readonly List<string> InputControlIds = new();
    private int NextInputId;

    [Inject]
    private IFileUploadService FileUploadService { get; set; } = null!;

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
            var fileUploadInfo = new FileUploadInfo(
                htmlInputId: CurrentInputControlId,
                htmlInputFileIndex: i,
                browserFile: browserFile);
            FileUploadInfos.Add(fileUploadInfo);
        }
        AddInputControl();
    }


    private void AddInputControl()
    {
        NextInputId++;
        InputControlIds.Add($"InputFileId{NextInputId}");
    }

    private async Task UploadAsync()
    {
        foreach (FileUploadInfo file in FileUploadInfos)
        {
            await FileUploadService.UploadAsync(file, () => InvokeAsync(StateHasChanged));
        }
    }
}