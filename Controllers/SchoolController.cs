using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDataMgtm.Models;
using SchoolDataMgtm.Services;

namespace SchoolDataMgtm.Controllers
{
    public class SchoolController : ApiController
    {
        SchoolService ss = new SchoolService();

        // GET: api/School
        public Response Get()
        {
            return ss.GetAll();
        }

        // GET: api/School/5
        public Response Get(int id)
        {
            return ss.GetById(id);   
        }

        // POST: api/School
        public Response AddSchool([FromBody]School data)
        {
            return ss.Add(data);
        }

        // PUT: api/School/5
        public void Put(int id, [FromBody]School value)
        {

        }

        // DELETE: api/School/5
        public void Delete(int id)
        {
        }
    }
}
