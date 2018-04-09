using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    public interface IGeneralService
    {
        List<OfferViewModel> GetList();

        void CreateOffer(OfferBindingModel model);

        void TakeOfferInWork(OfferBindingModel model);

        void FinalOffer(int id);

        void CostOffer(int id);

        void PutPartOnWarehouse(WarehousePartBindingModel model);
    }
}
