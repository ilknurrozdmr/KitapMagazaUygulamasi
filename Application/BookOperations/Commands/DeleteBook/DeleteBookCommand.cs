using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using BookStore.DBOperations;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
           _dbContext=dbContext;
        }

        public void Handle()
        {
           var book=_dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
          
            if(book == null)
                throw new InvalidOperationException("Silinecek Kitap Bulumadi.");
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}