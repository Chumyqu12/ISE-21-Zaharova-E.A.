using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface IGeneralSelection
    {
        List<CustomerSelectionUserViewModel> GetList();

        void CreateOrder(CustomerSelectionModel model);

        void TakeOrderInWork(CustomerSelectionModel model);

        void FinishOrder(int id);

        void PayOrder(int id);

        void PutComponentOnStock(SoftwareWarehousePartConnectingModel model);
    }
}
