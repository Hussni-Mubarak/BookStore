using AutoMapper;
using BookStore.Dto.AuthorDto;
using BookStore.Models;
using BookStore.Services.Interface.BookStore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _repo;
        private readonly IMapper _mapper;

        public AuthorController(IAuthor repo ,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("Authors")]
        public async Task<IActionResult> Authors()
        {
            var authors = await _repo.GetAll();
            return Ok(authors);
        }
        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var authorToCreate = _mapper.Map<Author>(createAuthorDto);
             _repo.Add(authorToCreate);
            await _repo.SaveChanges();
            return Ok(authorToCreate);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> Delete(int id)
        {
            var exitsAuthor = await _repo.GetById(id);

            //check if Author exit or not 
            if (exitsAuthor != null)
            {
                _repo.Remove(exitsAuthor);

                //save changes
                await _repo.SaveChanges();

                return Ok("Author Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(int id, CreateAuthorDto  createAuthorDto)
        {
            //Get Author From Database
            var dbAuthor = await _repo.GetById(id);

            //Update Author Detials
            dbAuthor.AuthorId = dbAuthor.AuthorId;
            dbAuthor.Name = createAuthorDto.Name;
            dbAuthor.Bio = createAuthorDto.Bio;
           

            //Save Changes
            await _repo.SaveChanges();

            return Ok("Author Updated Successfully ");
        }

    }
}
