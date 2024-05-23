namespace Domain.Entities;

public sealed class Users
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string HashedPassword { get; set; } = default!;
}