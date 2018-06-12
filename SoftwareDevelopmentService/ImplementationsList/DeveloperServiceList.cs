using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
			List<DeveloperViewModel> result = source.Developers
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
			Developer element = source.Developers.FirstOrDefault(rec => rec.Id == id);
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
			Developer element = source.Developers.FirstOrDefault(rec => rec.DeveloperName == model.DeveloperName);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			int maxId = source.Developers.Count > 0 ? source.Developers.Max(rec => rec.Id) : 0;
			source.Developers.Add(new Developer
			{
				Id = maxId + 1,
				DeveloperName = model.DeveloperName
			});
		}

		public void UpdateElement(DeveloperBindingModel model)
		{
			Developer element = source.Developers.FirstOrDefault(rec =>
										rec.DeveloperName == model.DeveloperName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			element = source.Developers.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.DeveloperName = model.DeveloperName;
			element = source.Developers.FirstOrDefault(rec =>
										rec.DeveloperName == model.DeveloperName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			element = source.Developers.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.DeveloperName = model.DeveloperName;

		}

		public void DeleteElement(int id)
		{
			Developer element = source.Developers.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				source.Developers.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	}
}
