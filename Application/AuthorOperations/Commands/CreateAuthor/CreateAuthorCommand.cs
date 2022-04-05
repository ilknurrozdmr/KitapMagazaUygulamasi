using System;
using System.Linq;
using System.Windows.Input;
using FluentValidation;
//using BookStore.Applications.OperationAbstract;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut.");
            
            author=new Author();
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.Birthday = Model.Birthday;                
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}