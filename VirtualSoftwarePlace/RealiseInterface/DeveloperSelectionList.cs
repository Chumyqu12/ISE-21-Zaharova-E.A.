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
    public class DeveloperSelectionList : IDeveloperService
    {

        private BaseListSingleton source;

        public DeveloperSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<DeveloperUserViewModel> GetList()
        {
            List<DeveloperUserViewModel> result = new List<DeveloperUserViewModel>();
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                result.Add(new DeveloperUserViewModel
                {
                    Id = source.Developers[i].Id,
                    DeveloperFIO = source.Developers[i].DeveloperFIO
                });
            }
            return result;
        }

        public DeveloperUserViewModel GetPart(int id)
        {
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id == id)
                {
                    return new DeveloperUserViewModel
                    {
                        Id = source.Developers[i].Id,
                        DeveloperFIO = source.Developers[i].DeveloperFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddPart(DeveloperConnectingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id > maxId)
                {
                    maxId = source.Developers[i].Id;
                }
                if (source.Developers[i].DeveloperFIO == model.DeveloperFIO)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            source.Developers.Add(new Developer
            {
                Id = maxId + 1,
                DeveloperFIO = model.DeveloperFIO
            });
        }

        public void UpdPart(DeveloperConnectingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Developers[i].DeveloperFIO == model.DeveloperFIO &&
                    source.Developers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Developers[index].DeveloperFIO = model.DeveloperFIO;
        }

        public void DelPart(int id)
        {
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id == id)
                {
                    source.Developers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
