using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NamelessApi.Domain;

namespace NamelessApi.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }


        public DbSet<Game> Games { get; set; }
        public DbSet<GameIgdb> GamesIgdb { get; set; }
    }
}
