using System.Collections.Generic;
using System.Linq;
using AilawaAPI.Data.models;

namespace AilawaAPI.Service
{
    public class VendorDetails : IVendorDetails
    {
        private readonly AilawaContext context;
        public VendorDetails(AilawaContext context)
        {
            this.context = context;
        }

        public IEnumerable<VendorMaster> GetVendorDetails()
        {
            return context.VendorMaster.OrderBy(V => V.OrderNo).AsEnumerable();
        }
    }
}