using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly BookSubscriptionContext _context;

    public SubscriptionsController(BookSubscriptionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetSubscription()
    {
        var subscribedBooks = await (from subscription in _context.Subscriptions
                                     join book in _context.Books
                                     on subscription.BookId equals book.Id
                                     select book).ToListAsync();

        return subscribedBooks;
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteSubscription(int bookId)
    {
        var subscribtion = await _context.Subscriptions.FirstOrDefaultAsync(s => s.BookId == bookId);

        if (subscribtion != null)
        {
            _context.Subscriptions.Remove(subscribtion);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }
}