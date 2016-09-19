using Servicios.Dominio;
using Servicios.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    [ServiceContract]
    public interface IPaises
    {
        [FaultContract(typeof(PaisRepetido))]

        [OperationContract]
        Pais CrearPais(Pais paisACrear);

        [OperationContract]
        Pais ObtenerPais(string codpai);

        [OperationContract]
        Pais ModificarPais(Pais paisAModificar);

        [OperationContract]
        void EliminarPais(string codpai);

        [OperationContract]
        List<Pais> ListarPaises();

    }

}
