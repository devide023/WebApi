using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Parm;
using System.Data.Entity.Infrastructure;
namespace Api.Service
{
    public interface IBase<T>
    {
        T Add(T entry);
        T Find(int id);
        T Update(T entry);
        T Remove(int id);
        int Remove(List<int> ids);
        IEnumerable<T> Get_List();
        IEnumerable<T> Get_List<P, TKey>(P parm, Expression<Func<T, TKey>> orderByLambda) where P:BaseParm;
        IEnumerable<T> Get_List<P, TKey>(P parm, Expression<Func<T, TKey>> orderByLambda,out int record_count) where P:BaseParm;
    }
}
