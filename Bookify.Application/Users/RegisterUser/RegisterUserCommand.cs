﻿using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;