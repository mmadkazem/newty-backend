namespace Reservation.Application.ExternalServices.UploadImageProvider;

public interface IObjectStorageProvider
{
    Task<string> Insert(IFormFile file, Guid subjectId);
    Task<string> Remove(string objectKey);
    Task<string> GetUrl(string objectKey);
}