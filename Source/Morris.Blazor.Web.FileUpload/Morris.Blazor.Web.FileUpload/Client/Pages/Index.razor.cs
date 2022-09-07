using Microsoft.AspNetCore.Components;
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
}