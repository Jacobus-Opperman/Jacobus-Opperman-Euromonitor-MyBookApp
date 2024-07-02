using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
public class BookSubscriptionContext : DbContext
{
    public BookSubscriptionContext(DbContextOptions<BookSubscriptionContext> options)
    : base(options)
    {
    }

    //public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
}