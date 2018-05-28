using SoftwareDevelopmentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService
{
    [Table("SoftwareDatabase")]
	public class SoftwareDbContext : DbContext
    {
         
        public SoftwareDbContext()
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<Offer> Offers { get; set; }

        public virtual DbSet<Software> Softwares { get; set; }

        public virtual DbSet<SoftwarePart> SoftwareParts { get; set; }

        public virtual DbSet<Warehouse> Warehouses { get; set; }

        public virtual DbSet<WarehousePart> WarehouseParts { get; set; }
    }
}

