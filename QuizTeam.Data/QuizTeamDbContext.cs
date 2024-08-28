using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizTeam.Domain.Entities;

namespace QuizTeam.Data
{
    public class QuizTeamDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=QuizTeamDb2024;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "John Doe" },
                new Member { Id = 2, Name = "Jane Smith" },
                new Member { Id = 3, Name = "Alice Johnson" },
                new Member { Id = 4, Name = "Bob Brown" },
                new Member { Id = 5, Name = "Charlie Davis" },
                new Member { Id = 6, Name = "David Wilson" },
                new Member { Id = 7, Name = "Emma Clark" },
                new Member { Id = 8, Name = "Frank Thompson" },
                new Member { Id = 9, Name = "Grace Lee" },
                new Member { Id = 10, Name = "Hannah White" }
            );
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
