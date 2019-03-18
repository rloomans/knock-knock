using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace KnockKnockApi.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TriangleTypeController : Controller
	{
		// GET: api/triangletype
		[HttpGet]
		public IActionResult Get(int a, int b, int c)
		{
			try {
	            var triangle = new Triangle(a, b, c);

				return Ok(triangle.Characterise());
			}
			catch (System.ArgumentException e)
            {
                return BadRequest(new { Error = e.Message });
            }
		}
	}
}
