using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDevelopmentService.ImplementationsList
{
    public class CustomerServiceList : ICustomerService
    {
        private DataListSingleton source;

        public CustomerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CustomerViewModel> GetList()
        {
			List<CustomerViewModel> result = source.Customers.Select(rec => new CustomerViewModel
			{
				Id = rec.Id,
				CustomerName = rec.CustomerName
			})
				.ToList();
		
            return result;
        }

        public CustomerViewModel GetElement(int id)
        {
			Customer element = source.Customers.FirstOrDefault(rec => rec.Id == id);
			if (element != null) {
				return new CustomerViewModel
				{
					Id = element.Id,
					CustomerName = element.CustomerName
				};
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CustomerBindingModel model)
        {
			Customer element = source.Customers.FirstOrDefault(rec => rec.CustomerName == model.CustomerName);
			if (element!=null)
			    { 
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
			int maxId = source.Customers.Count > 0 ? source.Customers.Max(rec => rec.Id) : 0;
			source.Customers.Add(new Customer
			{ 
           
                Id = maxId + 1,
                CustomerName = model.CustomerName
            });
        }

        public void UpdateElement(CustomerBindingModel model)
        {
			Customer element = source.Customers.FirstOrDefault(rec =>
			  rec.CustomerName==model.CustomerName && rec.Id != model.Id);
           
                if (element != null)
                {
				throw new Exception("Уже есть клиент с таким ФИО");
			    }
			element = source.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
          element.CustomerName=model.CustomerName;
        }

        public void DeleteElement(int id)
        {
			Customer element = source.Customers.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				source.Customers.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
        }
    }
}
