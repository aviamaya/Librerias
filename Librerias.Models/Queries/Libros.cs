using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Librerias.Models.Queries
{
    public class Libros : BaseQuery
    {
        public Libros() : base() { }

        public List<Libro> GetAll()
        {
            var libros = new List<Libro>();
            using (var db = GetConnection())
            {
                libros = db.Query<Libro>(@"SELECT * FROM [Libros]").ToList();
            }
            return libros;
        }
        public Libro GetById(int Id)
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<Libro>(@"SELECT * FROM [Libros] WHERE IdLibro = @Id", new { Id });
            }
        }

        public BaseResult CreateLibro(Libro libro)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                libro.FechaCreacion = DateTime.Now;
                rowsAffected = db.Execute(@"INSERT INTO [Libros] (NombreLibro,Descripcion,FechaPublicacion,FechaCreacion)
                                                        VALUES (@NombreLibro,@Descripcion,@FechaPublicacion,@FechaCreacion)", libro);
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }
        public BaseResult UpdateLibro(Libro libro)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                libro.FechaModificacion = DateTime.Now;
                rowsAffected = db.Execute(@"UPDATE [Libros]
                                                SET NombreLibro = @NombreLibro,
                                                    Descripcion = @Descripcion,
                                                    FechaPublicacion = @FechaPublicacion,
                                                    FechaModificacion = @FechaModificacion 
                                                    WHERE IdLibro = @IdLibro", libro);
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }
    }
}
