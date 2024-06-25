namespace Reservation.Application.Images.Commands.UploadImage;

public record UploadImageCommandRequest(IFormFile File) : IRequest<string>;

public class UploadImageCommandHandler(IUploadImageProvider uploadImage) : IRequestHandler<UploadImageCommandRequest, string>
{
    private readonly IUploadImageProvider _uploadImage = uploadImage;

    public async Task<string> Handle(UploadImageCommandRequest request, CancellationToken cancellationToken)
        => await _uploadImage.Insert(request.File)
            ?? throw new UploadImageUnsuccessfulException();
}