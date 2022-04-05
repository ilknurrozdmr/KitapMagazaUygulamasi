using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBook;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{
   [ApiController]
   [Route("[controller]s")]
   public class BookController : ControllerBase
   {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;

      public BookController(BookStoreDbContext context, IMapper mapper)
     {
       _context = context;
       _mapper=mapper;
     }

      [HttpGet] 
      public IActionResult GetBooks(){
           /* var bookList=_context.Books.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;*/
            GetBooksQuery query =new GetBooksQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
         }

      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         BookDetailViewModel result;
         GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
         query.BookId=id;
         GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
         validator.ValidateAndThrow(query);
         result=query.Handle();
         
         return Ok(result);
      }

      //[HttpGet] 
      //public Book Get([FromQuery] string id)
      //{
      //  var book=BookList.Where(book => book.Id==Convert.ToInt32(id)).SingleOrDefault();
      // return book;
      //}

      [HttpPost]
      public IActionResult AddBook([FromBody] CreateBookModel newBook)
      {
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=newBook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            //ValidationResult result=validator.Validate(command);
            validator.ValidateAndThrow(command); //ValidateAndThrow metodu önce kontrolleri yapar, eğer hata varsa hata mesajlarını fırlatır.
            command.Handle();
            // if(!result.IsValid) >>IsValid özelliği validasyon sonucunda hata olup olmadığını geri döner
            // foreach (var item in result.Errors) >> result objesi Errorsadında bir de hata mesajlarını barındıran bir dizi bulundurur.
            //   Console.WriteLine("Özellik" + item.PropertyName + "- Error Message: "+item.ErrorMessage);
            // else
            //  command.Handle();
            return Ok();
      }

      [HttpPut("{id}")]
      public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
      {
         UpdateBookCommand command=new UpdateBookCommand(_context);
         command.BookId=id;
         command.Model=updatedBook;
         UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
         validator.ValidateAndThrow(command);
         command.Handle();
         
         return Ok();
      }

      [HttpDelete("{id}")]
      public IActionResult DeleteBook(int id)
      {
          DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command); 
            command.Handle();
         
         return Ok();
      }
   }
}