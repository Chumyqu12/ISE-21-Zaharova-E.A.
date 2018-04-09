using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    public interface ISoftwareService
    {
        List<SoftwareViewModel> GetList();

        SoftwareViewModel GetElement(int id);

        void AddElement(SoftwareBindingModel model);

        void UpdateElement(SoftwareBindingModel model);

        void DeleteElement(int id);
    }
}
