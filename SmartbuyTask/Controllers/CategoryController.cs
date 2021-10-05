using AutoMapper;
using BookStore.Dto.CategoryDto;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategory repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("Categorys")]
        public async Task<IActionResult> Categorys()
        {
            var Categorys = await _repo.GetAll();
            return Ok(Categorys);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var CategoryToCreate = _mapper.Map<Category>(createCategoryDto);
            _repo.Add(CategoryToCreate);
            await _repo.SaveChanges();
            return Ok(CategoryToCreate);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete(int id)
        {
            var exitsCategory = await _repo.GetById(id);

            //check if Category exit or not 
            if (exitsCategory != null)
            {
                _repo.Remove(exitsCategory);

                //save changes
                await _repo.SaveChanges();

                return Ok("Category Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id, CreateCategoryDto createCategoryDto)
        {
            //Get Category From Database
            var dbCategory = await _repo.GetById(id);

            //Update Category Detials
            dbCategory.Id = dbCategory.Id;
            dbCategory.CategoryName = createCategoryDto.CategoryName;

            //Save Changes
            await _repo.SaveChanges();

            return Ok("Category Updated Successfully ");
        }

    }
}

