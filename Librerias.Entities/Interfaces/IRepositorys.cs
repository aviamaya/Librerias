using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Entities.Interfaces
{
    public interface IRepositorys
    {
        Task<int> SaveChanges();
    }
}
