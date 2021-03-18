using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class LocationMaster
    {
        public LocationMaster()
        {
            CaseDetails = new HashSet<CaseDetails>();
        }

        public Guid LocationMasterId { get; set; }
        public string LocationName { get; set; }
        public Guid StateMasterId { get; set; }
        public Guid? FemasterId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual Femaster Femaster { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        public virtual ICollection<CaseDetails> CaseDetails { get; set; }
    }
}
