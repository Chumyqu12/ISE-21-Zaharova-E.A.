using SoftwareDevelopmentService.Attributies;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IGeneralService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<OfferViewModel> GetList();
        [CustomMethod("Метод создания заказа")]
        void CreateOffer(OfferBindingModel model);
        [CustomMethod("Метод передачи заказа в работу")]
        void TakeOfferInWork(OfferBindingModel model);
        [CustomMethod("Метод передачи заказа на оплату")]
        void FinalOffer(int id);
        [CustomMethod("Метод фиксирования оплаты по заказу")]
        void CostOffer(int id);
        [CustomMethod("Метод пополнения компонент на складе")]
        void PutPartOnWarehouse(WarehousePartBindingModel model);
    }
}
