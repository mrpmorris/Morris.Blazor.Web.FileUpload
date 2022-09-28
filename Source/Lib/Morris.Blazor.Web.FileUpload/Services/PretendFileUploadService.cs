namespace Morris.Blazor.Web.FileUpload.Services;

public class PretendFileUploadService : IFileUploadService
{
    public async ValueTask UploadAsync(
        FileUploadInfo fileUploadInfo,
        Action? onProgress = null,
        CancellationToken cancellationToken = default)
    {
        for (int i = 1; i <= 10; i++)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(250);
                fileUploadInfo.TotalBytesUploaded = fileUploadInfo.BrowserFile.Size * i / 10;
                onProgress?.Invoke();
                Console.WriteLine($"{fileUploadInfo.BrowserFile.Name} {fileUploadInfo.TotalBytesUploaded}");
            }
        }
    }
}
