using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application.Users.Queries;
using MediatR;


public sealed record GetPerson(long Id) : IRequest<Person?>;
public sealed record GetUserByName(string Name, string? Surname) : IRequest<List<Person>?>;

public sealed record GetUserByNameHandler(IAppDbContext DbContext) : IRequestHandler<GetUserByName, List<Person>?>
{
    public async Task<List<Person>?> Handle(GetUserByName request, CancellationToken cancellationToken)
    {
        var resp = await DbContext.Set<Person>()
            .Where(x => request.Surname == "" ? request.Name == x.name 
                : request.Name == x.name && request.Surname == x.surname)
            .ToListAsync(cancellationToken);
        return resp;
    }
}
public sealed record GetUserByIdHandler(IAppDbContext Dbcontext) : IRequestHandler<GetPerson,Person?>
{
    public async Task<Person?> Handle(GetPerson request, CancellationToken cancellationToken)
    {
        var resp = await Dbcontext.Set<Person>()
            .Where(x => x.id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return resp;
    }
}
