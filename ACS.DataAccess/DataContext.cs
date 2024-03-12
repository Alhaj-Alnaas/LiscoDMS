using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.DataAccess
{
   public class DataContext : IdentityDbContext<BaseUser>
    {
        public DataContext(DbContextOptions<DataContext>options ):base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Doc> Docements { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MessagesCategories> MessagesCategories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ApplicationUser> MainUsers { get; set; }
        public DbSet<SubApplicationUser> SubUsers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CollectingMessage> CollectingMessages { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
