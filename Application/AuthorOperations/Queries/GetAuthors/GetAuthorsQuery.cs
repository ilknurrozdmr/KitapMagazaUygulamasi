using System.Collections.Generic;
using AutoMapper;
using BookStore.DBOperations;
using System.Linq;

namespace Bookstore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
           _dbContext = dbContext;
           _mapper = mapper;            
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _dbContext.Authors.OrderBy(x => x.Id);
            return _mapper.Map<List<AuthorsViewModel>>(authors);
        }
    }
    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}