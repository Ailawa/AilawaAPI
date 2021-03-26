using System.Collections.Generic;
using System.Linq;
using AilawaAPI.Data.models;
using Microsoft.EntityFrameworkCore;

namespace AilawaAPI.Service
{
    public class UploadCaseDetails : IUploadCaseDetails
    {

        private readonly AilawaContext context;

        public UploadCaseDetails(AilawaContext context)
        {
            this.context = context;
        }

        public string ExcelUpload(List<TempCaseDetails> tempCaseDetails)
        {
            context.TempCaseDetails.AddRange(tempCaseDetails);
            int output = context.SaveChanges();
            if (output > 0)
            {
                context.Database.ExecuteSqlCommand("EXEC usp_tempCaseDetails_UpdateLocationMasterID");
                return output.ToString() + " Records successfully uploaded from Excel file.";
            }
            else
                return "No record uploaded from Excel";
        }

        public List<TempCaseDetails> UploadedData()
        {
            return context.TempCaseDetails.AsEnumerable().ToList();
        }
    }
}