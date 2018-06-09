using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface ISoftwareService
    {
        List<SoftwareUserViewModel> GetList();

        SoftwareUserViewModel GetPart(int id);

        void AddPart(SoftwareConnectingModel model);

        void UpdPart(SoftwareConnectingModel model);

        void DelPart(int id);
    }
}
