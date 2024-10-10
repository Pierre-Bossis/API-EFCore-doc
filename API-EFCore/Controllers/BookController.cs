using API_EFCore.BLL.Interfaces;
using API_EFCore.DAL.Entities;
using API_EFCore.Models;
using API_EFCore.Tools.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBLLRepository _repo;

        public BookController(IBookBLLRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _repo.GetBooksAsync();
            var bookDtos = books.Select(book => book.ToDto()).ToList();

            return Ok(bookDtos);
        }
    }
}
