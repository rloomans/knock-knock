using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ReverseWordsController : Controller
	{
		// GET: api/reversewords
		[HttpGet]
		public JsonResult Get(string query)
		{
			var words = new Words(query);

			return Json(words.ReverseWords().ToString());
		}
	}
}
