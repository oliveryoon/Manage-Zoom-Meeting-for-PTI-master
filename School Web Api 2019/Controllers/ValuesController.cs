using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Models;

namespace School_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        
        public ActionResult<IEnumerable<Hero>> Get()
        {
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Hero() { id = 1, name = "Dr XXX" });

            return heroes;
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Hero> Get(int id)
        {
            return new Hero() { id = 1, name = "Dr XXX" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
