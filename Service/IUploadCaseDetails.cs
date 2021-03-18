using System.Collections.Generic;
using AilawaAPI.Data.models;

namespace AilawaAPI.Service
{
    public interface IUploadCaseDetails
    {
         string ExcelUpload(List<TempCaseDetails> tempCaseDetails);

         List<TempCaseDetails> UploadedData();
    }
}