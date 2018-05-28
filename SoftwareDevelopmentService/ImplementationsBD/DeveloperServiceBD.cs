using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.ImplementationsBD
{
	public class DeveloperServiceBD: IDeveloperService
    {
        private SoftwareDbContext context;

        public DeveloperServiceBD(SoftwareDbContext context)
        {
            this.context = context;
        }

        public List<DeveloperViewModel> GetList()
        {
            List<DeveloperViewModel> result = context.Developers
                .Select(rec => new DeveloperViewModel
                {
                    Id = rec.Id,
                    DeveloperName = rec.DeveloperName
                })
                .ToList();
            return result;
        }

        public DeveloperViewModel GetElement(int id)
        {
            Developer element = context.Developers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new DeveloperViewModel
                {
                    Id = element.Id,
                    DeveloperName = element.DeveloperName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DeveloperBindingModel model)
        {
            Developer element = context.Developers.FirstOrDefault(rec => rec.DeveloperName == model.DeveloperName);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Developers.Add(new Developer
            {
                DeveloperName = model.DeveloperName
            });
            context.SaveChanges();
        }

        public void UpdateElement(DeveloperBindingModel model)
        {
            Developer element = context.Developers.FirstOrDefault(rec =>
                                        rec.DeveloperName == model.DeveloperName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Developers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DeveloperName = model.DeveloperName;
            context.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            Developer element = context.Developers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Developers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
