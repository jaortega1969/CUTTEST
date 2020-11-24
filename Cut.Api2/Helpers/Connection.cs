using Cut.Api2.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Cut.Api2.Helpers
{
    public class Connection
    {
        private readonly SqlConnection cnx;

        public Connection()
        {
            string strConnection = WebConfigurationManager.ConnectionStrings["CutConeccion"].ConnectionString;
            cnx = new SqlConnection(strConnection);
        }

        public DataSet GetVoucher(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_JO_API_CONSULTA_BOLETA", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@int_deposito", SqlDbType.Int).Value = id;
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter();
                MyDataAdapter.SelectCommand = cmd;
                MyDataAdapter.Fill(ds, "BOLETA");
                cmd.Dispose();
                cnx.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                cnx.Close();
            }
            return ds;
        }

        public int RunGetVaucherSP(Voucher model)
        {
            int newVaucher = 0;
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SP_JO_API_GENERAR_BOLETA", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@ach_codigo", SqlDbType.Char, 9).Value = model.Codigo;
                cmd.Parameters.Add("@amo_monto", SqlDbType.Decimal).Value = model.Valor;
                cmd.Parameters.Add("@ach_depositante", SqlDbType.Char, 60).Value = model.Depositante;
                cmd.Parameters.Add("@ach_usuario", SqlDbType.Char, 17).Value = model.UserId;
                SqlParameter newVoucherNumber = new SqlParameter()
                {
                    ParameterName = "@int_deposito",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(newVoucherNumber);
                cmd.ExecuteNonQuery();
                newVaucher = (int)newVoucherNumber.Value;
                cmd.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newVaucher;
        }
    }
}