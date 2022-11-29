﻿using Microsoft.EntityFrameworkCore;

namespace ApiRest.Model.Context
{
    public class MySQLContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<AuthUser> Users { get; set; }

        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base (options)
        {
            
        }
    }
}
