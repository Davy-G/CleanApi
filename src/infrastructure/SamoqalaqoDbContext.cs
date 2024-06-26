﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure;

public class SamoqalaqoDbContext(DbContextOptions<SamoqalaqoDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Users> Users { get; set; }
}