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
    public class AdminController : ApiController
    {
        AdminService adminService = new AdminService();

        // GET: api/Admin
        //public Response Get()
        //{
        //    return ;
        //}

        //// GET: api/Admin/5
        //public Response Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Admin
        public Response Post([FromBody]BranchHelperClass bch)
        {
            return adminService.AddBranch(bch);
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/User/Role/{id}")]
        public Response GetByRole(int id)
        {
            return adminService.GetUserByRoleId(id);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/User/School/Role/{schid}/{roleid}")]
        public Response GetBySchoolAndRole(int schid, int roleid)
        {
            return adminService.GetMembersBySchoolAndRole(schid, roleid);
        }
    }
}
