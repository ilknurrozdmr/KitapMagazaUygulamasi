using System;
using BookStore.DBOperations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı");
            bool isAuthorHasBook = _dbContext.Books.Any(x=>x.AuthorId == AuthorId);
            if(isAuthorHasBook)
                throw new InvalidOperationException("Bu Yazarın kitabı vardır silmeden önce ilk kayıtlı kitapların silinmesi gerekiyor");

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}