using FluentValidation;
using BookStore.BookOperations.GetBookDetail;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>{

        public GetBookDetailQueryValidator(){
            RuleFor(query => query.BookId).GreaterThan(0);   
        }

    }

}