using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServices<T>
    {
        void Add(T t);
        void Delete(T t);
        bool Delete(int id);
        List<T> Read();

    }
}