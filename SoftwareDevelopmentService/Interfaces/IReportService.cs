using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.Interfaces
{
	public interface IReportService
	{

		void SaveSoftwareCost(ReportBindingModel model);

		List<WarehousesLoadViewModel> GetWarehousesLoad();

		void SaveWarehousesLoad(ReportBindingModel model);

		List<CustomerOffersModel> GetCustomerOffers(ReportBindingModel model);

		void SaveCustomerOffers(ReportBindingModel model);
	}
}
