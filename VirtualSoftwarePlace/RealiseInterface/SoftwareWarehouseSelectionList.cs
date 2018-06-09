using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace;
using VirtualSoftware;

namespace VirtualSoftwarePlace.RealiseInterface
{ 
    public class SoftwareWarehouseSelectionList : ISoftwareWarehouseService
    {
        private BaseListSingleton source;

        public SoftwareWarehouseSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<SoftwareWarehouseUserViewModel> GetList()
        {
            List<SoftwareWarehouseUserViewModel> result = new List<SoftwareWarehouseUserViewModel>();
            for (int i = 0; i < source.SoftwareWarehouses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов на складе и их количество
                List<SoftwareWarehousePartViewModel> SoftwareWarehouseParts = new List<SoftwareWarehousePartViewModel>();
                for (int j = 0; j < source.SoftwareWarehousePart.Count; ++j)
                {
                    if (source.SoftwareWarehousePart[j].SoftwareWarehouseId == source.SoftwareWarehouses[i].Id)
                    {
                        string partName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareWarehousePart[j].PartId == source.Parts[k].Id)
                            {
                                partName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        SoftwareWarehouseParts.Add(new SoftwareWarehousePartViewModel
                        {
                            Id = source.SoftwareWarehousePart[j].Id,
                            SoftwareWarehouseId = source.SoftwareWarehousePart[j].SoftwareWarehouseId,
                            PartId = source.SoftwareWarehousePart[j].PartId,
                            PartName = partName,
                            Count = source.SoftwareWarehousePart[j].Count
                        });
                    }
                }
                result.Add(new SoftwareWarehouseUserViewModel
                {
                    Id = source.SoftwareWarehouses[i].Id,
                    SoftwareWarehouseName = source.SoftwareWarehouses[i].SoftwareWarehouseName,
                    SoftwareWarehouseParts = SoftwareWarehouseParts
                });
            }
            return result;
        }

        public SoftwareWarehouseUserViewModel GetPart(int id)
        {
            for (int i = 0; i < source.SoftwareWarehouses.Count; ++i)
            {
                // требуется дополнительно получить список компонентов на складе и их количество
                List<SoftwareWarehousePartViewModel> SoftwareWarehousePart = new List<SoftwareWarehousePartViewModel>();
                for (int j = 0; j < source.SoftwareWarehousePart.Count; ++j)
                {
                    if (source.SoftwareWarehousePart[j].SoftwareWarehouseId == source.SoftwareWarehouses[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareWarehousePart[j].PartId == source.Parts[k].Id)
                            {
                                componentName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        SoftwareWarehousePart.Add(new SoftwareWarehousePartViewModel
                        {
                            Id = source.SoftwareWarehousePart[j].Id,
                            SoftwareWarehouseId = source.SoftwareWarehousePart[j].SoftwareWarehouseId,
                            PartId = source.SoftwareWarehousePart[j].PartId,
                            PartName = componentName,
                            Count = source.SoftwareWarehousePart[j].Count
                        });
                    }
                }
                if (source.SoftwareWarehouses[i].Id == id)
                {
                    return new SoftwareWarehouseUserViewModel
                    {
                        Id = source.SoftwareWarehouses[i].Id,
                        SoftwareWarehouseName = source.SoftwareWarehouses[i].SoftwareWarehouseName,
                        SoftwareWarehouseParts = SoftwareWarehousePart
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddPart(SoftwareWarehouseConnectingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.SoftwareWarehouses.Count; ++i)
            {
                if (source.SoftwareWarehouses[i].Id > maxId)
                {
                    maxId = source.SoftwareWarehouses[i].Id;
                }
                if (source.SoftwareWarehouses[i].SoftwareWarehouseName == model.StockName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.SoftwareWarehouses.Add(new SoftwareWarehouse
            {
                Id = maxId + 1,
                SoftwareWarehouseName = model.StockName
            });
        }

        public void UpdPart(SoftwareWarehouseConnectingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.SoftwareWarehouses.Count; ++i)
            {
                if (source.SoftwareWarehouses[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.SoftwareWarehouses[i].SoftwareWarehouseName == model.StockName &&
                    source.SoftwareWarehouses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.SoftwareWarehouses[index].SoftwareWarehouseName = model.StockName;
        }

        public void DelPart(int id)
        {
            // при удалении удаляем все записи о компонентах на удаляемом складе
            for (int i = 0; i < source.SoftwareWarehousePart.Count; ++i)
            {
                if (source.SoftwareWarehousePart[i].SoftwareWarehouseId == id)
                {
                    source.SoftwareWarehousePart.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.SoftwareWarehouses.Count; ++i)
            {
                if (source.SoftwareWarehouses[i].Id == id)
                {
                    source.SoftwareWarehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
