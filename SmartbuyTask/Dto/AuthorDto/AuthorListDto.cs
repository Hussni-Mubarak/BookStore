using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Dto.AuthorDto
{
    public class AuthorListDto
    {
        public int AuthorId { get; set; }
     
        public string Name { get; set; }
        public string Bio { get; set; }
        public string BookName { get; set; }
    }
}
