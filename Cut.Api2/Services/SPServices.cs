using Cut.Api2.Helpers;
using Cut.Api2.Models;
using System;
using System.Data;


namespace Cut.Api2.Services
{
    public class SPServices
    {
        public SPServices()
        {

        }

        /*public Voucher GetVoucherById(int Id)*/
        public Voucher GetVoucherById(int Id)
        {
            var cnxSql = new Connection();
            var newVoucher = new Voucher();

            try
            {
                DataSet datos = cnxSql.GetVoucher(Id);
                foreach (DataRow dr in datos.Tables[0].Rows)
                {
                    var result = new Voucher()
                    {
                        FechaEmision = Convert.ToDateTime(dr["fecha"]),
                        Depositante = Convert.ToString(dr["usuario"]),
                        Detalle = Convert.ToString(dr["detalle"]),
                        Codigo = Convert.ToString(dr["codigo"]),
                        Nombre = Convert.ToString(dr["nombre"]),
                        MontoTotal = Convert.ToDecimal(dr["valor"]),
                        Valor = Convert.ToDecimal(dr["valor"]),
                        Boleta = Convert.ToInt32(dr["deposito"]),
                        Pagado = Convert.ToString(dr["flag"]).ToUpper() == "P",
                        FechaPago = (dr["fecha_a"] != DBNull.Value) ? Convert.ToDateTime(dr["fecha_a"]) : (DateTime?)null,
                        Ruc = Convert.ToString(dr["cedula"]),
                        UserId = Convert.ToString(dr["userId"]),
                    };

                    newVoucher = result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newVoucher;
        }

        public int CreateVoucher(Voucher model)
        {
            var cnxSql = new Connection();
            int result = cnxSql.RunGetVaucherSP(model);
            return result;
        }

    }
}