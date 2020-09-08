using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolDataMgtm.Models;
using SchoolDataMgtm.Interfaces;
using SchoolDataMgtm.Services;

namespace SchoolDataMgtm.Services
{

    public class AdminService : IGenericCRUD<User>
    {
        Response response = new Response();
        School_Data_MgtmEntities dalObj = new School_Data_MgtmEntities();
        UserService us = new UserService();
        public AdminService()
        {
            dalObj.Configuration.ProxyCreationEnabled = false;
        }

        public Response Add(User entity)
        {
            return response;
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            return us.GetAll();
        }

        public Response GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        
        public Response GetUserByRoleId(int id)
        {
            try
            {
                List<User> users = dalObj.Users.ToList();
                List<School> school = dalObj.Schools.ToList();
                var uList = (from u in users
                             //join sch in school on u.SchoolId equals sch.SchoolId
                             where u.RoleId == id
                             select new
                             {
                                 u.UserId,
                                 u.Name,
                                 u.Gender,
                                 u.EmailId,
                                 u.ContactNo,
                                 u.BirthDate,
                                 u.Qualifications,
                                 u.Class,
                                 u.IsActive,
                                 //sch.SchoolName
                             }).ToList();

                if (uList != null)
                {
                    response.Data = uList;
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
                //logger.Log("Exception occured returned Error msg");
                return response;

            }
        }

        public Response GetMembersBySchoolAndRole(int schId,int roleId)
        {
            try
            {
                List<User> users = dalObj.Users.ToList();
                List<School> school = dalObj.Schools.ToList();
                List<Role> role = dalObj.Roles.ToList();
                var uList = (from u in users
                             join sch in school on u.SchoolId equals schId
                             join rol in role on u.RoleId equals roleId
                            // where u.RoleId == roleId
                             select new
                             {
                                 u.UserId,
                                 u.Name,
                                 u.Gender,
                                 u.EmailId,
                                 u.ContactNo,
                                 u.BirthDate,
                                 u.Qualifications,
                                 u.Class,
                                 u.IsActive,
                                 rol.RoleName,
                                 sch.SchoolName
                             }).ToList();

                if (uList != null)
                {
                    response.Data = uList;
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
                //logger.Log("Exception occured returned Error msg");
                return response;

            }
        }
            
        public Response AddBranch(BranchHelperClass entity)
        {
            try
            {
                School sch = new School();
                Address addr = new Address();

                addr.Street = entity.Street;
                addr.City = entity.City;
                addr.State = entity.State;
                addr.Country = entity.Country;
                addr.PostalCode = entity.PostalCode;

                addr =dalObj.Addresses.Add(addr);
                dalObj.SaveChanges();

                sch.SchoolName = entity.SchoolName;
                sch.Branch = entity.Branch;
                sch.Principal = entity.Principal;
                sch.CreationDate = entity.CreationDate;
                sch.AdId = addr.AdId;
                dalObj.Schools.Add(sch);
                dalObj.SaveChanges();

                response.Data = null;
                response.Status = "Branch added!";
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

    }
}