namespace AutoLotDataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CreditRisk
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }
    }
}
