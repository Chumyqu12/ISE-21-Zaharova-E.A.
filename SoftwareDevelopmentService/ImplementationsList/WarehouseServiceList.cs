using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;

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
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов на складе и их количество
                List<WarehousePartViewModel> StockComponents = new List<WarehousePartViewModel>();
                for (int j = 0; j < source.WarehouseParts.Count; ++j)
                {
                    if (source.WarehouseParts[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string ParttName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareParts[j].PartId == source.Parts[k].Id)
                            {
                                ParttName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        StockComponents.Add(new WarehousePartViewModel
                        {
                            Id = source.WarehouseParts[j].Id,
                            WarehouseId = source.WarehouseParts[j].WarehouseId,
                            PartId = source.WarehouseParts[j].PartId,
                            PartName = ParttName,
                            Number = source.WarehouseParts[j].Number
                        });
                    }
                }
                result.Add(new WarehouseViewModel
                {
                    Id = source.Warehouses[i].Id,
                    WarehouseName = source.Warehouses[i].WarehouseName,
                    WarehouseParts = StockComponents
                });
            }
            return result;
        }

        public WarehouseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов на складе и их количество
                List<WarehousePartViewModel> WarehouseParts = new List<WarehousePartViewModel>();
                for (int j = 0; j < source.WarehouseParts.Count; ++j)
                {
                    if (source.WarehouseParts[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareParts[j].PartId == source.Parts[k].Id)
                            {
                                componentName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        WarehouseParts.Add(new WarehousePartViewModel
                        {
                            Id = source.WarehouseParts[j].Id,
                            WarehouseId = source.WarehouseParts[j].WarehouseId,
                            PartId = source.WarehouseParts[j].PartId,
                            PartName = componentName,
                            Number = source.WarehouseParts[j].Number
                        });
                    }
                }
                if (source.Warehouses[i].Id == id)
                {
                    return new WarehouseViewModel
                    {
                        Id = source.Warehouses[i].Id,
                        WarehouseName = source.Warehouses[i].WarehouseName,
                        WarehouseParts = WarehouseParts
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(WarehouseBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id > maxId)
                {
                    maxId = source.Warehouses[i].Id;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }

        public void UpdateElement(WarehouseBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName && 
                    source.Warehouses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Warehouses[index].WarehouseName = model.WarehouseName;
        }

        public void DeleteElement(int id)
        {
            // при удалении удаляем все записи о компонентах на удаляемом складе
            for (int i = 0; i < source.WarehouseParts.Count; ++i)
            {
                if (source.WarehouseParts[i].WarehouseId == id)
                {
                    source.WarehouseParts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
