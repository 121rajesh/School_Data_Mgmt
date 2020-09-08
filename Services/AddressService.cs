using SchoolDataMgtm.Interfaces;
using SchoolDataMgtm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDataMgtm.Services
{
    public class AddressService : IGenericCRUD<Address>
    {
        Response response = new Response();
        School_Data_MgtmEntities dalObj = new School_Data_MgtmEntities();

        public Response Add(Address entity)
        {
            try
            {
                dalObj.Addresses.Add(entity);
                dalObj.SaveChanges();
                response.Data = entity;
                response.Status = "Address added!";
                response.Error = null;
                return response;
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                return response;
            }
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            try
            {
                List<Address> addr = dalObj.Addresses.ToList();
                response.Data = addr;
                response.Status = "Success";
                response.Error = null;
                return response;
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                return response;
            }
        }

        public Response GetById(int id)
        {
            try
            {

                response.Data = dalObj.Addresses.Find(id);
                response.Status = "Success";
                response.Error = null;
                return response;
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                return response;
            }
        }

        public Response Update(int id, Address data)
        {
            try
            {
                Address addr = dalObj.Addresses.Find(id);
                addr.Street = data.Street;
                addr.City = data.City;
                addr.State = data.State;
                addr.Country = data.Country;

                dalObj.SaveChanges();
                response.Status = "Address updated successfully!";
                return response;
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                return response;
            }
        }
    }
}