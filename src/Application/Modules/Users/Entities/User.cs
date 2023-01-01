namespace Application.Modules.Users.Entities;

public sealed class User
{
    public User()
    {
    }

    public User(string emailAddress, string username)
    {
        this.EmailAddress = emailAddress;
        this.Username = username;
    }

    public int Id { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string Username { get; set; } = null!;
}
