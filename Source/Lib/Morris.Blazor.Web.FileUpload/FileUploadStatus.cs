namespace Morris.Blazor.Web.FileUpload;

public enum FileUploadStatus
{
    Queued,
    InProgress,
    Failed,
    Cancelled,
    Completed
}