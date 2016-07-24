using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Medihub.Backend.Api.DAL;

namespace Medihub.Backend.Api.Service
{
    public interface ICustomerService
    {
        IEnumerable<KH_Customer> GetCustomers();
    }
    public class CustomerService : ICustomerService
    {
        private IUnitOfWorkSql _unitOfWork;

        public CustomerService(IUnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<KH_Customer> GetCustomers()
        {
            return _unitOfWork.Repository<KH_Customer>().Queryable().ToList();
        }
    }
}