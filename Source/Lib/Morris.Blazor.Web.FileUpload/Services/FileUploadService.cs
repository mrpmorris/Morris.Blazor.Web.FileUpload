namespace Morris.Blazor.Web.FileUpload.Services;

public interface IFileUploadService
{
    ValueTask UploadAsync(
        FileUploadInfo fileUploadInfo,
        Action? onProgress = null,
        CancellationToken cancellationToken = default);
}
