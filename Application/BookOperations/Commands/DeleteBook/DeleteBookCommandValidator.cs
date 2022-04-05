using BookStore.BookOperations.DeleteBook;
using FluentValidation;

namespace BookStore.BookOperations.CreateBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand> //DeleteBookCommand modelinin özelliklerini doğrulamak istersem böyle bir sınıf oluşturmam gerekir.
    {

        public DeleteBookCommandValidator(){
            //RuleFor(command => command.Surname).NotNull(); >> surnama Boş olamaz
            RuleFor(command => command.BookId).GreaterThan(0);   
        }

    }

}