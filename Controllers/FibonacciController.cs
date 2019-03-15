using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class FibonacciController : ControllerBase
	{
		// GET: api/fibonacci
		[HttpGet]
		public int64 Get(long n)
		{
			return 1;
		}
	}
}
