using KnockKnockApi.Library;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	/// <inheritdoc />
	/// <summary>
	///     Reverses the letters of each word in a sentence.
	/// </summary>
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReverseWordsController : Controller
    {
	    /// <summary>
	    ///     Reverses the letters of each word in a sentence.
	    /// </summary>
	    /// <param name="sentence">A sentence</param>
	    /// <response code="200">string</response>
	    [HttpGet]
        public JsonResult Get(string sentence)
        {
            var words = new Words(sentence);

            return Json(words.ReverseWords().ToString());
        }
    }
}