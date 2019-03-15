using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ReverseWordsController : ControllerBase
	{
		// GET: api/reversewords
		[HttpGet]
		public string Get(string sentence)
		{
			return sentence;
		}
	}
}
