using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class ConductorController : ApiController
    {
        // GET: api/Conductor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Conductor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Conductor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Conductor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Conductor/5
        public void Delete(int id)
        {
        }
    }
}
