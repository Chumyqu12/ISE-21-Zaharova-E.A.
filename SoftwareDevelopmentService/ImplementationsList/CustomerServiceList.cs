using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;

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
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                result.Add(new CustomerViewModel
                {
                    Id = source.Customers[i].Id,
                    CustomerName = source.Customers[i].CustomerName
                });
            }
            return result;
        }

        public CustomerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    return new CustomerViewModel
                    {
                        Id = source.Customers[i].Id,
                        CustomerName = source.Customers[i].CustomerName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CustomerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
                if (source.Customers[i].CustomerName == model.CustomerName)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Customers.Add(new Customer {
                Id = maxId + 1,
                CustomerName = model.CustomerName
            });
        }

        public void UpdateElement(CustomerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Customers[i].CustomerName == model.CustomerName && 
                    source.Customers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Customers[index].CustomerName = model.CustomerName;
        }

        public void DeleteElement(int id)
        {
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    source.Customers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
