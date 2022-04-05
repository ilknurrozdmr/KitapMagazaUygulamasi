using AutoMapper;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBook;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using BookStore.Entities;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using Bookstore.Application.AuthorOperations.Queries.GetAuthors; 
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail; 
using BookStore.Application.AuthorOperations.Commands.CreateAuthor; 

namespace BookStore.Common
{
    public class MappingProfile : Profile
        {
        public MappingProfile()
        {
         CreateMap<CreateBookModel, Book>(); //<Source,Target> CreateBookModel objesi Book objesine maplenebilir demektir.
         CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src =>src.Genre.Name)); //her satırda uygula diyorum.
         CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src =>src.Genre.Name));
         

         CreateMap<Genre, GenresViewModel>();
         CreateMap<Genre, GenreDetailViewModel>();
         
         CreateMap<Author, AuthorsViewModel>();
         CreateMap<Author, AuthorDetailViewModel>();

        }
        }

}
