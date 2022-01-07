using AutoLotDataAccessLayer.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDataAccessLayer.Models
{
    public partial class Customer : EntityBase
    {
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"FirstName:{ FirstName }; LastName:{ LastName };";


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
