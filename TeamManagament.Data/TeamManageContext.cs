using Microsoft.EntityFrameworkCore;
using TeamManagement.Domain.Entities;

namespace TeamManagament.Data
{
    public class TeamManageContext:DbContext
    {
        public TeamManageContext() { }

        public TeamManageContext(DbContextOptions<TeamManageContext> options):base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TeamManageDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().HasData(
                 new TeamMember { MemberId = 1, Name = "John" },
        new TeamMember { MemberId = 2, Name = "Smith" },
        new TeamMember { MemberId = 3, Name = "Grey" },
        new TeamMember { MemberId = 4, Name = "Alice" },
        new TeamMember { MemberId = 5, Name = "Bob" },
        new TeamMember { MemberId = 6, Name = "Carol" },
        new TeamMember { MemberId = 7, Name = "David" },
        new TeamMember { MemberId = 8, Name = "Eve" },
        new TeamMember { MemberId = 9, Name = "Frank" },
        new TeamMember { MemberId = 10, Name = "Grace" }
                );

            modelBuilder.Entity<Team>().HasData(
                new Team {TeamId=111, TeamName="A" },
                new Team {TeamId=222,TeamName="B" },
                new Team { TeamId=333,TeamName="C"}
                );


        }

       public DbSet<TeamMember> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
