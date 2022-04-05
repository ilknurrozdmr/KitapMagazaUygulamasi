using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using AutoMapper;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookOperations.GetBookDetail
{
     public class GetBookDetailQuery
   {
     public int BookId {get; set;}
     private readonly BookStoreDbContext _dbContext;
     private readonly IMapper _mapper;
     
     public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
     {
       _dbContext=dbContext;
       _mapper=mapper;
     }

     public BookDetailViewModel Handle()
     {
         var book=_dbContext.Books.Include(x=>x.Genre).Where(book=>book.Id==BookId).SingleOrDefault();
         if(book is null)
         throw new InvalidOperationException("Kitap Bulunamadı");
         BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book);
        //  vm.Title=book.Title;
        //  vm.PageCount=book.PageCount;
        //  vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
        //  vm.Genre=((GenreEnum)book.GenreId).ToString();
         return vm;
     }
  }

  public class BookDetailViewModel
  {
      public string Title { get; set; }
      public string Genre { get; set; }
      public int PageCount { get; set; }
      public string PublishDate { get; set; }
  }
}