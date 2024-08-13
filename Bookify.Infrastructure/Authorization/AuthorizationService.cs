﻿using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Authorization;

internal sealed class AuthorizationService(ApplicationDbContext dbContext)
{
    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var roles = await dbContext.Set<User>()
            .Where(u => u.IdentityId == identityId)
            .Select(u => new UserRolesResponse
            {
                UserId = u.Id,
                Roles = u.Roles.ToList()
            })
            .FirstAsync();

        return roles;
    }

    //public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    //{
    //    var permissions = await dbContext.Set<User>()
    //        .Where(u => u.IdentityId == identityId)
    //        .SelectMany(u => u.Roles.Select(r => r.Permissions))
    //        .FirstAsync();

    //    return permissions.Select(p => p.Name).ToHashSet();
    //}
}