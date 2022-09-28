namespace Morris.Blazor.Web.FileUpload;

public class FileUploadException : Exception
{
    public FileUploadInfo FileUploadInfo { get; }

    public FileUploadException(
        string message,
        FileUploadInfo fileUploadInfo,
        Exception? innerException = null)
        : base(message ,innerException)
    {
        FileUploadInfo = fileUploadInfo ?? throw new ArgumentNullException(nameof(fileUploadInfo));
    }
}
