using Servicios.Dominio;
using Servicios.Errores;
using Servicios.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    public class Paises : IPaises
    {
        private PaisDAO paisDAO = new PaisDAO();

        public Pais CrearPais(Pais paisACrear)
        {
            if (paisDAO.Obtener(paisACrear.cod_pais) != null)
            {
                throw new FaultException<PaisRepetido>
                    (
                      new PaisRepetido()
                      {
                          Codigo = "101",
                          Descripcion = "El codigo de Pais ya existe"
                      },
                      new FaultReason("Error al intentar crear Pais")
                    );

            }
            return paisDAO.Crear(paisACrear);
        }

        public Pais ObtenerPais(string codpai)
        {
            return paisDAO.Obtener(codpai);
        }

        public Pais ModificarPais(Pais paisAModificar)
        {
            return paisDAO.Modificar(paisAModificar);
        }

        public void EliminarPais(string codpai)
        {
            paisDAO.Eliminar(codpai);
        }

        public List<Pais> ListarPaises()
        {
            return paisDAO.Listar();
        }
    }


}
