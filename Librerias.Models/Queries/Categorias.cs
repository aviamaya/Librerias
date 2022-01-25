using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Librerias.Models.Queries
{
    public class Categorias : BaseQuery
    {
        public Categorias() : base() { }

        public List<Categoria> GetAll()
        {
            var categorias = new List<Categoria>();
            using (var db = GetConnection())
            {
                categorias = db.Query<Categoria>(@"SELECT * FROM [Categorias]").ToList();
            }
            return categorias;
        }

        public BaseResult Create(Categoria categoria)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                categoria.FechaCreacion = DateTime.Now;
                rowsAffected = db.Execute(@"INSERT INTO [Categorias] (Detalle,Activo,FechaCreacion)
                                                        VALUES (@Detalle,@Activo,@FechaCreacion)", categoria);
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }

        public Categoria GetById(int Id)
        {
            using (var db = GetConnection())
            {
                return db.QueryFirstOrDefault<Categoria>(@"SELECT * FROM [Categorias] WHERE IdCategoria = @Id", new { Id });
            }
        }

        public BaseResult Update(Categoria categoria)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                categoria.FechaModificacion = DateTime.Now;
                rowsAffected = db.Execute(@"UPDATE [Categorias]
                                                SET Detalle = @Detalle,
                                                    Activo = @Activo,
                                                    FechaModificacion = @FechaModificacion 
                                                    WHERE IdCategoria = @IdCategoria", categoria);
            }
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Ha ocurrido un error al momento de guardar los datos"
            };
        }
    }
}
