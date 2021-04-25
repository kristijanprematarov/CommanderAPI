namespace Commander.Data
{
    using Commander.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>().HasData
                (
                    new Command { Id = 1, HowTo = "View status of git repository", CommandLine = "git status", Platform = "Git" },
                    new Command { Id = 2, HowTo = "View all files in folder including hidden", CommandLine = "ls -a", Platform = "Git" },
                    new Command { Id = 3, HowTo = "Stage all files in directory for commit", CommandLine = "git add .", Platform = "Git" },
                    new Command { Id = 4, HowTo = "View staged files for commit", CommandLine = "git diff", Platform = "Git" },
                    new Command { Id = 5, HowTo = "Commit with message", CommandLine = "git commit -m \"the message goes in here\" ", Platform = "Git" },
                    new Command { Id = 6, HowTo = "Push to git", CommandLine = "git push", Platform = "Git" },
                    new Command { Id = 7, HowTo = "Remove last commit", CommandLine = "git reset --hard HEAD~1", Platform = "Git" },
                    new Command { Id = 8, HowTo = "Add migration", CommandLine = "add-migration \"name of migration goes in here\"", Platform = "EF Core" },
                    new Command { Id = 9, HowTo = "Remove last migration", CommandLine = "remove-migration", Platform = "EF Core" },
                    new Command { Id = 10, HowTo = "Update Database", CommandLine = "update-database -verbose", Platform = "EF Core" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
