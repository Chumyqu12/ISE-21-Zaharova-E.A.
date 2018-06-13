using SoftwareDevelopmentService.Attributies;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.ViewModels;
using System.Collections.Generic;

namespace SoftwareDevelopmentService.Interfaces
{
    [CustomInterface("Интерфейс для работы с компонентами")]
    public interface IPartService
    {
        [CustomMethod("Метод получения списка компонент")]
        List<PartViewModel> GetList();
        [CustomMethod("Метод получения компонента по id")]
        PartViewModel GetElement(int id);
        [CustomMethod("Метод добавления компонента")]
        void AddElement(PartBindingModel model);
        [CustomMethod("Метод изменения данных по компоненту")]
        void UpdateElement(PartBindingModel model);
        [CustomMethod("Метод удаления компонента")]
        void DeleteElement(int id);
    }
}
