using Servicios.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicios.Persistencia
{
    public class PaisDAO
    {
        //Conexion a la base de datos
        private string cadenaConexion = "Data Source = .\\SQLEXPRESS; Initial Catalog=BD_SEOL2; Integrated Security=SSPI;";

        public Pais Crear(Pais paisACrear)
        {
            Pais paisCreado = null;
            string sql = "INSERT INTO Paises VALUES(@codpai,@nompai)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codpai", paisACrear.cod_pais));
                    comando.Parameters.Add(new SqlParameter("@nompai", paisACrear.nom_pais));
                    comando.ExecuteNonQuery();
                }
            }
            paisCreado = Obtener(paisACrear.cod_pais);
            return paisCreado;
        }

        public Pais Obtener(string codpai)
        {
            Pais paisEncontrado = null;
            string sql = "SELECT * FROM Paises WHERE cod_pais=@codpai";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codpai", codpai));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            paisEncontrado = new Pais()
                            {
                                cod_pais = (string)resultado["cod_pais"],
                                nom_pais = (string)resultado["nom_pais"]
                            };
                        }
                    }
                }
            }
            return paisEncontrado;
        }

        public Pais Modificar(Pais paisAModificar)
        {
            Pais paisModificado = null;
            string sql = "UPDATE Paises SET nom_pais=@nompai WHERE cod_pais=@codpai";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codpai", paisAModificar.cod_pais));
                    comando.Parameters.Add(new SqlParameter("@nompai", paisAModificar.nom_pais));
                    comando.ExecuteNonQuery();
                }
            }
            paisModificado = Obtener(paisAModificar.cod_pais);
            return paisModificado;
        }

        public void Eliminar (string codpai)
        {
            string sql = "DELETE FROM Paises WHERE cod_pais=@codpai";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codpai", codpai));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Pais> Listar()
        {
            List<Pais> paisesEncontrados = new List<Pais>();
            Pais paisEncontrado = null;
            string sql = "SELECT * FROM Paises";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            paisEncontrado = new Pais()
                            {
                                cod_pais = (string)resultado["cod_pais"],
                                nom_pais = (string)resultado["nom_pais"]
                            };
                            paisesEncontrados.Add(paisEncontrado);
                        }
                    }
                }
            }

            return paisesEncontrados;
        }
    }


    }
