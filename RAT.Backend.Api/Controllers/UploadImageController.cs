using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using RAT.Backend.Api.DAL;
using RAT.Backend.Api.Service;

namespace RAT.Backend.Api.Controllers
{
    [RoutePrefix("api/uploadImage")]
    public class UploadImageController : ApiController
    {
          private readonly IUploadService _uploadService;
          public UploadImageController()
        {
            var context = new SqlDbContext();
            _uploadService = new UploadService(new UnitOfWorkMssql(context));
        }

        [HttpPost()]
        public string UploadFiles()
        {
            int iUploadedCnt = 0;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Upload/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        var test = new TestUploadImage
                        {
                            CreatedDate = DateTime.Now,
                            Name = hpf.FileName,
                            UrlImage = String.Format("/Content/Upload/{0}",hpf.FileName)
                        };
                        _uploadService.Insert(test);
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }

            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully";
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
