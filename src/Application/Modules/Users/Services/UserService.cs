using Application.Modules.Core.Database;
using Application.Modules.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.Users.Services;

public sealed class UserService : IAsyncDisposable
{
    private readonly ApplicationDbContext dbContext;

    public UserService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        this.dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<User> GetUsers()
    {
        return this.dbContext.Users.AsQueryable();
    }

    public IQueryable<User?> GetUserById(int id)
    {
        return this.dbContext.Users.Where(u => u.Id == id);
    }

    public IQueryable<User?> GetActiveUser()
    {
        // Temporarily hard-coded ID.
        return this.dbContext.Users.Where(u => u.Id == 1);
    }

    public ValueTask DisposeAsync()
    {
        return this.dbContext.DisposeAsync();
    }
}
