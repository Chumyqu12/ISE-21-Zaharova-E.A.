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
    public class CustomerSelectionList : ICustomerCustomer
    {
        private BaseListSingleton source;

        public CustomerSelectionList()
        {
            source = BaseListSingleton.GetInstance();
        }

        public List<CustomerUserViewModel> GetList()
        {
            List<CustomerUserViewModel> result = new List<CustomerUserViewModel>();
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                result.Add(new CustomerUserViewModel
                {
                    Id = source.Customers[i].Id,
                    CustomerFIO = source.Customers[i].CustomerFIO
                });
            }
            return result;
        }

        public CustomerUserViewModel GetPart(int id)
        {
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    return new CustomerUserViewModel
                    {
                        Id = source.Customers[i].Id,
                        CustomerFIO = source.Customers[i].CustomerFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddPart(CustomerConnectingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
                if (source.Customers[i].CustomerFIO == model.CustomerFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Customers.Add(new Customer
            {
                Id = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });
        }

        public void UpdPart(CustomerConnectingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Customers[i].CustomerFIO == model.CustomerFIO &&
                    source.Customers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Customers[index].CustomerFIO = model.CustomerFIO;
        }

        public void DelPart(int id)
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
