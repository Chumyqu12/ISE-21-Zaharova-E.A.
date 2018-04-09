using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class SoftwareServiceList : ISoftwareService
    {
        private DataListSingleton source;

        public SoftwareServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SoftwareViewModel> GetList()
        {
            List<SoftwareViewModel> result = new List<SoftwareViewModel>();
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<SoftwarePartViewModel> SoftwareParts = new List<SoftwarePartViewModel>();
                for (int j = 0; j < source.SoftwareParts.Count; ++j)
                {
                    if (source.SoftwareParts[j].SoftwareId == source.Softwares[i].Id)
                    {
                        string PartName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareParts[j].PartId == source.Parts[k].Id)
                            {
                                PartName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        SoftwareParts.Add(new SoftwarePartViewModel
                        {
                            Id = source.SoftwareParts[j].Id,
                            SoftwareId = source.SoftwareParts[j].SoftwareId,
                            PartId = source.SoftwareParts[j].PartId,
                            PartName = PartName,
                            Number = source.SoftwareParts[j].Number
                        });
                    }
                }
                result.Add(new SoftwareViewModel
                {
                    Id = source.Softwares[i].Id,
                    SoftwareName = source.Softwares[i].SoftwareName,
                    Cost = source.Softwares[i].Cost,
                    SoftwareParts = SoftwareParts
                });
            }
            return result;
        }

        public SoftwareViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<SoftwarePartViewModel> SoftwareParts = new List<SoftwarePartViewModel>();
                for (int j = 0; j < source.SoftwareParts.Count; ++j)
                {
                    if (source.SoftwareParts[j].SoftwareId == source.Softwares[i].Id)
                    {
                        string PartName = string.Empty;
                        for (int k = 0; k < source.Softwares.Count; ++k)
                        {
                            if (source.SoftwareParts[j].PartId == source.Parts[k].Id)
                            {
                                PartName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        SoftwareParts.Add(new SoftwarePartViewModel
                        {
                            Id = source.SoftwareParts[j].Id,
                            SoftwareId = source.SoftwareParts[j].SoftwareId,
                            PartId = source.SoftwareParts[j].PartId,
                            PartName = PartName,
                            Number = source.SoftwareParts[j].Number
                        });
                    }
                }
                if (source.Softwares[i].Id == id)
                {
                    return new SoftwareViewModel
                    {
                        Id = source.Softwares[i].Id,
                        SoftwareName = source.Softwares[i].SoftwareName,
                        Cost = source.Softwares[i].Cost,
                        SoftwareParts = SoftwareParts
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(SoftwareBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                if (source.Softwares[i].Id > maxId)
                {
                    maxId = source.Softwares[i].Id;
                }
                if (source.Softwares[i].SoftwareName == model.SoftwareName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Softwares.Add(new Software
            {
                Id = maxId + 1,
                SoftwareName = model.SoftwareName,
                Cost = model.Cost
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].Id > maxPCId)
                {
                    maxPCId = source.SoftwareParts[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.SoftwareParts.Count; ++i)
            {
                for (int j = 1; j < model.SoftwareParts.Count; ++j)
                {
                    if(model.SoftwareParts[i].PartId ==
                        model.SoftwareParts[j].PartId)
                    {
                        model.SoftwareParts[i].Number +=
                            model.SoftwareParts[j].Number;
                        model.SoftwareParts.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.SoftwareParts.Count; ++i)
            {
                source.SoftwareParts.Add(new SoftwarePart
                {
                    Id = ++maxPCId,
                    SoftwareId = maxId + 1,
                    PartId = model.SoftwareParts[i].PartId,
                    Number = model.SoftwareParts[i].Number
                });
            }
        }

        public void UpdateElement(SoftwareBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                if (source.Softwares[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Softwares[i].SoftwareName == model.SoftwareName && 
                    source.Softwares[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Softwares[index].SoftwareName = model.SoftwareName;
            source.Softwares[index].Cost = model.Cost;
            int maxPCId = 0;
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].Id > maxPCId)
                {
                    maxPCId = source.SoftwareParts[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].SoftwareId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.SoftwareParts.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.SoftwareParts[i].Id == model.SoftwareParts[j].Id)
                        {
                            source.SoftwareParts[i].Number = model.SoftwareParts[j].Number;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if(flag)
                    {
                        source.SoftwareParts.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for(int i = 0; i < model.SoftwareParts.Count; ++i)
            {
                if(model.SoftwareParts[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.SoftwareParts.Count; ++j)
                    {
                        if (source.SoftwareParts[j].SoftwareId == model.Id &&
                            source.SoftwareParts[j].PartId == model.SoftwareParts[i].PartId)
                        {
                            source.SoftwareParts[j].Number += model.SoftwareParts[i].Number;
                            model.SoftwareParts[i].Id = source.SoftwareParts[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.SoftwareParts[i].Id == 0)
                    {
                        source.SoftwareParts.Add(new SoftwarePart
                        {
                            Id = ++maxPCId,
                            SoftwareId = model.Id,
                            PartId = model.SoftwareParts[i].PartId,
                            Number = model.SoftwareParts[i].Number
                        });
                    }
                }
            }
        }

        public void DeleteElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.SoftwareParts.Count; ++i)
            {
                if (source.SoftwareParts[i].SoftwareId == id)
                {
                    source.SoftwareParts.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                if (source.Softwares[i].Id == id)
                {
                    source.Softwares.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
