using AutoLotDataAccessLayer.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDataAccessLayer.Models
{
    public partial class Order : EntityBase
    {
        [Column("customer_id")]
        public int CustomerId { get; set; }

        // �� ����������, ���� �������������� EF ������� �������� �� ����� CarId, ��
        // ��� ����� ����������� � �������� �������� ����� ��� �������������� �������� ���� Car.
        [Column("car_id")]
        public int CarId { get; set; }


        // ������������� �������.
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        // ���� ����� ��������� �������� ��� �������� �� CarId, ����� ������������� ��������
        // ���������� ������������ ��������� [ForeignKey(nameof(CarId))].
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Inventory { get; set; }
    }
}
