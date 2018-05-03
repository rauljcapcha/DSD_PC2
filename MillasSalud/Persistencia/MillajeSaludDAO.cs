using MillasSalud.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MillasSalud.Persistencia
{
    public class MillajeSaludDAO
    {
        private MillajeSalud MillajeSalud { get; set; }

        public MillajeSaludDAO(MillajeSalud paramMillajeSalud)
            : base()
        {
            this.MillajeSalud = paramMillajeSalud;
        }

        private DataTable Buscar(string OpcionBusqueda)
        {
            return DataAccess.getInstance().ExecuteStoreProcedureSelect("Usp_Botica_Tb_MillajeSalud_Select", OpcionBusqueda, this.MillajeSalud.ClienteDNI);
        }

        public MillajeSalud Seleccionar()
        {
            DataTable objDataTable = this.Buscar(OpcionBusqueda: "S");
            this.MillajeSalud = new MillajeSalud();
            foreach (DataRow objDataRow in objDataTable.Rows)
            {
                this.MillajeSalud.ClienteDNI = (string)objDataRow["ClienteDNI"].ToString();
                this.MillajeSalud.ImporteSolesAcumulados = (decimal)objDataRow["ImporteSolesAcumulados"];
            }
            objDataTable.Dispose();
            return this.MillajeSalud;
        }

        private int InsertUpdateDelete(string Opcion)
        {
            return DataAccess.getInstance().ExecuteStoreProcedureInsertUpdateDelete("Usp_Botica_Tb_MillajeSalud_InsertUpdate", Opcion,
                this.MillajeSalud.ClienteDNI,
                this.MillajeSalud.ImporteSolesAcumulados);
        }

        public MillajeSalud InsertarUpdate()
        {
            int result = this.InsertUpdateDelete("IU");
            if (result != 0)
            {
                return this.Seleccionar();
            }
            return new MillajeSalud();
        }
    }
}