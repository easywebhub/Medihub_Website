﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medihub.Commons
{
    public class ServiceResult
    {
        public bool Successfully { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public string StatusCode { get; set; } // mở rộng
    }

    public class ServiceResult<T>
    {
        public bool Successfully { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public string StatusCode { get; set; } // mở rộng

        public T Data { get; set; }

        public ServiceResult() { }

        public ServiceResult(bool result, string message, T data)
            : this(result, message, data, null)
        {

        }

        public ServiceResult(bool result, string message, T data, Exception ex)
        {
            Successfully = result;
            Message = message;
            Data = data;
            Exception = ex;
        }
    }

}
