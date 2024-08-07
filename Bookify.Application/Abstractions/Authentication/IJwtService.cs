﻿using Bookify.Domain.Abstractions;

namespace Bookify.Application.Abstraction.Authentication
{
    public interface IJwtService
    {
        public Task<Result<string>> GetAccessTokenAsync(
            string email,
            string password,
            CancellationToken cancellationToken = default);
    }
}
