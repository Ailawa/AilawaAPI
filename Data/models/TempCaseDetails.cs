using System;
using System.Collections.Generic;

namespace AilawaAPI.Data.models
{
    public partial class TempCaseDetails
    {
        public Guid TempCaseDetailsId { get; set; }
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
        public string LocationName { get; set; }
        public Guid? LocationMasterId { get; set; }
        public Guid? StateMasterId { get; set; }
    }
}
