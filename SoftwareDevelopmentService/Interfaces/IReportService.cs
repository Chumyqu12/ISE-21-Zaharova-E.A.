using SoftwareDevelopmentService.Attributies;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
	{
        [CustomMethod("Метод сохранения списка изделий в doc-файл")]
        void SaveSoftwareCost(ReportBindingModel model);
        [CustomMethod("Метод получения списка складов с количество компонент на них")]
        List<WarehousesLoadViewModel> GetWarehousesLoad();
        [CustomMethod("Метод сохранения списка списка складов с количество компонент на них в xls-файл")]
        void SaveWarehousesLoad(ReportBindingModel model);
        [CustomMethod("Метод получения списка заказов клиентов")]
        List<CustomerOffersModel> GetCustomerOffers(ReportBindingModel model);
        [CustomMethod("Метод сохранения списка заказов клиентов в pdf-файл")]
        void SaveCustomerOffers(ReportBindingModel model);
	}
}
