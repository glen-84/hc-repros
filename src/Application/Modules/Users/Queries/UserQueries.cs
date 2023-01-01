using Application.Modules.Users.Entities;
using Application.Modules.Users.Services;

namespace Application.Modules.Users.Types;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class UserQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers([Service] UserService userService)
    {
        return userService.GetUsers();
    }

    [NodeResolver]
    [UseSingleOrDefault]
    [UseProjection]
    public IQueryable<User?> GetUserById(int id, [Service] UserService userService)
    {
        return userService.GetUserById(id);
    }

    // Issue #1: UseSingleOrDefault causes the `GraphQLType` to be ignored.
    [GraphQLType("ActiveUser")]
    [UseSingleOrDefault]
    [UseProjection]
    public IQueryable<User?> GetActiveUser([Service] UserService userService)
    {
        return userService.GetActiveUser();
    }
}
