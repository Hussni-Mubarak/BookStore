using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Dto.AuthorDto
{
    public class CreateAuthorDto
    {
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
