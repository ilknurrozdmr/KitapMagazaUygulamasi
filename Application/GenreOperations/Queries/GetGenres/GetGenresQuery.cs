using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using System.Collections.Generic;

namespace BookStore.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public List<GenresViewModel> Handle()
        {
             var genres=_context.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
             List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
             return returnObj;
        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    } 
}