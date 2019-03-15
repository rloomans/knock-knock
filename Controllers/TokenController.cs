using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class TokenController : ControllerBase
	{
		// GET: api/token
		[HttpGet]
		public string Get()
		{
			return "6a0cc61b-6f3a-45da-ba53-15acd962c1d5";
		}
	}
}
