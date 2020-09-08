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
    public class AddressController : ApiController
    {
        AddressService addrServ = new AddressService();

        // GET: api/Address
        public Response Get()
        {
            return addrServ.GetAll();
        }

        // GET: api/Address/5
        public Response Get(int id)
        {
            return addrServ.GetById(id);
        }

        // POST: api/Address
        public Response AddAddress([FromBody]Address addr)
        {
            return addrServ.Add(addr);
        }

        // PUT: api/Address/5
        public Response UpdateAddress(int id, [FromBody]Address data)
        {
            return addrServ.Update(id, data);
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
