using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries;
using MediatR;


public sealed record GetUserById(long Id) : IRequest<Person?>;

public sealed record GetUserByIdHandler(IappDbContext Dbcontext) : IRequestHandler<GetUserById,Person?>
{
    public async Task<Person?> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var resp = await Dbcontext.Set<Person>().Where(x => x.id == request.Id).FirstOrDefaultAsync(cancellationToken);
        return resp;
    }
}
