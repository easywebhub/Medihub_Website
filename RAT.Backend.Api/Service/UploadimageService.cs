using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using RAT.Backend.Api.DAL;

namespace RAT.Backend.Api.Service
{
    public interface IUploadService
    {
        bool Insert(TestUploadImage testUpload);
    }
    public class UploadService : IUploadService
    {
        private IUnitOfWorkSql _unitOfWork;

        public UploadService(IUnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Insert(TestUploadImage testUpload)
        {
            _unitOfWork.Repository<TestUploadImage>().Insert(testUpload);
            _unitOfWork.Save();
            return true;
        }
    }
}