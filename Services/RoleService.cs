using SchoolDataMgtm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDataMgtm.Interfaces;

namespace SchoolDataMgtm.Services
{
    public class RoleService:IGenericCRUD<Role>
    {
        Response response = new Response();
        School_Data_MgtmEntities dalObj = new School_Data_MgtmEntities();

        public RoleService()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }

        public Response GetAll()
        {
            try
            {
                List<Role> roles = dalObj.Roles.ToList();
                response.Data = roles;
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
                response.Data = dalObj.Roles.Find(id);
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

        public Response Add(Role entity)
        {
            try
            {
                dalObj.Roles.Add(entity);
                dalObj.SaveChanges();
                response.Data = entity;
                response.Status = "Role added!";
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

        public Response Update(int id, Role data)
        {
            try
            {
                Role role = dalObj.Roles.Find(id);
                role.RoleName = data.RoleName;
                dalObj.SaveChanges();
                response.Status = "Role updated successfully!";
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
    }
}