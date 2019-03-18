using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : Controller
	{
		// GET: api/token
		[HttpGet]
		public JsonResult Get()
		{
			return Json("6a0cc61b-6f3a-45da-ba53-15acd962c1d5");
		}
	}
}
