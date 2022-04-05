using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Entities;

namespace BookStore.DBOperations
{
   public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }
            context.Authors.AddRange(
                  new Author
                  {
                     Name = "Özdemir",
                     Surname = "Asaf",
                     Birthday = new DateTime(1923, 6, 11)
                  },
                new Author
                {
                    Name = "Turgut",
                    Surname = "Uyar",
                    Birthday = new DateTime(1927, 8, 4)
                },
                new Author
                {
                    Name = "Oğuz",
                    Surname = "Atay",
                    Birthday = new DateTime(1934, 10, 12)
                });

             context.Genres.AddRange(
                new Genre
                {
                   Name="Personel Growth"
                },
                new Genre
                {
                   Name="Science Fiction"
                },
                new Genre
                {
                   Name="Romance"
                }

             );

            context.Books.AddRange(
               new Book
         {
            Title="Lean Startup",
            GenreId=1, 
            PageCount=200,
            PublishDate=new DateTime(2001,06,12)
            
         },
         new Book
         {
            Title="Hearland",
            GenreId=2, 
            PageCount=250,
            PublishDate=new DateTime(2010,05,23)
            
         },
         new Book
         {
            Title="Dune",
            GenreId=2, 
            PageCount=540,
            PublishDate=new DateTime(2001,06,12)
            
         });

            context.SaveChanges();
        }
    }
} 
}
