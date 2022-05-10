using generadorCodigo.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace generadorCodigo.Repository
{
    

    public class RepositoryValue
    {
        private readonly string _connectionString;
        public RepositoryValue(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Conexion");
        }

        //Obtener todas las tablas de la base de datos que estamos apuntando
        public async Task<List<InformacionTabla>> ObtenerTodasTablas()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd=new SqlCommand("sp_obtener_tablas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<InformacionTabla>();
                    await sql.OpenAsync();
                    using(var reader=await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(
                                MapToValueTabla(reader)
                                );
                        }
                    }
                    return response;
                }
            }
        }
        //obtener los campos de una tabla en especifica
        public async Task<List<CamposInformacionTabla>> ObtenerCamposTabla(string tabla)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtener_camposTabla", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Tabla", tabla));
                    var response = new List<CamposInformacionTabla>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(
                                MapToValueCampoTabla(reader)
                                );
                        }
                    }
                    return response;
                }
            }
        }

        private InformacionTabla MapToValueTabla(SqlDataReader reader)
        {
            return new InformacionTabla
            {
                nombreTabla = reader["nombreTabla"].ToString(),
                Table_Catalog = reader["TABLE_CATALOG"].ToString(),
                Table_name = reader["TABLE_NAME"].ToString(),
                Table_schema=reader["TABLE_SCHEMA"].ToString(),
                Table_Type=reader["TABLE_TYPE"].ToString()
                
            };
        }
        private CamposInformacionTabla MapToValueCampoTabla(SqlDataReader reader)
        {
            CamposInformacionTabla it = new CamposInformacionTabla();
            if (!(reader["DATETIME_PRECISION"] is DBNull))
            {
                it.Datetime_precision = Convert.ToInt32(reader["DATETIME_PRECISION"]);
            }
            if (!(reader["CHARACTER_MAXIMUM_LENGTH"] is DBNull))
            {
                it.Character_maximum_Length = Convert.ToInt32(reader["CHARACTER_MAXIMUM_LENGTH"]);
            }
            if (!(reader["NUMERIC_PRECISION_RADIX"] is DBNull))
            {
                it.Numeric_precision_radix = Convert.ToInt32(reader["NUMERIC_PRECISION_RADIX"]);
            }
            if (!(reader["NUMERIC_PRECISION"] is DBNull))
            {
                it.Numeric_precision = Convert.ToInt32(reader["NUMERIC_PRECISION"]);
            }
            if (!(reader["CHARACTER_OCTET_LENGTH"] is DBNull))
            {
                it.Character_octet_length = Convert.ToInt32(reader["CHARACTER_OCTET_LENGTH"]);
            }
            if (!(reader["NUMERIC_SCALE"] is DBNull))
            {
                it.Numeric_Scale = Convert.ToInt32(reader["NUMERIC_SCALE"]);
            }
            it.Ordinal_position = Convert.ToInt32(reader["ORDINAL_POSITION"]);
            it.Column_Default = reader["COLUMN_DEFAULT"].ToString();
            it.Column_name = reader["COLUMN_NAME"].ToString();
            it.Table_Catalog = reader["TABLE_CATALOG"].ToString();
            it.Table_name = reader["TABLE_NAME"].ToString();
            it.Table_schema = reader["TABLE_SCHEMA"].ToString();
            it.Is_nullable = reader["IS_NULLABLE"].ToString();
            it.Data_type = reader["DATA_TYPE"].ToString();
            return it;
       
        }
    }

    
}
