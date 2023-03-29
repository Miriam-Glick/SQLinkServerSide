using Microsoft.EntityFrameworkCore;
using SqLinkServer.DataDB;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SqLinkServer.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {   Id= 1,
                    Name = "Test Test",
                    Team = "Developers",
                    Email = "Test@test.com",
                    Password = "Tr12345",
                    JoinedAt = new DateTime(2000, 4, 16),
                    Avatar = "https://avatarfiles.alphacoders.com/164/thumb-164632.jpg",
                },
                new User
                {   Id = 2,  
                    Name = "SqLink Test",
                    Team = "Developers",
                    Email = "Test@sqlink.com",
                    Password = "sq12345",
                    JoinedAt = new DateTime(2000, 5, 20),
                    Avatar = "https://avatarfiles.alphacoders.com/164/thumb-164632.jpg",
                }

                );


            modelBuilder.Entity<Project>().HasData(
            new Project {Id=1, Name = "Main Project", Score = 88, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 1 },
            new Project {Id = 2,     Name = "Main Project", Score = 95, DurationInDays = 35, BugsCount = 7, MadeDadeline = false, UserId = 1 },
            new Project {Id = 3, Name = "Main Project", Score = 93, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 1 },
            new Project {Id = 4, Name = "Main Project", Score = 75, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 1 },
            new Project {Id = 5, Name = "Main Project", Score = 67, DurationInDays = 35, BugsCount = 7, MadeDadeline = false, UserId = 1 },
            new Project {Id = 6, Name = "Main Project", Score = 60, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 1 },
            new Project {Id = 7, Name = "Main Project", Score = 88, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 1 },
            new Project {Id = 8, Name = "Main Project", Score = 45, DurationInDays = 35, BugsCount = 7, MadeDadeline = false, UserId = 2 },
            new Project {Id = 9, Name = "Main Project", Score = 88, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 2 },
            new Project {Id = 10, Name = "Main Project", Score = 99, DurationInDays = 35, BugsCount = 7, MadeDadeline = false, UserId = 2 },
            new Project {Id = 11, Name = "Main Project", Score = 95, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 2 },
            new Project {Id = 12, Name = "Main Project", Score = 68, DurationInDays = 35, BugsCount = 7, MadeDadeline = true, UserId = 2 }


            );
        }
    }
}
