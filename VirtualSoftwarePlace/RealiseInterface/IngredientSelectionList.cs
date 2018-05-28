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
    public class SoftwareSelectionList : ISoftwareService
    {
        private BaseListSingleton source;

        public SoftwareSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<SoftwareUserViewModel> GetList()
        {
            List<SoftwareUserViewModel> result = new List<SoftwareUserViewModel>();
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<SoftwarePartUserViewModel> SoftwareParts = new List<SoftwarePartUserViewModel>();
                //////////////////////////////////////////////////////////
                for (int j = 0; j < source.SoftwareParts.Count; ++j)
                {
                    if (source.SoftwareParts[j].SoftwareId == source.Softwares[i].Id)
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
                        SoftwareParts.Add(new SoftwarePartUserViewModel
                        {
                            Id = source.SoftwareParts[j].Id,
                            SoftwareId = source.SoftwareParts[j].SoftwareId,
                            PartId = source.SoftwareParts[j].PartId,
                            PartName = componentName,
                            Count = source.SoftwareParts[j].Count
                        });
                    }
                }
                result.Add(new SoftwareUserViewModel
                {
                    Id = source.Softwares[i].Id,
                    SoftwareName = source.Softwares[i].SoftwareName,
                    Price = source.Softwares[i].Cost,
                    SoftwarePart = SoftwareParts
                });
            }
            return result;
        }
        public void AddPart(SoftwareConnectingModel model)
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
                Cost = model.Value
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
            for (int i = 0; i < model.SoftwarePart.Count; ++i)
            {
                for (int j = 1; j < model.SoftwarePart.Count; ++j)
                {
                    if (model.SoftwarePart[i].PartId ==
                        model.SoftwarePart[j].PartId)
                    {
                        model.SoftwarePart[i].Count +=
                            model.SoftwarePart[j].Count;
                        model.SoftwarePart.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.SoftwarePart.Count; ++i)
            {
                source.SoftwareParts.Add(new SoftwarePart
                {
                    Id = ++maxPCId,
                    SoftwareId = maxId + 1,
                    PartId = model.SoftwarePart[i].PartId,
                    Count = model.SoftwarePart[i].Count
                });
            }
        }

        public void UpdPart(SoftwareConnectingModel model)
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
            source.Softwares[index].Cost = model.Value;
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
                    for (int j = 0; j < model.SoftwarePart.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.SoftwareParts[i].Id == model.SoftwarePart[j].Id)
                        {
                            source.SoftwareParts[i].Count = model.SoftwarePart[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.SoftwareParts.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.SoftwarePart.Count; ++i)
            {
                if (model.SoftwarePart[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.SoftwareParts.Count; ++j)
                    {
                        if (source.SoftwareParts[j].SoftwareId == model.Id &&
                            source.SoftwareParts[j].PartId == model.SoftwarePart[i].PartId)
                        {
                            source.SoftwareParts[j].Count += model.SoftwarePart[i].Count;
                            model.SoftwarePart[i].Id = source.SoftwareParts[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.SoftwarePart[i].Id == 0)
                    {
                        source.SoftwareParts.Add(new SoftwarePart
                        {
                            Id = ++maxPCId,
                            SoftwareId = model.Id,
                            PartId = model.SoftwarePart[i].PartId,
                            Count = model.SoftwarePart[i].Count
                        });
                    }
                }
            }
        }

        public SoftwareUserViewModel GetPart(int id)
        {
            for (int i = 0; i < source.Softwares.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<SoftwarePartUserViewModel> SoftwareParts = new List<SoftwarePartUserViewModel>();
                for (int j = 0; j < source.SoftwareParts.Count; ++j)
                {
                    if (source.SoftwareParts[j].SoftwareId == source.Softwares[i].Id)
                    {
                        string partName = string.Empty;
                        for (int k = 0; k < source.Parts.Count; ++k)
                        {
                            if (source.SoftwareParts[j].SoftwareId == source.Parts[k].Id)
                            {
                                partName = source.Parts[k].PartName;
                                break;
                            }
                        }
                        SoftwareParts.Add(new SoftwarePartUserViewModel
                        {
                            Id = source.SoftwareParts[j].Id,
                            SoftwareId = source.SoftwareParts[j].SoftwareId,
                            PartId = source.SoftwareParts[j].SoftwareId,
                            PartName = partName,
                            Count = source.SoftwareParts[j].Count
                        });
                    }
                }
                if (source.Softwares[i].Id == id)
                {
                    return new SoftwareUserViewModel
                    {
                        Id = source.Softwares[i].Id,
                        SoftwareName = source.Softwares[i].SoftwareName,
                        Price = source.Softwares[i].Cost,
                        SoftwarePart = SoftwareParts
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void DelPart(int id)
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
