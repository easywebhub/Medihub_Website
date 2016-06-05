using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using RAT.Backend.Api.DAL;
using RAT.Backend.Api.Models;
using RAT.Backend.Api.Service;
using RAT.Commons;

namespace RAT.Backend.Api.Controllers
{
    public class CustomerController : ApiController
    {
          private readonly ICustomerService _customerService;
          public CustomerController()
        {
            var context = new SqlDbContext();
            _customerService = new CustomerService(new UnitOfWorkMssql(context));
        }
          [HttpGet]
          public HttpContentResult<IEnumerable<dynamic>> GetBusiness()
          {
              var result = new HttpContentResult<IEnumerable<dynamic>>();
              try
              {
                  var lst = _customerService.GetCustomers();
                  result.Data = lst;
                  result.Result = true;
                  result.StatusCode = GlobalsEnum.GlobalStatus.Success.ToString();
                  result.Message = "Success Load";
              }
              catch (Exception ex)
              {
                  result.StatusCode = GlobalsEnum.GlobalStatus.Failed.ToString();
                  result.SysMessage = ex.ToString();
                  result.Result = false;
                  throw;
              }
              return result;
          }
    }
}
