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

        public List<site_menu> Get_UserMenu(int user_id)
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.site_user_roles.Where(t => t.user_id == user_id).Join(db.site_role_menus, ta => ta.role_id, tb => tb.role_id, (ta, tb) => new { ta, tb }).Select(t => t.tb)
                        .Join(db.site_menus.Where(t=>t.status == 1), t1 => t1.menu_id, t2 => t2.id, (t1, t2) => new { t1, t2 }).Select(t => t.t2);
                    return list.Distinct().ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<sys_user> Get_User_List(UserQueryParm parm, out int Result_Count)
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.sys_users as IQueryable<sys_user>;
                    if (!string.IsNullOrEmpty(parm.key))
                    {
                        list = list.Where(t => t.Name.Contains(parm.key.Trim()));
                    }
                    if (!string.IsNullOrEmpty(parm.tel))
                    {
                        list = list.Where(t => t.Mobile.Contains(parm.tel.Trim()) || t.Tel.Contains(parm.tel.Trim()));
                    }
                    PagedList<sys_user> retlist = list.OrderByDescending(t => t.Id).ToPagedList(parm.pageindex, parm.pagesize);
                    Result_Count = retlist.TotalItemCount;
                    return retlist.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
