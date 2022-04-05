using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    public class Book
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //id colonunu auto increment olduğunu ifade eder eger computed şeçilirse bir fonksiyon yardımıylada idler oluşturulabilir.
         public int Id { get; set; }
         public string Title { get; set; }
         public int GenreId { get; set; }
         public Genre Genre { get; set; }
         public int AuthorId { get; set; }
         public Author Author { get; set; }  
         public int PageCount { get; set; }
         public DateTime PublishDate { get; set;} 
                        
    }
}