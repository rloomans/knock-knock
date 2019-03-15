using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using KnockKnockApi.Library;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class TriangleTypeController : ControllerBase
	{
		// GET: api/triangletype
		[HttpGet]
		public string Get(int a, int b, int c)
		{
            var triangle = new Triangle(a, b, c);

			return triangle.Characterise();
		}
	}
}
