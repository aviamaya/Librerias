using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Librerias.Models.Queries
{
    public class BaseQuery
    {
        internal string _connectionString;

        //Esto nos ayuda a que las credenciales de la base de datos no sean visibles y no se puedan 
        public BaseQuery()
        {
            _connectionString = Environment.GetEnvironmentVariable("dbAppLibreriaConnection");
        }

        //Aca nos conectamos a la base de datos
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public class BaseResult
        {
            public bool Success { get; set; }

            public string Message { get; set; }

            public int ObjectId { get; set; }
        }
    }
}
