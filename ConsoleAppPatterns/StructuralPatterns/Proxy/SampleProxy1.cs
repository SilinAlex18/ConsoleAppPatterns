using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppPatterns.StructuralPatterns.Proxy
{
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public PageContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-J13R395\SQLEXPRESS;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().HasData(
                new Page[]
                {
                new Page { Id=1, Number = 1, Text = "Lorem ipsum dolor sit amet" },
                new Page { Id=2, Number = 2, Text = "Ut enim ad minim veniam" },
                new Page { Id=3, Number = 3, Text = "Excepteur sint occaecat cupidatat non proident" }
                });
        }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        PageContext db;

        public BookStore()
        {
            db = new PageContext();
        }

        public Page GetPage(int number)
        {
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;

        public BookStoreProxy()
        {
            pages = new List<Page>();
        }

        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }

        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }
}
