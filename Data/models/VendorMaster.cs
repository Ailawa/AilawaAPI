using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class VendorMaster
    {
        public VendorMaster()
        {
            CaseDetails = new HashSet<CaseDetails>();
        }

        public Guid VendorMasterId { get; set; }
        public string VendorName { get; set; }
        public int OrderNo { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<CaseDetails> CaseDetails { get; set; }
    }
}
