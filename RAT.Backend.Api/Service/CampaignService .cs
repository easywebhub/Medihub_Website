using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using RAT.Backend.Api.DAL;
using RAT.Backend.Api.Models;

namespace RAT.Backend.Api.Service
{
    public interface ICampaignService 
    {
        IEnumerable<KH_Campaign> GetAllCampaigns();
        IEnumerable<KH_Campaign> GetListCampaignbyCustomerId(int customerId);
        KH_Campaign GetCampaignbyId(long id);
        bool UpdateKhCampaign(KH_Campaign model);
         bool UpdateMapCampaignDrug(CampaignDrugModel model);
    }
    public class CampaignService  : ICampaignService
    {
        private readonly IUnitOfWorkSql _unitOfWork;

        public CampaignService(IUnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<KH_Campaign> GetAllCampaigns()
        {
            return _unitOfWork.Repository<KH_Campaign>().Queryable().ToList();
        }

        public IEnumerable<KH_Campaign> GetListCampaignbyCustomerId(int customerId)
        {
          return  _unitOfWork.Repository<KH_Campaign>().Queryable().Where(x => x.CustomerId == customerId).ToList();
        }

        public KH_Campaign GetCampaignbyId(long id)
        {
           return _unitOfWork.Repository<KH_Campaign>().GetByID(id);
        }

        public bool UpdateKhCampaign(KH_Campaign model)
        {
       
            if (model.Id == 0)
            {
                _unitOfWork.Repository<KH_Campaign>().Insert(model);
            }
            else
            {
                _unitOfWork.Repository<KH_Campaign>().Update(model);
            }
              _unitOfWork.Save();
            return true;
        }

        public bool UpdateMapCampaignDrug(CampaignDrugModel model)
        {
            foreach (var detail in model.ListDrugId)
            {
                
            }
            return true;
        }
    
    }
}