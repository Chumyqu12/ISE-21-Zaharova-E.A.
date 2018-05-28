using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftware;

namespace VirtualSoftwarePlace.RealiseInterface
{
    public class GeneralSelectionList : IGeneralSelection
    {
        private BaseListSingleton source;

        public GeneralSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<CustomerSelectionUserViewModel> GetList()
        {
            List<CustomerSelectionUserViewModel> result = new List<CustomerSelectionUserViewModel>();
            for (int i = 0; i < source.CustomerSelections.Count; ++i)
            {
                string customerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.CustomerSelections[i].CustomerId)
                    {
                        customerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string SoftwareName = string.Empty;
                for (int j = 0; j < source.Softwares.Count; ++j)
                {
                    if (source.Softwares[j].Id == source.CustomerSelections[i].SoftwareId)
                    {
                        SoftwareName = source.Softwares[j].SoftwareName;
                        break;
                    }
                }
                string developerFIO = string.Empty;
                if (source.CustomerSelections[i].DeveloperId.HasValue)
                {
                    for (int j = 0; j < source.Developers.Count; ++j)
                    {
                        if (source.Developers[j].Id == source.CustomerSelections[i].DeveloperId.Value)
                        {
                            developerFIO = source.Developers[j].DeveloperFIO;
                            break;
                        }
                    }
                }
                result.Add(new CustomerSelectionUserViewModel
                {
                    Id = source.CustomerSelections[i].Id,
                    CustomerId = source.CustomerSelections[i].CustomerId,
                    CustomerFIO = customerFIO,
                    SoftwareId = source.CustomerSelections[i].SoftwareId,
                    SoftwareName = SoftwareName,
                    DeveloperId = source.CustomerSelections[i].DeveloperId,
                    DeveloperName = developerFIO,
                    Count = source.CustomerSelections[i].Count,
                    Sum = source.CustomerSelections[i].Sum,
                    DateCreate = source.CustomerSelections[i].DateCreate.ToLongDateString(),
                    DateCook = source.CustomerSelections[i].DateImplement?.ToLongDateString(),
                    Status = source.CustomerSelections[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateOrder(CustomerSelectionModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.CustomerSelections.Count; ++i)
            {
                if (source.CustomerSelections[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
            source.CustomerSelections.Add(new CustomerSelection
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                SoftwareId = model.SoftwareId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = CustomerSelectionCondition.Принят
            });
        }

        public void TakeOrderInWork(CustomerSelectionModel model)
        {
            int index = -1;
            for (int i = 0; i < source.CustomerSelections.Count; ++i)
            {
                if (source.CustomerSelections[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            // смотрим по количеству компонентов на складах
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].SoftwareId == source.CustomerSelections[index].SoftwareId)
                {
                    int countOnStocks = 0;
                    for (int j = 0; j < source.SoftwareWarehousePart.Count; ++j)
                    {
                        if (source.SoftwareWarehousePart[j].PartId == source.SoftwareParts[i].PartId)
                        {
                            countOnStocks += source.SoftwareWarehousePart[j].Count;
                        }
                    }
                    if (countOnStocks < source.SoftwareParts[i].Count * source.CustomerSelections[index].Count)
                    {
                        for (int j = 0; j < source.Parts.Count; ++j)
                        {
                            if (source.Parts[j].Id == source.SoftwareParts[i].PartId)
                            {
                                throw new Exception("Не достаточно компонента " + source.Parts[j].PartName +
                                    " требуется " + source.SoftwareParts[i].Count + ", в наличии " + countOnStocks);
                            }
                        }
                    }
                }
            }
            // списываем
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].SoftwareId == source.CustomerSelections[index].SoftwareId)
                {
                    int countOnStocks = source.SoftwareParts[i].Count * source.CustomerSelections[index].Count;
                    for (int j = 0; j < source.SoftwareWarehousePart.Count; ++j)
                    {
                        if (source.SoftwareWarehousePart[j].PartId == source.SoftwareParts[i].PartId)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (source.SoftwareWarehousePart[j].Count >= countOnStocks)
                            {
                                source.SoftwareWarehousePart[j].Count -= countOnStocks;
                                break;
                            }
                            else
                            {
                                countOnStocks -= source.SoftwareWarehousePart[j].Count;
                                source.SoftwareWarehousePart[j].Count = 0;
                            }
                        }
                    }
                }
            }
            source.CustomerSelections[index].DeveloperId = model.DeveloperId;
            source.CustomerSelections[index].DateImplement = DateTime.Now;
            source.CustomerSelections[index].Status = CustomerSelectionCondition.Готовиться;
        }

        public void FinishOrder(int id)
        {
            int index = -1;
            for (int i = 0; i < source.CustomerSelections.Count; ++i)
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
            source.CustomerSelections[index].Status = CustomerSelectionCondition.Готов;
        }

        public void PayOrder(int id)
        {
            int index = -1;
            for (int i = 0; i < source.CustomerSelections.Count; ++i)
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
            source.CustomerSelections[index].Status = CustomerSelectionCondition.Оплачен;
        }

        public void PutComponentOnStock(SoftwareWarehousePartConnectingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.SoftwareWarehousePart.Count; ++i)
            {
                if (source.SoftwareWarehousePart[i].SoftwareWarehouseId == model.SoftwareWarehouseId &&
                    source.SoftwareWarehousePart[i].PartId == model.PartId)
                {
                    source.SoftwareWarehousePart[i].Count += model.Count;
                    return;
                }
                if (source.SoftwareWarehousePart[i].Id > maxId)
                {
                    maxId = source.SoftwareWarehousePart[i].Id;
                }
            }
            source.SoftwareWarehousePart.Add(new SoftwareWarehousePart
            {
                Id = ++maxId,
                SoftwareWarehouseId = model.SoftwareWarehouseId,
                PartId = model.PartId,
                Count = model.Count
            });
        }
    }
}
