using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public  ICollection<Author> Authors { get; set; }

    }
}
