using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface ISoftwareWarehouseService
    {
        List<SoftwareWarehouseUserViewModel> GetList();

        SoftwareWarehouseUserViewModel GetPart(int id);

        void AddPart(SoftwareWarehouseConnectingModel model);

        void UpdPart(SoftwareWarehouseConnectingModel model);

        void DelPart(int id);
    }
}
