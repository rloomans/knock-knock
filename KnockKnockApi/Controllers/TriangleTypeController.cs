using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace KnockKnockApi.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TriangleTypeController : Controller
	{
		/// <summary>
		/// Returns the type of triangle given the lengths of its sides.
		/// </summary>
	 	/// <param name="a">The length of side a</param>
	 	/// <param name="b">The length of side b</param>
	 	/// <param name="c">The length of side c</param>
		/// <returns></returns>/  
		[HttpGet]
		public IActionResult Get(int a, int b, int c)
		{
			try {
	            var triangle = new Triangle(a, b, c);

				return Ok(triangle.Characterise().ToString());
			}
			catch (System.ArgumentException e)
            {
                return BadRequest(new { Error = e.Message });
            }
		}
	}
}
