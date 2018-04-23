using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class DeveloperServiceList : IDeveloperService
    {
        private DataListSingleton source;

        public DeveloperServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<DeveloperViewModel> GetList()
        {
            List<DeveloperViewModel> result = new List<DeveloperViewModel>();
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                result.Add(new DeveloperViewModel
                {
                    Id = source.Developers[i].Id,
                    DeveloperName = source.Developers[i].DeveloperName
                });
            }
            return result;
        }

        public DeveloperViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id == id)
                {
                    return new DeveloperViewModel
                    {
                        Id = source.Developers[i].Id,
                        DeveloperName = source.Developers[i].DeveloperName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DeveloperBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id > maxId)
                {
                    maxId = source.Developers[i].Id;
                }
                if (source.Developers[i].DeveloperName == model.DeveloperName)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            source.Developers.Add(new Developer
            {
                Id = maxId + 1,
                DeveloperName = model.DeveloperName
            });
        }

        public void UpdateElement(DeveloperBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Developers.Count; ++i)
            {
                if (source.Developers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Developers[i].DeveloperName == model.DeveloperName && 
                    source.Developers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Developers[index].DeveloperName = model.DeveloperName;
        }

        public void DeleteElement(int id)
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
