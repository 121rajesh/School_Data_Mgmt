
using SchoolDataMgtm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDataMgtm.Services;

namespace SchoolDataMgt.Controllers
{
    public class UserController : ApiController
    {
        UserService uServ = new UserService();
        public UserController()
        {
            //dalObj.Configuration.ProxyCreationEnabled = false;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/User")]
        // GET: api/User
        public Response Get()
        {
            return uServ.GetAll();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/User/{id}")]
        // GET: api/User/5
        public Response Get(int id)
        {
            return uServ.GetById(id);
        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/User/Register")]
        // POST: api/User
        public Response Register([FromBody]User data)
        {
            return uServ.Add(data);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/User/Login")]
        public Response Login([FromBody]User user)
        {
            return uServ.Login(user);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/user/edit")]
        // PUT: api/User/5
        public Response Put(int id, [FromBody]User user)
        {
            return uServ.Update(id, user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }

    
}
