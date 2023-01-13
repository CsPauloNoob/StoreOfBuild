using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IUnityOfWork
    {
        Task Save();
    }
}
