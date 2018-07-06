using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Parm;
using System.Data.Entity;

namespace Api.Service
{
    public interface IUserService<T>:IBase<sys_user> where T : BaseParm
    {
        IEnumerable<sys_user> Get_List(T parm, out int record_count);
    }
}
