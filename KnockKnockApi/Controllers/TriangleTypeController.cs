using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TriangleTypeController : Controller
	{
		// GET: api/triangletype
		[HttpGet]
		public JsonResult Get(int a, int b, int c)
		{
            var triangle = new Triangle(a, b, c);

			return Json(triangle.Characterise());
		}
	}
}
