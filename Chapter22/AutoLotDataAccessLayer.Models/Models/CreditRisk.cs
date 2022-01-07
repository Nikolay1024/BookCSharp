using AutoLotDataAccessLayer.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDataAccessLayer.Models
{
    public partial class CreditRisk : EntityBase
    {
        [StringLength(50)]
        [Column("first_name")]
        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 2)]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("last_name")]
        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 1)]
        public string LastName { get; set; }
    }
}
