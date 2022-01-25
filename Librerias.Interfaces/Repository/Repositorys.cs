using Librerias.Entities.Interfaces;
using Librerias.Interfaces.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Interfaces.Repository
{
    public class Repositorys : IRepositorys
    {
        readonly LibreriaDbContext dbContext;
        public Repositorys(LibreriaDbContext context) => dbContext = context;

        public Task<int> SaveChanges()
        {
            try
            {
                return dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
