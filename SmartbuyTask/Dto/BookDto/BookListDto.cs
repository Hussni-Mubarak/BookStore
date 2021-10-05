using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Dto.BookDto
{
    public class BookListDto
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
       
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
