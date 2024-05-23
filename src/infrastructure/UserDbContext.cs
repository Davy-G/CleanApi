using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure;

public class UserDbContext(DbContextOptions options) :  DbContext(options), IAppDbContext
{
    public DbSet<Users> User { get; set; }
}