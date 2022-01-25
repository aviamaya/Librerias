using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Librerias.Models.Queries
{
    public class LibrosRelaciones : BaseQuery
    {
        public LibrosRelaciones() : base() { }

        public List<v_Lista_LibrosRelacion> GetAll()
        {
            var librosRelaciones = new List<v_Lista_LibrosRelacion>();
            using (var db = GetConnection())
            {
                librosRelaciones = db.Query<v_Lista_LibrosRelacion>(@"SELECT * FROM [v_Lista_LibrosRelacion]").ToList();
            }
            return librosRelaciones;
        }
        public v_Lista_LibrosRelacion GetById(int Id)
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<v_Lista_LibrosRelacion>(@"SELECT * FROM [v_Lista_LibrosRelacion] WHERE IdRelacion = @Id", new { Id });
            }
        }
        public BaseResult Create(LibroRelacion librosRelaciones)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                librosRelaciones.FechaCreacion = DateTime.Now;
                rowsAffected = db.Execute(@"INSERT INTO [LibrosRelaciones] (IdLibro,IdCategoria,IdAutor,FechaCreacion)
                                                        VALUES (@IdLibro,@IdCategoria,@IdAutor,@FechaCreacion)", librosRelaciones);
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }

        public BaseResult Delete(int Id)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                rowsAffected = db.Execute(@"DELETE FROM [LibrosRelaciones] WHERE IdRelacion = @Id", new { Id });
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }
    }
}
