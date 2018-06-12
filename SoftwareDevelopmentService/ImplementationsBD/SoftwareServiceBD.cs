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
    class SoftwareServiceBD : ISoftwareService
    {
        private SoftwareDbContext context;

        public SoftwareServiceBD(SoftwareDbContext context)
        {
            this.context = context;
        }

        public List<SoftwareViewModel> GetList()
        {
            List<SoftwareViewModel> result = context.Softwares
                .Select(rec => new SoftwareViewModel
                {
                    Id = rec.Id,
                    SoftwareName = rec.SoftwareName,
                    Cost = rec.Cost,
                    SoftwareParts = context.SoftwareParts
                            .Where(recPC => recPC.SoftwareId == rec.Id)
                            .Select(recPC => new SoftwarePartViewModel
                            {
                                Id = recPC.Id,
                                SoftwareId = recPC.SoftwareId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                Number = recPC.Number
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public SoftwareViewModel GetElement(int id)
        {
            Software element = context.Softwares.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SoftwareViewModel
                {
                    Id = element.Id,
                    SoftwareName = element.SoftwareName,
                    Cost = element.Cost,
                    SoftwareParts = context.SoftwareParts
                            .Where(recPC => recPC.SoftwareId == element.Id)
                            .Select(recPC => new SoftwarePartViewModel
                            {
                                Id = recPC.Id,
                                SoftwareId = recPC.SoftwareId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                Number = recPC.Number
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SoftwareBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Software element = context.Softwares.FirstOrDefault(rec => rec.SoftwareName == model.SoftwareName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Software
                    {
                        SoftwareName = model.SoftwareName,
                        Cost = model.Cost
                    };
                    context.Softwares.Add(element);
                    context.SaveChanges();
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
                        context.SoftwareParts.Add(new SoftwarePart
                        {
                            SoftwareId = element.Id,
                            PartId = groupPart.PartId,
                            Number = groupPart.Number
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdateElement(SoftwareBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Software element = context.Softwares.FirstOrDefault(rec =>
                                        rec.SoftwareName == model.SoftwareName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Softwares.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.SoftwareName = model.SoftwareName;
                    element.Cost = model.Cost;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты
                    var compIds = model.SoftwareParts.Select(rec => rec.PartId).Distinct();
                    var updateParts = context.SoftwareParts
                                                    .Where(rec => rec.SoftwareId == model.Id &&
                                                        compIds.Contains(rec.PartId));
                    foreach (var updatePart in updateParts)
                    {
                        updatePart.Number = model.SoftwareParts
                                                        .FirstOrDefault(rec => rec.Id == updatePart.Id).Number;
                    }
                    context.SaveChanges();
                    context.SoftwareParts.RemoveRange(
                                        context.SoftwareParts.Where(rec => rec.SoftwareId == model.Id &&
                                                                            !compIds.Contains(rec.PartId)));
                    context.SaveChanges();
                    // новые записи
                    var groupParts = model.SoftwareParts
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.PartId)
                                                .Select(rec => new
                                                {
                                                    PartId = rec.Key,
                                                    Number = rec.Sum(r => r.Number)
                                                });
                    foreach (var groupPart in groupParts)
                    {
                        SoftwarePart elementPC = context.SoftwareParts
                                                .FirstOrDefault(rec => rec.SoftwareId == model.Id &&
                                                                rec.PartId == groupPart.PartId);
                        if (elementPC != null)
                        {
                            elementPC.Number += groupPart.Number;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.SoftwareParts.Add(new SoftwarePart
                            {
                                SoftwareId = model.Id,
                                PartId = groupPart.PartId,
                                Number = groupPart.Number
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Software element = context.Softwares.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.SoftwareParts.RemoveRange(
                                            context.SoftwareParts.Where(rec => rec.SoftwareId == id));
                        context.Softwares.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}

