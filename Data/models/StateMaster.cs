using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class StateMaster
    {
        public StateMaster()
        {
            CaseDetails = new HashSet<CaseDetails>();
            LocationMaster = new HashSet<LocationMaster>();
        }

        public Guid StateMasterId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<CaseDetails> CaseDetails { get; set; }
        public virtual ICollection<LocationMaster> LocationMaster { get; set; }
    }
}
