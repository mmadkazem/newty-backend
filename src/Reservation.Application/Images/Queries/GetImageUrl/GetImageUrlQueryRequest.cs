namespace Reservation.Application.Images.Queries.GetImageUrl;


public record GetImageUrlQueryRequest(string ObjectKey) : IRequest<string>;


public sealed class GetImageUrlQueryHandler(IObjectStorageProvider uploadImage) : IRequestHandler<GetImageUrlQueryRequest, string>
{
    private readonly IObjectStorageProvider _uploadImage = uploadImage;

    public async Task<string> Handle(GetImageUrlQueryRequest request, CancellationToken cancellationToken)
        => await _uploadImage.GetUrl(request.ObjectKey)
            ?? throw new ImageNotFoundException();
}