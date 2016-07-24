using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Medihub.Backend.Api.Helper;
using Medihub.Backend.Api.Storage.Couchbase;
using Medihub.Commons;
using Newtonsoft.Json.Linq;

namespace Medihub.Backend.Api.Controllers
{
    public class DanhmucController : ApiController
    {
        [HttpPost]
        public HttpContentResultModel<bool> InsertObjectJson(JObject model)
        {
            string bucket = CouchbaseConfigHelper.Instance.Bucket;
            var result = new HttpContentResultModel<bool>();
            try
            {
                if (String.IsNullOrEmpty(model["orderId"].ToString()))
                {
                    model["orderId"] = Guid.NewGuid().ToString();
                }
                var rs = CouchbaseStorageHelper.Instance.Upsert(model["orderId"].ToString(), model, bucket);

                if (!rs.Success || rs.Exception != null)
                {
                    throw new Exception("could not save user to Couchbase");
                }

                result.Data = true;
                result.StatusCode = Globals.StatusCode.Success.Code;
                result.Message = Globals.StatusCode.Success.Message;
                result.Result = true;
                result.ItemsCount = 1;

            }
            catch (Exception ex)
            {
                result.StatusCode = Globals.StatusCode.Error.Code;
                result.Message = ex.Message;
                result.Result = false;
                result.ItemsCount = 0;


            }

            return result;
        }

    }
}
