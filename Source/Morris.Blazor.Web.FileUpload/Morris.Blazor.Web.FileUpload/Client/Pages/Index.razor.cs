using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Morris.Blazor.Web.FileUpload.Client.Pages;

public partial class Index
{
    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

    private async Task Test()
    {
        var x = await FormData.CreateAsync(JSRuntime);
        await x.AddFileAsync();
        await x.PostAsync("api/test/upload");
        await x.DisposeAsync();
    }

    private void SelectedFilesChanged(InputFileChangeEventArgs e)
    {
        Console.WriteLine($"{e.FileCount} files");
        foreach (IBrowserFile file in e.GetMultipleFiles(int.MaxValue))
        {
            Console.WriteLine($"Added file {file.Name}");
        }
    }

    record FileUploadInfo(string htmlInputId, int fileIndex, IBrowserFile browserFile);
}