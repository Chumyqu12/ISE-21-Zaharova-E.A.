using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwarePlace.LogicInterface
{
    public interface IDeveloperService
    {
        List<DeveloperUserViewModel> GetList();

        DeveloperUserViewModel GetPart(int id);

        void AddPart(DeveloperConnectingModel model);

        void UpdPart(DeveloperConnectingModel model);

        void DelPart(int id);
    }
}
