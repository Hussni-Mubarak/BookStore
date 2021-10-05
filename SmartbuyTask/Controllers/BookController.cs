using AutoMapper;
using BookStore.Dto.BookDto;
using BookStore.Helpers;
using BookStore.Helpers.Paginations;
using BookStore.Models;
using BookStore.Services.Interface.BookStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _repo;
        private readonly IMapper _mapper;

        public BookController(IBook repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("Books")]
        public async Task<IActionResult> Books()
        {
            var Books = await _repo.GetAll();
            return Ok(Books);
        }
        [HttpGet("BookPagenation")]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationParams paginationParams)
        {
            var users = await _repo.GetUserPagedList(paginationParams);

            //var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }


        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            var BookToCreate = _mapper.Map<Book>(createBookDto);

            _repo.Add(BookToCreate);
            await _repo.SaveChanges();
            return Ok(BookToCreate);
        }

        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> Delete(int id)
        {
            var exitsBook = await _repo.GetById(id);

            //check if Book exit or not 
            if (exitsBook != null)
            {
                _repo.Remove(exitsBook);

                //save changes
                await _repo.SaveChanges();

                return Ok("Book Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id, BookListDto BookListDto)
        {
            //Get Book From Database
            var dbBook = await _repo.GetById(id);

            //Update Book Detials
            dbBook.CategoryId = dbBook.CategoryId;
            dbBook.Name = BookListDto.Name;
            dbBook.Description = BookListDto.Description;


            //Save Changes
            await _repo.SaveChanges();

            return Ok("Book Updated Successfully ");
        }

    }
}

