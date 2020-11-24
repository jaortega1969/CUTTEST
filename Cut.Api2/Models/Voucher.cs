using System;
namespace Cut.Api2.Models
{
    public class Voucher
    {
        public int Boleta { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string UserId { get; set; }
        public string Depositante { get; set; }
        public decimal MontoTotal { get; set; }
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public bool Pagado { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
