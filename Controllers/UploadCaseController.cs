using AilawaAPI.Service;
using Microsoft.AspNetCore.Mvc;
using AilawaAPI.Data.models;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Net.Mime;

namespace AilawaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadCaseController : ControllerBase
    {
        private readonly IUploadCaseDetails uploadCaseDetails;
        public UploadCaseController(IUploadCaseDetails uploadCaseDetails)
        {
            this.uploadCaseDetails = uploadCaseDetails;
        }

        [Route("UploadExcel")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult ExcelUpload()
        {
            string message = "";
            FileInfo caseFile = null;
            try
            {
                var file = Request.Form.Files[0];
                Guid VendorID = Guid.Parse(Request.Form["VendorMasterID"]);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "temp");

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    caseFile = new FileInfo(fullPath);
                    if (caseFile.Extension == ".xls" || caseFile.Extension == ".xlsx")
                    {
                        using (ExcelPackage package = new ExcelPackage(caseFile))
                        {
                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                            List<TempCaseDetails> tempCaseDetails = new List<TempCaseDetails>();

                            for (int i = 2; i <= workSheet.Dimension.Rows; i++)
                            {
                                tempCaseDetails.Add(new TempCaseDetails
                                {
                                    TempCaseDetailsId = Guid.NewGuid(),
                                    VendorMasterId = VendorID,
                                    ClientName = workSheet.Cells[i, 1].Text,
                                    CaseRefId = workSheet.Cells[i, 2].Text,
                                    CandidateName = workSheet.Cells[i, 3].Text,
                                    FatherName = workSheet.Cells[i, 4].Text,
                                    CandidateAddress = workSheet.Cells[i, 6].Text,
                                    AddressType = workSheet.Cells[i, 5].Text,
                                    MobileNo = workSheet.Cells[i, 10].Text,
                                    ContactNo = workSheet.Cells[i, 11].Text,
                                    Pincode = workSheet.Cells[i, 7].Text,
                                    LocationName = workSheet.Cells[i, 8].Text
                                });
                            }
                            message = uploadCaseDetails.ExcelUpload(tempCaseDetails);
                        }
                    }
                    else
                        message = "Uploaded File is not Excel. Please Upload Excel File.";
                }
                return Ok(message);
            }
            catch (Exception)
            {
                return Ok("error");
            }
            finally
            {
                if (caseFile.Exists)
                {
                    caseFile.Delete();
                }
            }
        }
    }
}