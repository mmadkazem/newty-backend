namespace Reservation.Application.Images.Commands.UploadImage;

public record UploadImageCommandRequest(IFormFile File, Guid SubjectId) : IRequest<string>
{
    public static UploadImageCommandRequest Create(UploadImageDTO model, Guid subjectId)
        => new(model.File, subjectId);
}

public record UploadImageDTO(IFormFile File);

public class UploadImageCommandHandler(IObjectStorageProvider uploadImage) : IRequestHandler<UploadImageCommandRequest, string>
{
    private readonly IObjectStorageProvider _uploadImage = uploadImage;

    public async Task<string> Handle(UploadImageCommandRequest request, CancellationToken cancellationToken)
        => await _uploadImage.Insert(request.File, request.SubjectId)
            ?? throw new UploadImageUnsuccessfulException();
}