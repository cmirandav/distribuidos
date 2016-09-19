using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicios.Dominio
{
    [DataContract]
    public class Pais
    {
        [DataMember]
        public string cod_pais { get; set; }
        [DataMember]
        public string nom_pais { get; set; }
    }

}