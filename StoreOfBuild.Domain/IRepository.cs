using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IRepository<T>
    {
        T GetById(int id);

        void Save(T entity);

        IEnumerable<T> GetAll();
    }
}