using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    public interface IDeveloperService
    {
        List<DeveloperViewModel> GetList();

        DeveloperViewModel GetElement(int id);
    
        void AddElement(DeveloperBindingModel model);

        void UpdateElement(DeveloperBindingModel model);

        void DeleteElement(int id);
    }
}
