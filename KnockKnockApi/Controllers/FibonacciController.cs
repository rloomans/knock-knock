using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class FibonacciController : Controller
	{
		/// <summary>
		/// Returns the nth number in the fibonacci sequence.
		/// </summary>
		// GET: api/fibonacci
		[HttpGet]
		public JsonResult Get(long n)
		{
			return Json(Fibonacci.Calculate(n));
		}
	}
}
