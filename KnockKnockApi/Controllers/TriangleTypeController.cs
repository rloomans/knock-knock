using System;
using KnockKnockApi.Library;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	/// <inheritdoc />
	/// <summary>
	///     Returns the type of triangle given the lengths of its sides.
	/// </summary>
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleTypeController : Controller
    {
	    /// <summary>
	    ///     Returns the type of triangle given the lengths of its sides.
	    /// </summary>
	    /// <param name="a">The length of side a</param>
	    /// <param name="b">The length of side b</param>
	    /// <param name="c">The length of side c</param>
	    /// <response code="200">string</response>
	    [HttpGet]
        public IActionResult Get(int a, int b, int c)
        {
            var triangle = new Triangle {A = a, B = b, C = c};

            return Ok(triangle.Characterise().ToString());
        }
    }
}