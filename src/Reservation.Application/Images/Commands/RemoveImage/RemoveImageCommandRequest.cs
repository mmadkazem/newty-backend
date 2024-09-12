namespace Reservation.Application.Images.Commands.RemoveImage;


public record RemoveImageCommandRequest(string ObjectKey, Guid SubjectId) : IRequest<string>
{
    public static RemoveImageCommandRequest Create(string objectKey, Guid subjectId)
        => new(objectKey, subjectId);
}

public sealed class RemoveImageCommandHandler(IObjectStorageProvider uploadImage) : IRequestHandler<RemoveImageCommandRequest, string>
{
    private readonly IObjectStorageProvider _uploadImage = uploadImage;

    public async Task<string> Handle(RemoveImageCommandRequest request, CancellationToken cancellationToken)
    {
        var subjectReceipt = request.ObjectKey.Split("@").First();
        if (subjectReceipt != request.SubjectId.ToString())
        {
            throw new NotAllowedRemovedException();
        }

        return await _uploadImage.Remove(request.ObjectKey)
            ?? throw new ImageNotFoundException();
    }
}