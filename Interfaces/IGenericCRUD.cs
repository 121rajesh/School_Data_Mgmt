using SchoolDataMgtm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataMgtm.Interfaces
{
    public interface IGenericCRUD<TEntity> where TEntity:class
    {
        Response GetAll();
        Response GetById(int id);
        Response Add(TEntity entity);
        Response Update(int id, TEntity entity);
        Response Delete(int id);
    }
}
