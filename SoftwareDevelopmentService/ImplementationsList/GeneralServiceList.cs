using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;

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
            List<OfferViewModel> result = new List<OfferViewModel>();
            for (int i = 0; i < source.Offers.Count; ++i)
            {
                string CustomerName = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if(source.Customers[j].Id == source.Offers[i].CustomerId)
                    {
                        CustomerName = source.Customers[j].CustomerName;
                        break;
                    }
                }
                string SoftwareName = string.Empty;
                for (int j = 0; j < source.Softwares.Count; ++j)
                {
                    if (source.Softwares[j].Id == source.Offers[i].SoftwareId)
                    {
                        SoftwareName = source.Softwares[j].SoftwareName;
                        break;
                    }
                }
                string DeveloperName = string.Empty;
                if(source.Offers[i].DeveloperId.HasValue)
                {
                    for (int j = 0; j < source.Developers.Count; ++j)
                    {
                        if (source.Developers[j].Id == source.Offers[i].DeveloperId.Value)
                        {
                            DeveloperName = source.Developers[j].DeveloperName;
                            break;
                        }
                    }
                }
                result.Add(new OfferViewModel
                {
                    Id = source.Offers[i].Id,
                    CustomerId = source.Offers[i].CustomerId,
                    CustomerName= CustomerName,
                    SoftwareId = source.Offers[i].SoftwareId,
                    SoftwareName = SoftwareName,
                    DeveloperId = source.Offers[i].DeveloperId,
                    DeveloperName = DeveloperName,
                    Number = source.Offers[i].Number,
                    Summa = source.Offers[i].Summa,
                    Creation = source.Offers[i].Creation.ToLongDateString(),
                    Implementation = source.Offers[i].Implementation?.ToLongDateString(),
                    Condition = source.Offers[i].Condition.ToString()
                });
            }
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
            int index = -1;
            for (int i = 0; i < source.Offers.Count; ++i)
            {
                if (source.Offers[i].Id == model.Id)
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
            for(int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if(source.SoftwareParts[i].SoftwareId == source.Offers[index].SoftwareId)
                {
                    int countOnStocks = 0;
                    for(int j = 0; j < source.SoftwareParts.Count; ++j)
                    {
                        if(source.SoftwareParts[j].PartId == source.SoftwareParts[i].PartId)
                        {
                            countOnStocks += source.SoftwareParts[j].Number;
                        }
                    }
                    if(countOnStocks < source.SoftwareParts[i].Number * source.Offers[index].Number)
                    {
                        for (int j = 0; j < source.Parts.Count; ++j)
                        {
                            if (source.Parts[j].Id == source.SoftwareParts[i].PartId)
                            {
                                throw new Exception("Не достаточно компонента " + source.Parts[j].PartName + 
                                    " требуется " + source.SoftwareParts[i].Number + ", в наличии " + countOnStocks);
                            }
                        }
                    }
                }
            }
            // списываем
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].SoftwareId == source.Offers[index].SoftwareId)
                {
                    int countOnStocks = source.SoftwareParts[i].Number * source.Offers[index].Number;
                    for (int j = 0; j < source.WarehouseParts.Count; ++j)
                    {
                        if (source.WarehouseParts[j].PartId == source.SoftwareParts[i].PartId)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (source.WarehouseParts[j].Number >= countOnStocks)
                            {
                                source.WarehouseParts[j].Number -= countOnStocks;
                                break;
                            }
                            else
                            {
                                countOnStocks -= source.WarehouseParts[j].Number;
                                source.WarehouseParts[j].Number = 0;
                            }
                        }
                    }
                }
            }
            source.Offers[index].DeveloperId = model.DeveloperId;
            source.Offers[index].Implementation = DateTime.Now;
            source.Offers[index].Condition = OfferCondition.Выполняется;
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
            int maxId = 0;
            for (int i = 0; i < source.WarehouseParts.Count; ++i)
            {
                if(source.WarehouseParts[i].WarehouseId == model.WarehouseId && 
                    source.WarehouseParts[i].PartId == model.PartId)
                {
                    source.WarehouseParts[i].Number += model.Number;
                    return;
                }
                if (source.WarehouseParts[i].Id > maxId)
                {
                    maxId = source.WarehouseParts[i].Id;
                }
            }
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
