using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace KnockKnockApi.Controllers
{
	/// <summary>
	/// Returns the nth number in the fibonacci sequence.
	/// </summary>
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class FibonacciController : Controller
	{
		/// <summary>
		/// Returns the nth fibonacci number.
		/// </summary>
		/// <param name="n">The index (n) of the fibonacci sequence</param>
		/// <response code="200">int64</response>
		[HttpGet]
		public IActionResult Get(long n)
		{
			try {
				return Ok(Fibonacci.Calculate(n));
			}
			catch (System.ArgumentException e)
            {
                return BadRequest(new { Error = e.Message });
            }
		}
	}
}
