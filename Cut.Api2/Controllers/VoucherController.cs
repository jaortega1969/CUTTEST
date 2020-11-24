using Cut.Api2.Models;
using Cut.Api2.Services;
using System.Data;
using System.Web.Http;

namespace Cut.Api2.Controllers
{
    public class VoucherController : ApiController
    {

        // GET: api/Voucher/5
        public Voucher Get(int id)
        {
            SPServices service = new SPServices();
            Voucher  newVoucher = service.GetVoucherById(id);
            return newVoucher;
        }



        // POST: api/Voucher
        public int Post([FromBody] Voucher newVoucher)
        {
            SPServices service = new SPServices();
            int result = service.CreateVoucher(newVoucher);
            return result;
        }

    }
}
