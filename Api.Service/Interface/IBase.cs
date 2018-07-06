using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;

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
    }
}
