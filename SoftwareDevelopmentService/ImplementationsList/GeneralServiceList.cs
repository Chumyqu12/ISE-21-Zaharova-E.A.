using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class GeneralServiceList : IGeneralService
    {
        private DataListSingleton source;

        public GeneralServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OfferViewModel> GetList()
        {
			List<OfferViewModel> result = source.Offers
				 .Select(rec => new OfferViewModel
				 {
					 Id = rec.Id,
					 CustomerId = rec.CustomerId,
					 SoftwareId = rec.SoftwareId,
					 DeveloperId = rec.DeveloperId,
					 Creation = rec.Creation.ToLongDateString(),
					 Implementation = rec.Implementation?.ToLongDateString(),
					 Condition = rec.Condition.ToString(),
					 Number = rec.Number,
					 Summa = rec.Summa,
					 CustomerName = source.Customers
									 .FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerName,
					 SoftwareName = source.Softwares
									 .FirstOrDefault(recP => recP.Id == rec.SoftwareId)?.SoftwareName,
					 DeveloperName = source.Developers
									 .FirstOrDefault(recI => recI.Id == rec.DeveloperId)?.DeveloperName
				 })
				 .ToList();
			return result;
		}

        public void CreateOffer(OfferBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Offers.Count; ++i)
            {
                if (source.Offers[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
            source.Offers.Add(new Offer
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                SoftwareId = model.SoftwareId,
                Creation = DateTime.Now,
                Number = model.Number,
                Summa = model.Summa,
                Condition = OfferCondition.Принят
            });
        }

        public void TakeOfferInWork(OfferBindingModel model)
        {
			Offer element = source.Offers.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			// смотрим по количеству компонентов на складах
			var SoftwareParts = source.SoftwareParts.Where(rec => rec.SoftwareId == element.SoftwareId);
			foreach (var softwarePart in SoftwareParts)
			{
				int countOnWarehouses = source.WarehouseParts
											.Where(rec => rec.PartId == softwarePart.PartId)
											.Sum(rec => rec.Number);
				if (countOnWarehouses < softwarePart.Number * element.Number)
				{
					var partName = source.Parts
									.FirstOrDefault(rec => rec.Id == softwarePart.PartId);
					throw new Exception("Не достаточно компонента " + partName?.PartName +
						" требуется " + softwarePart.Number + ", в наличии " + countOnWarehouses);
				}
			}
			// списываем
			foreach (var softwarePart in SoftwareParts)
			{
				int countOnWarehouses = softwarePart.Number * element.Number;
				var WarehouseParts = source.WarehouseParts
											.Where(rec => rec.PartId == softwarePart.PartId);
				foreach (var warehousePart in WarehouseParts)
				{
					// компонентов на одном слкаде может не хватать
					if (warehousePart.Number >= countOnWarehouses)
					{
						warehousePart.Number -= countOnWarehouses;
						break;
					}
					else
					{
						countOnWarehouses -= warehousePart.Number;
						warehousePart.Number = 0;
					}
				}
			}
			element.DeveloperId = model.DeveloperId;
			element.Implementation = DateTime.Now;
			element.Condition = OfferCondition.Выполняется;
		}

        public void FinalOffer(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Offers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Offers[index].Condition = OfferCondition.Готов;
        }

        public void CostOffer(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Offers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Offers[index].Condition = OfferCondition.Оплачен;
        }

		public void PutPartOnWarehouse(WarehousePartBindingModel model)
		{
			WarehousePart element = source.WarehouseParts
												  .FirstOrDefault(rec => rec.WarehouseId == model.WarehouseId &&
																	  rec.PartId == model.PartId);
			if (element != null)
			{
				element.Number += model.Number;
			}
			else
			{
				int maxId = source.WarehouseParts.Count > 0 ? source.WarehouseParts.Max(rec => rec.Id) : 0;
				source.WarehouseParts.Add(new WarehousePart
				{
					Id = ++maxId,
					WarehouseId = model.WarehouseId,
					PartId = model.PartId,
					Number = model.Number
				});
			}
		}
    }
}
