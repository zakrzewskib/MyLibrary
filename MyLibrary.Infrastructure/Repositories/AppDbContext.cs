using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });

            modelBuilder.Entity<BookAuthor>().
                HasOne(x => x.Book).WithMany(x => x.BookAuthors).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BookAuthor>().
                HasOne(x => x.Author).WithMany(x => x.BookAuthors).HasForeignKey(x => x.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
