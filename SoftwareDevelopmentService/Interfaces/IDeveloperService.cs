using SoftwareDevelopmentService.Attributies;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    [CustomInterface("Интерфейс для работы с работниками")]
    public interface IDeveloperService
    {
        [CustomMethod("Метод получения списка работников")]
        List<DeveloperViewModel> GetList();
        [CustomMethod("Метод получения работника по id")]
        DeveloperViewModel GetElement(int id);
        [CustomMethod("Метод добавления работника")]
        void AddElement(DeveloperBindingModel model);
        [CustomMethod("Метод изменения данных по работнику")]
        void UpdateElement(DeveloperBindingModel model);
        [CustomMethod("Метод удаления работника")]
        void DeleteElement(int id);
    }
}
