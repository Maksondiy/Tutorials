﻿using Microsoft.EntityFrameworkCore;

namespace Tutorials.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<Person> Person  { get; set; }
    }
}
