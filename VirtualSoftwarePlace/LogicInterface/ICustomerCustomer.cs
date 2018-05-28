using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftwarePlace.ConnectingModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface ICustomerCustomer
    {
        List<CustomerUserViewModel> GetList();

        CustomerUserViewModel GetPart(int id);

        void AddPart(CustomerConnectingModel model);

        void UpdPart(CustomerConnectingModel model);

        void DelPart(int id);
    }
}
