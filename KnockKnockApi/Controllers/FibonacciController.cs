using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
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
		// GET: api/fibonacci
		[HttpGet]
		public JsonResult Get(long n)
		{
			return Json(Fibonacci.Calculate(n));
		}
	}
}
