using SchoolDataMgtm.Interfaces;
using SchoolDataMgtm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDataMgtm.Services
{
    public class UserService: IGenericCRUD<User>
    {
        Response response = new Response();
        School_Data_MgtmEntities dalObj = new School_Data_MgtmEntities();

        public UserService()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }

        public Response GetAll()
        {

            try
            {
                List<User> users = dalObj.Users.ToList();
                if (users != null)
                {
                    response.Data = users;
                    response.Status = "Success";
                    response.Error = null;
                    return response;
                }
                else
                {
                    response.Data = null;
                    response.Status = "Failed";
                    response.Error = null;
                    return response;
                }
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
                User user = dalObj.Users.Find(id);
                if (user != null)
                {

                    response.Data = user;
                    response.Status = "Success";
                    response.Error = null;
                    //logger.Log("Displayed User data");
                    return response;
                }
                else
                {
                    response.Data = null;
                    response.Status = "Invalid user id!!";
                    response.Error = null;
                    //logger.Log("Displayed User data");
                    return response;
                }
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                //logger.Log("Exception occured returned Error msg");
                return response;
            }
        }

        

        public Response Add(User entity)
        {
            try
            {
                if (entity != null)
                {
                    dalObj.Users.Add(entity);
                    dalObj.SaveChanges();
                    response.Data = entity;
                    response.Status = "Registered successfully!";
                    response.Error = null;
                    //logger.Log("Displayed User entity");
                    return response;
                }
                else
                {
                    response.Data = null;
                    response.Status = "Fields are empty";
                    response.Error = null;
                    //logger.Log("Displayed User entity");
                    return response;
                }

            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                //logger.Log("Exception occured returned Error msg");
                return response;
            }
        }

        public Response Update(int id, User entity)
        {
            try
            {
                User u = dalObj.Users.Find(id);
                u.Name = entity.Name;
                u.EmailId = entity.EmailId;
                u.ContactNo = entity.ContactNo;
                u.BirthDate = entity.BirthDate;
                u.DisplayPicture = entity.DisplayPicture;
                u.SchoolId = entity.SchoolId;
                u.RoleId = entity.RoleId;
                u.Qualifications = entity.Qualifications;
                u.Class = entity.Class;
                if (entity.IsActive == false)
                {
                    u.IsActive = entity.IsActive;
                }
                else
                {
                    u.IsActive = entity.IsActive;
                }

                dalObj.SaveChanges();
                response.Status = "entity data updated";
                response.Error = null;
                return response;
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                //logger.Log("Exception occured returned Error msg");
                return response;
            }
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response Login(User user)
        {
            try
            {
                List<User> users = dalObj.Users.ToList();
                if (user.EmailId != null && user.Password != null)
                {
                    var validate = (from u in users
                                    where u.EmailId == user.EmailId && u.Password == user.Password
                                    select u).SingleOrDefault();
                    if (validate != null)
                    {
                        response.Data = validate;
                        response.Error = null;
                        response.Status = "Success";
                        return response;
                    }
                    else
                    {
                        response.Data = null;
                        response.Error = null;
                        response.Status = "Incorrect email or password";
                        return response;
                    }
                }
                else
                {
                    response.Data = null;
                    response.Error = null;
                    response.Status = "Fields are empty";
                    return response;
                }
            }
            catch (Exception cause)
            {
                response.Data = cause.Message;
                response.Status = "Failed";
                response.Error = cause;
                //logger.Log("Exception occured returned Error msg");
                return response;
            }
        }

    }
}