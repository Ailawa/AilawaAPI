using System.Collections.Generic;
using AilawaAPI.Data.models;

namespace AilawaAPI.Service
{
    public interface IVendorDetails
    {
         IEnumerable<VendorMaster> GetVendorDetails();
    }
}