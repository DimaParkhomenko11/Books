using System.Threading.Tasks;
using Books.Model;
using Microsoft.AspNetCore.Mvc;


namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        
        /*[HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }*/
        
        [HttpPost]
        public async Task<IActionResult> Create(Model.Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.CreateAsync(book);
            return Ok(book.id);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(string id, Model.Books booksData)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.UpdateAsync(id, booksData);
            return NoContent();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(book.id);
            return NoContent();
        }
    }
}