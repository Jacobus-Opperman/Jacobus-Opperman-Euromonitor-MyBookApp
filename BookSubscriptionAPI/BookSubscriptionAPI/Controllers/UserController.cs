//using Microsoft.AspNetCore.Mvc;

//[Route("api/[controller]")]
//[ApiController]
//public class UserController : ControllerBase
//{
//    private readonly BookSubscriptionContext _context;

//    public UserController(BookSubscriptionContext context)
//    {
//        _context = context;
//    }

//    [HttpPost("register")]
//    public async Task<ActionResult<User>> Register(User user)
//    {
//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();
//        return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
//    }

//    [HttpPost("login")]
//    public ActionResult<User> Login(User user)
//    {
//        var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
//        if (existingUser == null)
//        {
//            return Unauthorized();
//        }
//        return Ok(existingUser);
//    }
//}