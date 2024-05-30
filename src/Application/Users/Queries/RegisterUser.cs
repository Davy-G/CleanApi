namespace Application.Users.Queries;

using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using MediatR;
using Domain.Entities;

public sealed record Register(string Username, string Password) : IRequest<string>;

public sealed record RegistrationHandler(IAppDbContext DbContext) : IRequestHandler<Register, string>
{
    public async Task<string> Handle(Register request, CancellationToken ct)
    {
        var username = request.Username;
        var passwordhash = BCrypt.HashPassword(request.Password, 13);
        var check = await DbContext.Set<Users>()
            .Where(x => x.Username == request.Username).FirstOrDefaultAsync(ct);
        if (check is not null)
        {
            return "could not register user";
        }
        else
        {
            DbContext.Set<Users>().Add(new Users()
            {
                Username = username,
                HashedPassword = passwordhash
            });
            await DbContext.SaveChangesAsync(ct);
            return "User registered successfully";
        }
    }
}