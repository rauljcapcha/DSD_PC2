using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.IO;
using IronSharp.IronMQ;
using IronSharp.Core;

namespace UnitTestProjectMillasSalud
{
    [TestClass]
    public class UnitTestMillasSalud
    {
        [TestMethod]
        public void TestMethodRegistrarCompraBienCliente1()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Compra CompraRegistrar = new Compra()
            {
                IdCompra = 0,
                ClienteDNI = "09999999",
                ImporteCompra = 100
            };
            string postdata = js.Serialize(CompraRegistrar);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:2607/ServiceCompra.svc/Compras");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            string respuesta = js.Deserialize<string>(tramaJson);
            Assert.AreEqual("Bien!", respuesta);
        }

        [TestMethod]
        public void TestMethodRegistrarCompraBienCliente2()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Compra CompraRegistrar = new Compra()
            {
                IdCompra = 0,
                ClienteDNI = "10000001",
                ImporteCompra = 30
            };
            string postdata = js.Serialize(CompraRegistrar);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:2607/ServiceCompra.svc/Compras");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            string respuesta = js.Deserialize<string>(tramaJson);
            Assert.AreEqual("Bien!", respuesta);
        }

        [TestMethod]
        public void TestMethodRegistrarCompraOops()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Compra CompraRegistrar = new Compra()
            {
                IdCompra = 0,
                ClienteDNI = null,
                ImporteCompra = 3
            };
            string postdata = js.Serialize(CompraRegistrar);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:2607/ServiceCompra.svc/Compras");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                Compra CompraRegistrada = js.Deserialize<Compra>(tramaJson);
                Assert.AreEqual(null, CompraRegistrada.ClienteDNI);
            }
            catch (WebException e)
            {
                HttpStatusCode codigo = ((HttpWebResponse)e.Response).StatusCode;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                AdministradorExcepciones error = js.Deserialize<AdministradorExcepciones>(tramaJson);
                Assert.AreEqual(HttpStatusCode.Conflict, codigo);
                Assert.AreEqual("Oops!", error.Descripcion);
            }
        }

        [TestMethod]
        public void TestMethodContarColas()
        {
            var iromMq = Client.New(new IronClientConfig { ProjectId = "5ae526754f1745000ce9c765", Token = "kI4nEtFhvuEtXOJ9ZqZE", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http" });
            var queues = iromMq.Queues();
            //
            QueueClient comprasCliente1 = iromMq.Queue("09999999");
            Assert.AreEqual(2, comprasCliente1.Info().Size);//contando las colas del cliente 1
            ////
            QueueClient comprasCliente2 = iromMq.Queue("10000001");
            Assert.AreEqual(3, comprasCliente2.Info().Size);//contando las colas del cliente 2
        }

        [TestMethod]
        public void TestMethodMostrarMillas()
        {
            HttpWebRequest requestCliente1 = (HttpWebRequest)WebRequest.Create("http://localhost:2607/ServiceCliente.svc/Clientes/09999999");
            requestCliente1.Method = "GET";
            HttpWebResponse responseCliente1 = (HttpWebResponse)requestCliente1.GetResponse();
            StreamReader readerCliente1 = new StreamReader(responseCliente1.GetResponseStream());
            MillajeSalud Cliente1 = new JavaScriptSerializer().Deserialize<MillajeSalud>(readerCliente1.ReadToEnd());
            Assert.AreEqual("09999999", Cliente1.ClienteDNI);
            Assert.AreEqual((decimal)200, Cliente1.ImporteSolesAcumulados);//se pusieron en cola dos montos de 100
            Assert.AreEqual((Cliente1.ImporteSolesAcumulados * (decimal)(0.15)), Cliente1.ImporteSolesValeDescuento);//15% de lo acumulado para DNIs anteriores a 09999999 [adultos mayores].
            //
            HttpWebRequest requestCliente2 = (HttpWebRequest)WebRequest.Create("http://localhost:2607/ServiceCliente.svc/Clientes/10000001");
            requestCliente2.Method = "GET";
            HttpWebResponse responseCliente2 = (HttpWebResponse)requestCliente2.GetResponse();
            StreamReader readerCliente2 = new StreamReader(responseCliente2.GetResponseStream());
            MillajeSalud Cliente2 = new JavaScriptSerializer().Deserialize<MillajeSalud>(readerCliente2.ReadToEnd());
            Assert.AreEqual("10000001", Cliente2.ClienteDNI);
            Assert.AreEqual((decimal)90, Cliente2.ImporteSolesAcumulados);//se pusieron en cola 3 montos de 30
            Assert.AreEqual((Cliente2.ImporteSolesAcumulados * (decimal)(0.10)), Cliente2.ImporteSolesValeDescuento);//10% si el DNI es 10000000 o posterior.
        }
    }
}
