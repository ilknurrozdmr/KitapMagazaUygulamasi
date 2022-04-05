using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStore.Common;
using BookStore.DBOperations;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookOperations.GetBook
{
    public class GetBooksQuery
    {
       private readonly BookStoreDbContext _dbContext;
       private readonly IMapper _mapper;
       public GetBooksQuery(BookStoreDbContext dbContext,IMapper mapper)
       {
        _dbContext=dbContext;
        _mapper=mapper;
       }

       public List<BooksViewModel> Handle(){
            var bookList=_dbContext.Books.Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
             //new List<BooksViewModel>();
        //  foreach (var book in bookList)
        //     {
        //         vm.Add(new BooksViewModel(){
        //             Title=book.Title,
        //             Genre= ((GenreEnum)book.GenreId).ToString(),
        //             PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
        //             PageCount=book.PageCount
        //         });
        //     }
            return vm;   
        }
    }

    public class BooksViewModel{ //bunun adının yanında vievmodel olması bunun uı tarafından kullanılacağını ifade ediyor
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
}