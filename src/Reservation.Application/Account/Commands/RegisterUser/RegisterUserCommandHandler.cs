namespace Reservation.Application.Account.Commands.RegisterUser;


public sealed class RegisterUserCommandHandler(ICacheProvider cache)
        : IRequestHandler<RegisterUserCommandRequest>
{
        private readonly ICacheProvider _cache = cache;

        public async Task Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
                => await _cache.SetAsync<UserCacheVM>(nameof(User) + request.PhoneNumber, new(request.FullName, request.PhoneNumber));
}