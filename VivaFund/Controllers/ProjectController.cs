using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VivaFund.Controllers
{
    public class ProjectController : ApiController
    {
        // GET: api/Project
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Project/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Project
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }
    }
}
