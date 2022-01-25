using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Interfaces.DataContext
{
    class LibreriaDbContextFactory :
        IDesignTimeDbContextFactory<LibreriaDbContext>
    {
        public LibreriaDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<LibreriaDbContext>();
            OptionsBuilder.UseSqlServer("Server=(localdb)\\Local;database=dbAppLibreria");
            return new LibreriaDbContext(OptionsBuilder.Options);
        }
    }
}
