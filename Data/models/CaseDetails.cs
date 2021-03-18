using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class CaseDetails
    {
        public Guid CaseDetailsId { get; set; }
        public Guid VendorMasterId { get; set; }
        public string ClientName { get; set; }
        public string CaseRefId { get; set; }
        public string CandidateName { get; set; }
        public string FatherName { get; set; }
        public string CandidateAddress { get; set; }
        public string AddressType { get; set; }
        public string LandMark { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string AlternateNo { get; set; }
        public string DateOfBirth { get; set; }
        public string PeriodOfStayTo { get; set; }
        public string PeriodOfStayFrom { get; set; }
        public string ClientRefNo { get; set; }
        public string TransactionNo { get; set; }
        public string Pincode { get; set; }
        public string LocationType { get; set; }
        public Guid? LocationMasterId { get; set; }
        public Guid? StateMasterId { get; set; }
        public DateTime Doi { get; set; }
        public DateTime? Doc { get; set; }
        public bool? CaseStatus { get; set; }
        public string Remarks { get; set; }
        public Guid? FemasterId { get; set; }

        public virtual Femaster Femaster { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        public virtual VendorMaster VendorMaster { get; set; }
    }
}
