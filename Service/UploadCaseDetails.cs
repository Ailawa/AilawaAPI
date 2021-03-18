using System.Collections.Generic;
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
                return "Excel file has been successfully uploaded";
            }
            else
                return "Excel file uploaded has fiald";
        }

        public List<TempCaseDetails> UploadedData()
        {
            throw new System.NotImplementedException();
        }
    }
}