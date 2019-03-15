using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class FibonacciController : ControllerBase
	{
		// GET: api/fibonacci
		[HttpGet]
		public long Get(long n)
		{
			return Fibonacci.Calculate(n);
		}
	}
}
