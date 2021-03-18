using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class Femaster
    {
        public Femaster()
        {
            CaseDetails = new HashSet<CaseDetails>();
            LocationMaster = new HashSet<LocationMaster>();
        }

        public Guid FemasterId { get; set; }
        public string Fename { get; set; }
        public string FemailId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<CaseDetails> CaseDetails { get; set; }
        public virtual ICollection<LocationMaster> LocationMaster { get; set; }
    }
}
