using Broadway._6PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(object id);
        ResponseViewModel Create(T model);
        ResponseViewModel Edit(T model);
        ResponseViewModel Delete(T model);
    }
}