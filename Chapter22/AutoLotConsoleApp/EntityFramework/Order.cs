namespace AutoLotConsoleApp.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        // ѕо соглашению, если инфраструктура EF находит свойство по имени CarId, то
        // оно будет примен€тьс€ в качестве внешнего ключа дл€ навигационного свойства типа Car.
        [Column("car_id")]
        public int CarId { get; set; }

        
        // Ќавигационные свойста.
        public virtual Customer Customer { get; set; }

        // ≈сли нужно назначить свойству им€ отличное от CarId, тогда навигационное свойство
        // необходимо декорировать атрибутом [ForeignKey(nameof(CarId))].
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
    }
}
