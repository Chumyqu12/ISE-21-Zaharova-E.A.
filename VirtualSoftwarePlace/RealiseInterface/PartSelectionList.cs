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
    public class PartSelectionList : IPartService
    {
        private BaseListSingleton source;

        public PartSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<PartUserViewModel> GetList()
        {
            List<PartUserViewModel> result = new List<PartUserViewModel>();
            for (int i = 0; i < source.Parts.Count; ++i)
            {
                result.Add(new PartUserViewModel
                {
                    Id = source.Parts[i].Id,
                    PartName = source.Parts[i].PartName
                });
            }
            return result;
        }

        public PartUserViewModel GetPart(int id)
        {
            for (int i = 0; i < source.Parts.Count; ++i)
            {
                if (source.Parts[i].Id == id)
                {
                    return new PartUserViewModel
                    {
                        Id = source.Parts[i].Id,
                        PartName = source.Parts[i].PartName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddPart(PartConnectingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Parts.Count; ++i)
            {
                if (source.Parts[i].Id > maxId)
                {
                    maxId = source.Parts[i].Id;
                }
                if (source.Parts[i].PartName == model.PartName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            source.Parts.Add(new Part
            {
                Id = maxId + 1,
                PartName = model.PartName
            });
        }

        public void UpdPart(PartConnectingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Parts.Count; ++i)
            {
                if (source.Parts[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Parts[i].PartName == model.PartName &&
                    source.Parts[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Parts[index].PartName = model.PartName;
        }

        public void DelPart(int id)
        {
            for (int i = 0; i < source.Parts.Count; ++i)
            {
                if (source.Parts[i].Id == id)
                {
                    source.Parts.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
