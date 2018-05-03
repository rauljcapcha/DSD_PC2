using System.Runtime.Serialization;

namespace MillasSalud.Dominio
{
    [DataContract]
    public class Compra
    {
        [DataMember]
        public int IdCompra { get; set; }
        [DataMember]
        public string ClienteDNI { get; set; }
        [DataMember]
        public decimal ImporteCompra { get; set; }
    }
}