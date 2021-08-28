using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDataAccessLayer.Models
{
    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        [Column("car_id")]
        public int CarId { get; set; }

        [Column("make")]
        [StringLength(50)]
        public string Make { get; set; }

        [Column("color")]
        [StringLength(50)]
        public string Color { get; set; }

        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public string MakeColor => $"Make:{ Make }; Color:{ Color };";


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
