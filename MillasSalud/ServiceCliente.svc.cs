using IronSharp.Core;
using IronSharp.IronMQ;
using MillasSalud.Dominio;
using MillasSalud.Error;
using MillasSalud.Persistencia;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace MillasSalud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCliente.svc or ServiceCliente.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCliente : IServiceCliente
    {
        public MillajeSalud ConsultarMillasSalud(string ClienteDNI)
        {
            var iromMq = Client.New(new IronClientConfig { ProjectId = "5ae526754f1745000ce9c765", Token = "kI4nEtFhvuEtXOJ9ZqZE", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http" });
            var queues = iromMq.Queues();
            QueueClient compras = iromMq.Queue(ClienteDNI);
            while (compras.Info().Size > 0)
            {
                QueueMessage message;
                message = compras.Next();
                var body = message.Body;
                JavaScriptSerializer js = new JavaScriptSerializer();
                Compra objCompra = js.Deserialize<Compra>(message.Body);
                new MillajeSaludDAO(new MillajeSalud() { ClienteDNI = objCompra.ClienteDNI, ImporteSolesAcumulados = objCompra.ImporteCompra }).InsertarUpdate();
                message.Delete();
            }
            //
            MillajeSalud objMillajeSalud = new MillajeSaludDAO(new MillajeSalud() { ClienteDNI = ClienteDNI }).Seleccionar();
            //
            if (!string.IsNullOrEmpty(objMillajeSalud.ClienteDNI))
            {
                if (int.Parse(objMillajeSalud.ClienteDNI) < 10000000)
                {
                    objMillajeSalud.ImporteSolesValeDescuento = (objMillajeSalud.ImporteSolesAcumulados * (decimal)(0.15));
                }
                else
                {
                    objMillajeSalud.ImporteSolesValeDescuento = (objMillajeSalud.ImporteSolesAcumulados * (decimal)(0.10));
                }
            }
            return objMillajeSalud;
        }
    }
}
