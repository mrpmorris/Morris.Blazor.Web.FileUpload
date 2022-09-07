using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris.Blazor.Web.FileUpload;

public class FormData : IAsyncDisposable
{
    private readonly int FormDataId;
    private readonly IJSRuntime JSRuntime;
    private readonly DotNetObjectReference<FormData> JSReference;

    private FormData(IJSRuntime jSRuntime, int formDataId)
    {
        JSReference = DotNetObjectReference.Create(this);
        JSRuntime = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
        FormDataId = formDataId;
    }

    public static async ValueTask<FormData> CreateAsync(IJSRuntime jsRuntime)
    {
        ArgumentNullException.ThrowIfNull(jsRuntime);

        int formDataId = await jsRuntime.InvokeAsync<int>("Morris.Blazor.Web.MultiFileUploader.create");

        var result = new FormData(jsRuntime, formDataId);
        return result;

    }

    public async Task AddFileAsync()
    {
        await JSRuntime.InvokeVoidAsync("Morris.Blazor.Web.MultiFileUploader.addFile", FormDataId);
    }


    public async ValueTask PostAsync(string url)
    {
        await JSRuntime.InvokeVoidAsync("Morris.Blazor.Web.MultiFileUploader.post", FormDataId, url);
    }

    public async ValueTask DisposeAsync()
    {
        await JSRuntime.InvokeVoidAsync("Morris.Blazor.Web.MultiFileUploader.dispose", FormDataId);
    }
}
