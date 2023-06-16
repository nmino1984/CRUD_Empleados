using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.DataLayer
{
    public class EmpleadoDL
    {
        public List<Empleado> List()
        {
            List<Empleado> list= new List<Empleado>();

            using (SqlConnection oConection = new SqlConnection(Conection.Cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Empleados()", oConection);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Empleado
                            {
                                IdEmpleado= Convert.ToInt32(dr["IdEmpleado"].ToString()),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Departamento = new Departamento 
                                {
                                    IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                Sueldo = Convert.ToDouble(dr["Sueldo"].ToString()),
                                FechaContrato = dr["FechaContrato"].ToString(),
                            });

                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public Empleado Get(int id)
        {
            Empleado entidad = new Empleado();

            using (SqlConnection oConection = new SqlConnection(Conection.Cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Empleado(@idEmpleado)", oConection);
                cmd.Parameters.AddWithValue("@idEmpleado", id);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
                            entidad.NombreCompleto = dr["NombreCompleto"].ToString();
                            entidad.Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            entidad.Sueldo = Convert.ToDouble(dr["Sueldo"].ToString());
                            entidad.FechaContrato = dr["FechaContrato"].ToString();
                        }

                        return entidad;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool Create(Empleado entity)
        {
            bool answer = false;

            using (SqlConnection oConection = new SqlConnection(Conection.Cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CreateEmpleado", oConection);
                cmd.Parameters.AddWithValue("@NombreCompleto", entity.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entity.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entity.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entity.FechaContrato);

                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    if (rowsAffected > 0) 
                    { 
                        answer = true; 
                    }

                    return answer;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool Edit(Empleado entity)
        {
            bool answer = false;

            using (SqlConnection oConection = new SqlConnection(Conection.Cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EditEmpleado", oConection);
                cmd.Parameters.AddWithValue("@@IdEmpleado", entity.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreCompleto", entity.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entity.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entity.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entity.FechaContrato);

                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        answer = true;
                    }

                    return answer;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool Delete(int id)
        {
            bool answer = false;

            using (SqlConnection oConection = new SqlConnection(Conection.Cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmpleado", oConection);
                cmd.Parameters.AddWithValue("@@IdEmpleado", id);

                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        answer = true;
                    }

                    return answer;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
