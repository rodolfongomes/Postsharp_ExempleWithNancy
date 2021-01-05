using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExempleRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<Model.Person> Get()
        {
            var repository = new Repository.Person();

            var ret = repository.GetAll();

            return ret;
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public Model.Person Get(int id)
        {
            var repository = new Repository.Person();

            var ret = repository.Get(id);

            if (ret == null)
                return new Model.Person();

            return ret;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
