using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayerREST.Controllers
{
    public class SuperadminController : ApiController
    {
        // GET: api/Superadmin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Superadmin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Superadmin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Superadmin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Superadmin/5
        public void Delete(int id)
        {
        }
    }
}
