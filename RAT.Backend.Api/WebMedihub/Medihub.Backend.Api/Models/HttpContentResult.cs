using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medihub.Backend.Api.Models
{
    
        public class HttpContentResult<T>
        {
            public bool Result { get; set; }
            public string StatusCode { get; set; }
            public string Message { get; set; }
            public string SysMessage { get; set; }
            public int TotalItem { get; set; }
            public T Data { get; set; }

        }



        public class HttpResponse
        {
            public bool Success { get; set; }

            public string SysMessage { get; set; }

            public string Message { get; set; }

            public string StatusCode { get; set; }

            public object Data { get; set; }

            public object RequestBody { get; set; }

        }

    
}