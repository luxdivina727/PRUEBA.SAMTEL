﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PRUEBA.SAMTEL.Models;

namespace PRUEBA.SAMTEL.Data
{
    public class MateriaData
    {
        public static List<Materia> Listar()
        {
            List<Materia> listadoMaterias = new List<Materia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("ListarMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listadoMaterias.Add(new Materia()
                            {
                                MateriaId = Convert.ToInt64(dr["MateriaId"]),
                                MateriaNombre = Convert.ToString(dr["MateriaNombre"]),
                                MateriaNumeroHoras = Convert.ToInt32(dr["MateriaNumeroHoras"]),
                            });
                        }

                    }



                    return listadoMaterias;
                }
                catch (Exception ex)
                {
                    return listadoMaterias;
                }
            }
        }
        public static bool Registrar(Materia alumno)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion()))
            {
                SqlCommand cmd = new SqlCommand("InsertarMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@materiaNombre", alumno.MateriaNombre);
                cmd.Parameters.AddWithValue("@materiaNumeroHoras", alumno.MateriaNombre);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}