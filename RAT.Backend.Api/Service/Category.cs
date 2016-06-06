using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using RAT.Backend.Api.DAL;
using RAT.Backend.Api.Models;

namespace RAT.Backend.Api.Service
{
    public interface ICategoryService 
    {
        IEnumerable<DM_Categories> GetCategorieses();
     
        DM_Categories GetCampaignbyId(long id);
        bool UpdateDmCategory(DM_Categories model);
        IEnumerable<DM_Brand> GetBrands();
     
        DM_Brand GetBrandsId(long id);
        bool UpdateBrands(DM_Brand model);

    }
    public class CategoryService  : ICategoryService
    {
        private readonly IUnitOfWorkSql _unitOfWork;

        public CategoryService(IUnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DM_Categories> GetCategorieses()
        {
            return _unitOfWork.Repository<DM_Categories>().Queryable().ToList();
        }



        public DM_Categories GetCampaignbyId(long id)
        {
           return _unitOfWork.Repository<DM_Categories>().GetByID(id);
        }

        public bool UpdateDmCategory(DM_Categories model)
        {
       
            if (model.Id == 0)
            {
                _unitOfWork.Repository<DM_Categories>().Insert(model);
            }
            else
            {
                _unitOfWork.Repository<DM_Categories>().Update(model);
            }
              _unitOfWork.Save();
            return true;
        }

        public IEnumerable<DM_Brand> GetBrands()
        {
             return _unitOfWork.Repository<DM_Brand>().Queryable().ToList();
        }

        public DM_Brand GetBrandsId(long id)
        {
             return _unitOfWork.Repository<DM_Brand>().GetByID(id);
        }

        public bool UpdateBrands(DM_Brand model)
        {
            if (model.Id == 0)
            {
                _unitOfWork.Repository<DM_Brand>().Insert(model);
            }
            else
            {
                _unitOfWork.Repository<DM_Brand>().Update(model);
            }
              _unitOfWork.Save();
            return true;
        }
    }
    }
}