using Microsoft.AspNetCore.Mvc;
using ProxyPatternCaching.Application.Dtos.Requests;
using ProxyPatternCaching.Application.Services.Interfaces;

namespace ProxyPatternCaching.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;


    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(CreateBookRequest book)
    {
        try
        {
            var response = await _bookService.AddBook(book);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(string id)
    {
        try
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}