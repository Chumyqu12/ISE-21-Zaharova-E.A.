using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
			List<SoftwareViewModel> result = source.Softwares.Select(rec => new SoftwareViewModel
			{
				// требуется дополнительно получить список компонентов для изделия и их количество

				Id = rec.Id,
				SoftwareName = rec.SoftwareName,
				Cost = rec.Cost,
				SoftwareParts = source.SoftwareParts
							.Where(recPC => recPC.SoftwareId == rec.Id)
							.Select(recPC => new SoftwarePartViewModel
							{
								Id = recPC.Id,
								SoftwareId = recPC.SoftwareId,
								PartId = recPC.PartId,
								PartName = source.Parts
								.FirstOrDefault(recC => recC.Id == recPC.PartId)?.PartName,
								Number = recPC.Number

							})
.ToList()
			})
			.ToList();
			return result;
		}

		public SoftwareViewModel GetElement(int id)
		{
			Software element = source.Softwares.FirstOrDefault(rec => rec.Id == id);
			if (element!=null)
			{
				return new SoftwareViewModel
				{
					Id = element.Id,
					SoftwareName = element.SoftwareName,
					Cost=element.Cost,
					SoftwareParts=source.SoftwareParts
					.Where(recPC=>recPC.SoftwareId==element.Id)
					.Select(recPC=>new SoftwarePartViewModel
					{ 
						Id=recPC.Id,
						SoftwareId=recPC.PartId,
						PartName=source.Parts
						.FirstOrDefault(recC=>recC.Id==recPC.PartId)?.PartName,
						Number=recPC.Number
		})
			.ToList()
		};
	}
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SoftwareBindingModel model)
        {
			Software element = source.Softwares.FirstOrDefault(rec => rec.SoftwareName == model.SoftwareName);
			if (element != null) {
				throw new Exception("Уже есть изделие с таким названием");
			}
			int maxId = source.Softwares.Count>0?source.Softwares.Max(rec=>rec.Id):0;
			source.Softwares.Add(new Software
           
            {
                Id = maxId + 1,
                SoftwareName = model.SoftwareName,
                Cost = model.Cost
            });
			// компоненты для изделия
			int maxPCId = source.SoftwareParts.Count > 0 ?
				source.SoftwareParts.Max(rec => rec.Id) : 0;
			// убираем дубли по компонентам
			var groupParts = model.SoftwareParts
				 .GroupBy(rec => rec.PartId)
				 .Select(rec => new
				 {
					 PartId = rec.Key,
					 Number = rec.Sum(r => r.Number)
				 });
            // добавляем компоненты
           foreach (var groupPart in groupParts)
            {
                source.SoftwareParts.Add(new SoftwarePart
                {
                    Id = ++maxPCId,
                    SoftwareId = maxId + 1,
                    PartId = groupPart.PartId,
                    Number = groupPart.Number
                });
            }
        }

        public void UpdateElement(SoftwareBindingModel model)
        {
			Software element = source.Softwares.FirstOrDefault(rec =>
										 rec.SoftwareName == model.SoftwareName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть изделие с таким названием");
			}
			element = source.Softwares.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.SoftwareName = model.SoftwareName;
			element.Cost = model.Cost;

			int maxPCId = source.SoftwareParts.Count > 0 ? source.SoftwareParts.Max(rec => rec.Id) : 0;
			// обновляем существуюущие компоненты
			var compIds = model.SoftwareParts.Select(rec => rec.PartId).Distinct();
			var updateParts = source.SoftwareParts
											.Where(rec => rec.SoftwareId == model.Id &&
										   compIds.Contains(rec.PartId));
			foreach (var updatePart in updateParts)
			{
				updatePart.Number = model.SoftwareParts
												.FirstOrDefault(rec => rec.Id == updatePart.Id).Number;
			}
			source.SoftwareParts.RemoveAll(rec => rec.SoftwareId == model.Id &&
									   !compIds.Contains(rec.PartId));
			// новые записи
			var groupParts = model.SoftwareParts
										.Where(rec => rec.Id == 0)
										.GroupBy(rec => rec.PartId)
										.Select(rec => new
										{
											PartId = rec.Key,
											Count = rec.Sum(r => r.Number)
										});
			foreach (var groupPart in groupParts)
			{
				SoftwarePart elementPC = source.SoftwareParts
										.FirstOrDefault(rec => rec.SoftwareId == model.Id &&
														rec.PartId == groupPart.PartId);
				if (elementPC != null)
				{
					elementPC.Number += groupPart.Count;
				}
				else
				{
					source.SoftwareParts.Add(new SoftwarePart
					{
						Id = ++maxPCId,
						SoftwareId = model.Id,
						PartId = groupPart.PartId,
						Number = groupPart.Count
					});
				}
			}
		}

		public void DeleteElement(int id)
        {
			Software element = source.Softwares.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				// удаяем записи по компонентам при удалении изделия
				source.SoftwareParts.RemoveAll(rec => rec.SoftwareId == id);
				source.Softwares.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	

    }
}
