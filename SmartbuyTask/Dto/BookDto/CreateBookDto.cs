using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Dto.BookDto
{
    public class CreateBookDto
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
    }
}
