using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPITemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptionsSnapshot<A01TemplateApiOptions> a01TemplateApiOptions;

        public ValuesController(IOptionsSnapshot<A01TemplateApiOptions> a01TemplateApiOptions)
        {
            this.a01TemplateApiOptions = a01TemplateApiOptions;
        }

        // GET api/values/{key}
        /// <summary>
        /// Retrieve the value of a key.
        /// </summary>
        /// <param name="key">The key to look up the value of.</param>
        /// <returns>The value of the specified key.</returns>
        /// <response code="200">The value was successfully retrieved.</response>
        /// <response code="400">The request parameters were invalid, the key doesn't exist, or a timeout occurred.</response>
        [HttpGet("{key}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<string>> Get(string key)
        {
            string result = null;

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "firstname", "Josh" },
                { "lastname", "Farquhar" },
                { "email", "josh@farquhar.me" },
            };

            try
            {
                result = dictionary[key];
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }
    }
}
