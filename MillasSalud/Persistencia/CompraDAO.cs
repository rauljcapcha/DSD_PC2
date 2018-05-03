using MillasSalud.Dominio;
using System.Collections.Generic;
using System.Data;

namespace MillasSalud.Persistencia
{
    public class CompraDAO
    {
        private Compra Compra { get; set; }

        public CompraDAO(Compra paramCompra)
            : base()
        {
            this.Compra = paramCompra;
        }

        private DataTable Buscar(string OpcionBusqueda)
        {
            return DataAccess.getInstance().ExecuteStoreProcedureSelect("Usp_Botica_Tb_Compra_Select", OpcionBusqueda, this.Compra.IdCompra, this.Compra.ClienteDNI);
        }

        private int InsertUpdateDelete(string Opcion)
        {
            return DataAccess.getInstance().ExecuteStoreProcedureInsertUpdateDelete("Usp_Botica_Tb_Compra_InsertUpdateDelete", Opcion,
                this.Compra.IdCompra,
                this.Compra.ClienteDNI,
                this.Compra.ImporteCompra);
        }

        public Compra Seleccionar()
        {
            DataTable objDataTable = this.Buscar(OpcionBusqueda: "S");
            this.Compra = new Compra();
            foreach (DataRow objDataRow in objDataTable.Rows)
            {
                this.Compra.IdCompra = (int)objDataRow["IdCompra"];
                this.Compra.ClienteDNI = (string)objDataRow["ClienteDNI"].ToString();
                this.Compra.ImporteCompra = (decimal)objDataRow["ImporteCompra"];
            }
            objDataTable.Dispose();
            return this.Compra;
        }

        public List<Compra> ListaCompras()
        {
            DataTable objDataTable = this.Buscar(OpcionBusqueda: "L");
            List<Compra> objList = new List<Compra>();
            foreach (DataRow objDataRow in objDataTable.Rows)
            {
                Compra objCompras = new Compra();
                {
                    objCompras.IdCompra = (int)objDataRow["IdCompra"];
                    objCompras.ClienteDNI = (string)objDataRow["ClienteDNI"].ToString();
                    objCompras.ImporteCompra = (decimal)objDataRow["ImporteCompra"];
                    objList.Add(objCompras);
                    objCompras = null;
                }
            }
            objDataTable.Dispose();
            return objList;
        }

        public Compra Insertar()
        {
            int result = this.InsertUpdateDelete("I");
            if (result != 0)
            {
                this.Compra.IdCompra = result;

                return this.Seleccionar();
            }
            return new Compra();
        }
    }
}