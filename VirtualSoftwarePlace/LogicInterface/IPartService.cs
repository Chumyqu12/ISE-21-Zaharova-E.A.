using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface IPartService
    {
        List<PartUserViewModel> GetList();

        PartUserViewModel GetPart(int id);

        void AddPart(PartConnectingModel model);

        void UpdPart(PartConnectingModel model);

        void DelPart(int id);
    }
}
