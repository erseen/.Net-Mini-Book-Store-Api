using AutoMapper;
using Business.Abstract;
using Data.Dto;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var book = await _bookService.GetAllBooksAsync();
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody]CreateBookDto bookDto)
        {
            await _bookService.CreateBookAsync(bookDto);
            return Ok(bookDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute(Name = "id")] int id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneBookById([FromRoute(Name ="id")]int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult>UpdateOneBook([FromBody] UpdateBookDto bookDto)
        {
            await _bookService.UpdateBookAsync(bookDto);
            return Ok();
        }
    

    }
}
