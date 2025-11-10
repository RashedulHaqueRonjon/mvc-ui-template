using System;
using System.Collections.Generic;
using MVCUITemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCUITemplate.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;

}
