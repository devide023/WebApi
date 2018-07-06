using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Dao;
using Api.Model.Parm;

namespace Api.Service
{
    public class UserService: BaseService<sys_user>, IUserService<UserQueryParm>
    {
        public UserService()
        {

        }

        public IEnumerable<sys_user> Get_List(UserQueryParm parm, out int record_count)
        {
            using (Db db = new Db())
            {
                record_count = 0;
                var list = db.sys_users as IEnumerable<sys_user>;


                return list;
            }
        }
    }
}
