namespace Reservation.Application.ExternalServices.UploadImageProvider;

public interface IUploadImageProvider
{
    Task<string> Insert(IFormFile file);
    Task<string> Remove(string objectKey);
    Task<string> GetUrl(string objectKey);
}