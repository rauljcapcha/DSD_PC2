using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MillasSalud.Dominio
{
    [DataContract]
    public class MillajeSalud
    {
        [DataMember]
        public string ClienteDNI { get; set; }
        [DataMember]
        public decimal ImporteSolesAcumulados { get; set; }
        [DataMember]
        public decimal ImporteSolesValeDescuento { get; set; }
    }
}