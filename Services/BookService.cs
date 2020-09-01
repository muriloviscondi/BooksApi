using BooksApi.Models;
using MongoDB.Driver;

namespace BooksApi.Services
{
  public class BookService
  {

    private readonly IMongoCollection<Book> _books;

    public BookService(IBookstoreDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _books = database.GetCollection<Book>(settings.BooksCollectionName)
    }
  }
}