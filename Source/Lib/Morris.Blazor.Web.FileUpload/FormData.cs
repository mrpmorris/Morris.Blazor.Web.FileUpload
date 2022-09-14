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
    private readonly JSCallbacks Callbacks;
    private readonly DotNetObjectReference<JSCallbacks> CallbacksJSReference;

    private FormData(IJSRuntime jSRuntime, int formDataId)
    {
        JSRuntime = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
        FormDataId = formDataId;
        Callbacks = new JSCallbacks();
        CallbacksJSReference = DotNetObjectReference.Create(Callbacks);
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
        await JSRuntime.InvokeVoidAsync("Morris.Blazor.Web.MultiFileUploader.post", FormDataId, url, CallbacksJSReference);
    }

    public async ValueTask DisposeAsync()
    {
        CallbacksJSReference.Dispose();
        await JSRuntime.InvokeVoidAsync("Morris.Blazor.Web.MultiFileUploader.dispose", FormDataId);
    }

    private class JSCallbacks
    {
        [JSInvokable("OnProgress")]
        public Task OnProgress(long uploaded, long fileSize)
        {
            Console.WriteLine($"Uploaded {uploaded} of {fileSize}");
            return Task.CompletedTask;
        }
    }
}
