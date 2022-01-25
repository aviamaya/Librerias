using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Librerias.Models.Queries
{
    public class Autores : BaseQuery
    {
        public Autores() : base() { }

        public List<Autor> GetAll()
        {
            var autores = new List<Autor>();
            using (var db = GetConnection())
            {
                autores = db.Query<Autor>(@"SELECT * FROM [Autor]").ToList();
            }
            return autores;
        }
    }
}
