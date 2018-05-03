using IronSharp.Core;
using IronSharp.IronMQ;
using MillasSalud.Dominio;
using MillasSalud.Error;
using MillasSalud.Persistencia;
using System;
using System.Net;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;

namespace MillasSalud
{
    public class ServiceCompra : IServiceCompra
    {
        public string CompraRegistrar(Compra paramCompra)
        {
            if (new CompraDAO(paramCompra).Insertar().IdCompra == 0)
            {
                throw new WebFaultException<AdministradorExcepciones>(new AdministradorExcepciones()
                {
                    Codigo = "001",
                    Descripcion = "Oops!"
                }, HttpStatusCode.Conflict);
            }
            else
            {
                var iromMq = Client.New(new IronClientConfig { ProjectId = "5ae526754f1745000ce9c765", Token = "kI4nEtFhvuEtXOJ9ZqZE", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http" });
                var queues = iromMq.Queues();
                QueueClient compras = iromMq.Queue(paramCompra.ClienteDNI);
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objCompra = js.Serialize(paramCompra);
                compras.Post(objCompra);
                return "Bien!";
            }
        }
    }
}
