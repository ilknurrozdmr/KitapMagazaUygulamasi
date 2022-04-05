using System;
using FluentValidation;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {

        public CreateBookCommandValidator(){
            RuleFor(command => command.Model.GenreId).GreaterThan(0); //GenreId nin 0 dan büyük olacağını garanti eder.
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date); //publish date in yıl bilgisi her zaman olduğumuz günden küçük olacağını garanti eder. NotEmpty:Boş olamaz
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4); //title ın boş olamayacağını ve minumum 4 karakterli olacağını garanti eder.
        }
    }
}