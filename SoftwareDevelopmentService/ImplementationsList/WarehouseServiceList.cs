using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class WarehouseServiceList : IWarehouseService
    {
        private DataListSingleton source;

        public WarehouseServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetList()
        {
			List<WarehouseViewModel> result = source.Warehouses
				.Select(rec => new WarehouseViewModel
				{
					Id = rec.Id,
					WarehouseName = rec.WarehouseName,
					WarehouseParts = source.WarehouseParts
							.Where(recPC => recPC.WarehouseId == rec.Id)
							.Select(recPC => new WarehousePartViewModel
							{
								Id = recPC.Id,
								WarehouseId = recPC.PartId,
								PartId = recPC.PartId,
								PartName = source.Parts
									.FirstOrDefault(recC => recC.Id == recPC.PartId)?.PartName,
								Number = recPC.Number
							})
							.ToList()
				})
				.ToList();
			return result;
		}

        public WarehouseViewModel GetElement(int id)
        {
			Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				return new WarehouseViewModel
				{
					Id = element.Id,
					WarehouseName = element.WarehouseName,
					WarehouseParts = source.WarehouseParts
							.Where(recPC => recPC.WarehouseId == element.Id)
							.Select(recPC => new WarehousePartViewModel
							{
								Id = recPC.Id,
								WarehouseId = recPC.WarehouseId,
								PartId = recPC.PartId,
								PartName = source.Parts
									.FirstOrDefault(recC => recC.Id == recPC.PartId)?.PartName,
								Number = recPC.Number
							})
							.ToList()
				};
			}
			throw new Exception("Элемент не найден");
		}

        public void AddElement(WarehouseBindingModel model)
        {
			Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName);
			if (element != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
			source.Warehouses.Add(new Warehouse
			{
				Id = maxId + 1,
				WarehouseName = model.WarehouseName
			});
		}

        public void UpdateElement(WarehouseBindingModel model)
        {
			Warehouse element = source.Warehouses.FirstOrDefault(rec =>
										rec.WarehouseName == model.WarehouseName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.WarehouseName = model.WarehouseName;
		}

        public void DeleteElement(int id)
        {
			// при удалении удаляем все записи о компонентах на удаляемом складе
			Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				// при удалении удаляем все записи о компонентах на удаляемом складе
				source.WarehouseParts.RemoveAll(rec => rec.WarehouseId == id);
				source.Warehouses.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
    }
}
