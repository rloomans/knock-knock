using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class FibonacciController : Controller
	{
		// GET: api/fibonacci
		[HttpGet]
		public JsonResult Get(long n)
		{
			return Json(Fibonacci.Calculate(n));
		}
	}
}
