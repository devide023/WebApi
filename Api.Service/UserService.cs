using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Dao;
using Api.Model.Parm;
using Webdiyer.WebControls.Mvc;

namespace Api.Service
{
    public class UserService: BaseService<sys_user>
    {
        public UserService()
        {

        }

        public override IEnumerable<sys_user> Get_List<P>(P parm)
        {
            return base.Get_List<P>(parm);
        }
    }
}
