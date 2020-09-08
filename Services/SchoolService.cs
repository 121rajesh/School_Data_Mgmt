using SchoolDataMgtm.Models;
using SchoolDataMgtm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDataMgtm.Services
{
    public class SchoolService:IGenericCRUD<School>
    {
        Response response = new Response();
        School_Data_MgtmEntities dalObj = new School_Data_MgtmEntities();

        public SchoolService()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }

        public Response GetAll()
        {
            try
            {
                response.Data = dalObj.Schools.ToList();
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
                response.Data = dalObj.Schools.Find(id);
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

        public Response Add(School entity)
        {
            try
            {
                
                dalObj.Schools.Add(entity);
                dalObj.SaveChanges();
                response.Status = "School added successfully!";
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

        public Response Update(int id, School entity)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}