using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Book> Books { get; private set; } = new HashSet<Book>();
    }
}