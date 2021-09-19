using AutoLotDataAccessLayer.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDataAccessLayer.Models
{
    public partial class Order : EntityBase
    {
        [Column("customer_id")]
        public int CustomerId { get; set; }

        // ѕо соглашению, если инфраструктура EF находит свойство по имени CarId, то
        // оно будет примен€тьс€ в качестве внешнего ключа дл€ навигационного свойства типа Car.
        [Column("car_id")]
        public int CarId { get; set; }


        // Ќавигационные свойста.
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        // ≈сли нужно назначить свойству им€ отличное от CarId, тогда навигационное свойство
        // необходимо декорировать атрибутом [ForeignKey(nameof(CarId))].
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Inventory { get; set; }
    }
}
