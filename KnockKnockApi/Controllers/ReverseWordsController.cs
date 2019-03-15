using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ReverseWordsController : Controller
	{
		// GET: api/reversewords
		[HttpGet]
		public JsonResult Get(string sentence)
		{
			return Json(sentence);
		}
	}
}
