using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookSubscriptionContext _context;

    public BooksController(BookSubscriptionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var unsubscribedBooks = await (from book in _context.Books
                                 join subscription in _context.Subscriptions
                                 on book.Id equals subscription.BookId into bookSubscriptions
                                 from subscription in bookSubscriptions.DefaultIfEmpty()
                                 where subscription == null
                                 select book).ToListAsync();

        return unsubscribedBooks;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost("{bookId}/subscription")]
    public async Task<IActionResult> AsignBookSubscription(int bookId)
    {
        var subscriptions = await _context.Subscriptions.OrderByDescending(s => s.Id).ToListAsync();

        var newId = 1;
        if (subscriptions.Count > 0)
        {
            newId = subscriptions.FirstOrDefault().Id + 1;
        }

        var booksubscription = new Subscription
        {
            Id = newId,
            BookId = bookId,
        };

        _context.Subscriptions.Add(booksubscription);

        await _context.SaveChangesAsync();
        return Ok(booksubscription);
    }
}