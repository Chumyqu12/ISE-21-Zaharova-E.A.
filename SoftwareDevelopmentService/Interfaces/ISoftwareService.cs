using SoftwareDevelopmentService.Attributies;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    [CustomInterface("Интерфейс для работы с изделиями")]
    public interface ISoftwareService
    {
        [CustomMethod("Метод получения списка изделий")]
        List<SoftwareViewModel> GetList();
        [CustomMethod("Метод получения изделия по id")]
        SoftwareViewModel GetElement(int id);
        [CustomMethod("Метод добавления изделия")]
        void AddElement(SoftwareBindingModel model);
        [CustomMethod("Метод изменения данных по изделию")]
        void UpdateElement(SoftwareBindingModel model);
        [CustomMethod("Метод удаления изделия")]
        void DeleteElement(int id);
    }
}
