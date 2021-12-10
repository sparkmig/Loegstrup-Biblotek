using Microsoft.EntityFrameworkCore;
using Storage.Models.Book;
using Storage.Models.Event;
using Storage.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Context
{
    public class LibaryContext : DbContext
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryName> CategoryNames { get; set; }
        public DbSet<RuleModel> Rules { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Biblotek;User Id=sa;Password=1234;");
        }
    }
}
