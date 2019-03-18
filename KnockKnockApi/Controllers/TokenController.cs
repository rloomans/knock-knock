using System;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : Controller
	{
		public static Guid TOKEN = new Guid("6a0cc61b-6f3a-45da-ba53-15acd962c1d5");

		// GET: api/token
		[HttpGet]
		public JsonResult Get()
		{
			return Json(TOKEN);
		}
	}
}
