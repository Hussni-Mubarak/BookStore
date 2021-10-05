using BookStore.Services.Interface.External;
using BookStore.Services.Repository.External;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {

        private readonly IRanking _repo;
        public ExternalController(IRanking repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetRanking")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {

            //Here is where I want to make the requisition
            var model = await _repo.GetRanking(id);

            //Validate if null
            if (model == null)
                return NotFound(); //or any other error code accordingly. Bad request is a strong candidate also.

            return Ok(model);
        }
    }
}
