﻿using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class PartServiceList : IPartService
    {
        private DataListSingleton source;

        public PartServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<PartViewModel> GetList()
        {
			List<PartViewModel> result = new List<PartViewModel>(from Part in source.Parts
																 select new PartViewModel
				/*source.Parts
				 .Select(rec => new PartViewModel*/
				 {
					 Id = Part.Id,
					 PartName = Part.PartName
				 })
				 .ToList();
			return result;
		}

        public PartViewModel GetElement(int id)
        {
			Part element = source.Parts.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				return new PartViewModel
				{
					Id = element.Id,
					PartName = element.PartName
				};
			}
			throw new Exception("Элемент не найден");
		}

        public void AddElement(PartBindingModel model)
        {
			Part element = source.Parts.FirstOrDefault(rec => rec.PartName == model.PartName);
			if (element != null)
			{
				throw new Exception("Уже есть компонент с таким названием");
			}
			int maxId = source.Parts.Count > 0 ? source.Parts.Max(rec => rec.Id) : 0;
			source.Parts.Add(new Part
			{
				Id = maxId + 1,
				PartName = model.PartName
			});
		}

        public void UpdateElement(PartBindingModel model)
        {
			Part element = source.Parts.FirstOrDefault(rec =>
										 rec.PartName == model.PartName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть компонент с таким названием");
			}
			element = source.Parts.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.PartName = model.PartName;
		}

        public void DeleteElement(int id)
        {
			Part element = source.Parts.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				source.Parts.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
    }
}
