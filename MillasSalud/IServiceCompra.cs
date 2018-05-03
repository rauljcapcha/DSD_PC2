using MillasSalud.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MillasSalud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceCompra" in both code and config file together.
    [ServiceContract]
    public interface IServiceCompra
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Compras", ResponseFormat = WebMessageFormat.Json)]
        string CompraRegistrar(Compra paramCompra);
    }
}
