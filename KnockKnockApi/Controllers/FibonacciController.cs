using System;
using KnockKnockApi.Library;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnockApi.Controllers
{
	/// <inheritdoc />
	/// <summary>
	///     Returns the nth number in the fibonacci sequence.
	/// </summary>
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : Controller
    {
	    /// <summary>
	    ///     Returns the nth fibonacci number.
	    /// </summary>
	    /// <param name="n">The index (n) of the fibonacci sequence</param>
	    /// <response code="200">int64</response>
	    [HttpGet]
        public IActionResult Get(long n)
        {
            try
            {
                return Ok(Fibonacci.Calculate(n));
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {Error = e.Message});
            }
        }
    }
}