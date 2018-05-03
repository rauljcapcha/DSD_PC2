using System;
using System.Data;
using System.Data.SqlClient;

namespace MillasSalud.Persistencia
{
    public class DataAccess
    {
        #region "Cadena Conexión
        private string ConnectionString = "Data Source=(local);Initial Catalog=DB_BOTICA;Persist Security Info=True;User ID=sa;Password=sql;Connect Timeout=300";
        #endregion

        #region "Constructor Singleton"
        static DataAccess instance;
        public static DataAccess getInstance()
        {
            if (instance == null) { instance = new DataAccess(); }
            return instance;
        }
        #endregion

        #region "Metodos"
        public int ExecuteStoreProcedureInsertUpdateDelete(string StoreProcedure, params object[] Parameters)
        {
            int StoreProcedureIUD = 0;
            using (SqlConnection objSqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand objSqlCommand = new SqlCommand())
                {
                    try
                    {
                        objSqlCommand.Connection = objSqlConnection;
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.CommandText = StoreProcedure;
                        //Establesco el tiempo de espera en 5 minutos
                        objSqlCommand.CommandTimeout = objSqlConnection.ConnectionTimeout;
                        objSqlConnection.Open();
                        SqlCommandBuilder.DeriveParameters(objSqlCommand);
                        int i = 0;
                        for (i = 0; i <= Parameters.Length - 1; i++)
                        {
                            ((SqlParameter)objSqlCommand.Parameters[i + 1]).Value = Parameters[i];
                        }
                        StoreProcedureIUD = Convert.ToInt32(objSqlCommand.ExecuteNonQuery());
                        objSqlConnection.Close();
                        IDataParameter ObjIDataParameter = null;
                        foreach (IDataParameter ObjDataParameter in objSqlCommand.Parameters)
                        {
                            ObjIDataParameter = ObjDataParameter;
                            if (ObjIDataParameter.Direction == ParameterDirection.InputOutput | ObjIDataParameter.Direction == ParameterDirection.Output)
                            {
                                return Convert.ToInt32(ObjIDataParameter.Value);
                            }
                        }
                        return StoreProcedureIUD;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objSqlConnection.Close();
                    }
                }
            }
        }
        public DataTable ExecuteStoreProcedureSelect(string StoreProcedure, params object[] Parameters)
        {
            using (SqlConnection objSqlConnection = new SqlConnection(this.ConnectionString))
            {
                using (DataTable objDataTabla = new DataTable())
                {
                    using (SqlCommand objSqlCommand = new SqlCommand())
                    {
                        using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter())
                        {
                            try
                            {
                                objSqlCommand.Connection = objSqlConnection;
                                objSqlCommand.CommandType = CommandType.StoredProcedure;
                                objSqlCommand.CommandText = StoreProcedure;
                                objSqlCommand.CommandTimeout = objSqlConnection.ConnectionTimeout;
                                objSqlConnection.Open();
                                SqlCommandBuilder.DeriveParameters(objSqlCommand);
                                int i = 1;
                                foreach (object Param in Parameters)
                                {
                                    objSqlCommand.Parameters[i].Value = Param;
                                    i += 1;
                                }
                                objSqlDataAdapter.SelectCommand = objSqlCommand;
                                objSqlDataAdapter.Fill(objDataTabla);
                                objSqlConnection.Close();
                                return objDataTabla;
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                objSqlConnection.Close();
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
