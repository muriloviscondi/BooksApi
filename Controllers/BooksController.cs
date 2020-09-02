using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
      _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<Book>> Get() =>
      _bookService.Get();

    [HttpGet("{id:length(24)}", Name = "GetBook")]
    public ActionResult<Book> Get(string id)
    {
      var book = _bookService.Get(id);

      if (book == null)
      {
        return NotFound();
      }

      return book;
    }

  }
}
