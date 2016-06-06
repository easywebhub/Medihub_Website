using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using RAT.Backend.Api.DAL;

namespace RAT.Backend.Api.Service
{
    public interface IDrugStoreService
    {
        IEnumerable<DM_DrugStore> GetDrugStores();
        DM_DrugStore GetDmDrugStorebyId(long id);
        bool UpdateDmDrugStore(DM_DrugStore model);
    }
    public class DrugStoreService : IDrugStoreService
    {
        private readonly IUnitOfWorkSql _unitOfWork;

        public DrugStoreService(IUnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DM_DrugStore> GetDrugStores()
        {
            return _unitOfWork.Repository<DM_DrugStore>().Queryable().ToList();
        }

        public DM_DrugStore GetDmDrugStorebyId(long id)
        {
            return _unitOfWork.Repository<DM_DrugStore>().GetByID(id);
        }

        public bool UpdateDmDrugStore(DM_DrugStore model)
        {
            if (model.Id == 0)
            {
                _unitOfWork.Repository<DM_DrugStore>().Insert(model);
            }
            else
            {
                _unitOfWork.Repository<DM_DrugStore>().Update(model);
            }
              _unitOfWork.Save();
            return true;
        }
    }
}