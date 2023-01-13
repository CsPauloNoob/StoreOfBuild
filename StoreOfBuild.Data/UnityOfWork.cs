using StoreOfBuild.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Save()
        {
            //Salva as alterações no banco
            await _context.SaveChangesAsync();
        }

    }
}
