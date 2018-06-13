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
	public class WarehouseServiceBD:IWarehouseService
    {
        private SoftwareDbContext context;

        public WarehouseServiceBD(SoftwareDbContext context)
        {
            this.context = context;
        }

        public List<WarehouseViewModel> GetList()
        {
            List<WarehouseViewModel> result = context.Warehouses
                .Select(rec => new WarehouseViewModel
                {
                    Id = rec.Id,
                    WarehouseName = rec.WarehouseName,
                    WarehouseParts = context.WarehouseParts
                            .Where(recPC => recPC.WarehouseId == rec.Id)
                            .Select(recPC => new WarehousePartViewModel
                            {
                                Id = recPC.Id,
                                WarehouseId = recPC.WarehouseId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                Number = recPC.Number
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public WarehouseViewModel GetElement(int id)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new WarehouseViewModel
                {
                    Id = element.Id,
                    WarehouseName = element.WarehouseName,
                    WarehouseParts = context.WarehouseParts
                            .Where(recPC => recPC.WarehouseId == element.Id)
                            .Select(recPC => new WarehousePartViewModel
                            {
                                Id = recPC.Id,
                                WarehouseId = recPC.WarehouseId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                Number = recPC.Number
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(WarehouseBindingModel model)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            context.Warehouses.Add(new Warehouse
            {
                WarehouseName = model.WarehouseName
            });
            context.SaveChanges();
        }

        public void UpdateElement(WarehouseBindingModel model)
        {
            Warehouse element = context.Warehouses.FirstOrDefault(rec =>
                                        rec.WarehouseName == model.WarehouseName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.WarehouseName = model.WarehouseName;
            context.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // при удалении удаляем все записи о компонентах на удаляемом складе
                        context.WarehouseParts.RemoveRange(
                                            context.WarehouseParts.Where(rec => rec.WarehouseId == id));
                        context.Warehouses.Remove(element);
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
