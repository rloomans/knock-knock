using System;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	/// <summary>
	/// Your token.
	/// </summary>
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : Controller
	{
		/// <summary>
		/// Token from Readify.
		/// </summary>
		/// <returns></returns>
		public static Guid TOKEN = new Guid("6a0cc61b-6f3a-45da-ba53-15acd962c1d5");

		/// <summary>
		/// Your token.
		/// </summary>
		/// <response code="200">uuid</response>
		[HttpGet]
		public JsonResult Get()
		{
			return Json(TOKEN);
		}
	}
}
