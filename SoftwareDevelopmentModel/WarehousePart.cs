﻿namespace SoftwareDevelopmentModel
{
    /// <summary>
    /// Сколько компонентов хранится на складе
    /// </summary>
    public class WarehousePart
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int PartId { get; set; }

        public int Number { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Part Part { get; set; }
    }
}
