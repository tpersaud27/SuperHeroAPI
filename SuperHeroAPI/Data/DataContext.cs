using System;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        // SuperHeroes will be the name of the table in the data base
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
