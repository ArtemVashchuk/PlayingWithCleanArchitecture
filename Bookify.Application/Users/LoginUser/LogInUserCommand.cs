using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Users.LoginUser
{
    public sealed record LogInUserCommand(string Email, string Password)
        : ICommand<AccessTokenResponse>;
}
