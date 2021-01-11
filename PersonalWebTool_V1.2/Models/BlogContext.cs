using Microsoft.EntityFrameworkCore;
using PersonalWebTool_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebTool_V1.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PostCategory> Categories { get; set; }
        public DbSet<GratefulnessEntry> GratefulnessEntries { get; set; }
        public DbSet<GratefulnessUnit> GratefulnessUnits { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitDay> HabitDays {get;set;}
        public DbSet<HabitQuantity> HabitQuantities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostCategory>().HasData(
                new PostCategory { PostCategoryID = 1, Name = "Adventure" },
                new PostCategory { PostCategoryID = 2, Name = "Optimization" },
                new PostCategory { PostCategoryID = 3, Name = "Programming" },
                new PostCategory { PostCategoryID = 4, Name = "Miscellaneous" });

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    BlogPostID = 1,
                    Title = "Initialize Personal Web Tool",
                    Body = "This first blog post in my Personal Web Tool. " +
                    "This first blog post in my Personal Web Tool. " +
                    "This first blog post in my Personal Web Tool. " +
                    "This first blog post in my Personal Web Tool. ",
                    PostCategoryID = 4,
                    ImageName = "open-sign"
                },
                new BlogPost
                {
                    BlogPostID = 2,
                    Title = "Initialize Personal Web Tool",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor" +
                    " incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                    " ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in" +
                    " voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                    " sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    PostCategoryID = 1,
                    ImageName = "vzhodne-alpe"
                });

            modelBuilder.Entity<GratefulnessUnit>().HasData(
                new GratefulnessUnit
                {
                    GratefulnessUnitID = 1,
                    Details = "Test1",
                    Main = "test1",
                    GratefulnessEntryID = 1
                }) ;

            modelBuilder.Entity<GratefulnessEntry>().HasData(
                new GratefulnessEntry
                {
                    GratefulnessEntryID = 1
                });

            


        }
    }
}
