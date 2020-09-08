using SchoolDataMgtm.Models;
using SchoolDataMgtm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolDataMgtm.Controllers
{
    public class RoleController : ApiController
    {
        RoleService rs = new RoleService();
        
        // GET: api/Role
        public Response Get()
        {
            return rs.GetAll();
        }

        // GET: api/Role/5
        public Response Get(int id)
        {
            return rs.GetById(id);
        }

        // POST: api/Role
        public Response AddRole([FromBody]Role data)
        {
            return rs.Add(data);
        }

        // PUT: api/Role/5
        public Response UpdateRole(int id, [FromBody]Role data)
        {
            return rs.Update(id, data);
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}
