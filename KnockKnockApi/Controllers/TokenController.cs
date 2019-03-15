using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
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
