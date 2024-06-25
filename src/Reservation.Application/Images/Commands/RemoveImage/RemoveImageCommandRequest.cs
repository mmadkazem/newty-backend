namespace Reservation.Application.Images.Commands.RemoveImage;


public record RemoveImageCommandRequest(string ObjectKey) : IRequest<string>;

public sealed class RemoveImageCommandHandler(IUploadImageProvider uploadImage) : IRequestHandler<RemoveImageCommandRequest, string>
{
    private readonly IUploadImageProvider _uploadImage = uploadImage;

    public async Task<string> Handle(RemoveImageCommandRequest request, CancellationToken cancellationToken)
        => await _uploadImage.Remove(request.ObjectKey)
            ?? throw new ImageNotFoundException();
}