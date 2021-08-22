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

        // �� ����������, ���� �������������� EF ������� �������� �� ����� CarId, ��
        // ��� ����� ����������� � �������� �������� ����� ��� �������������� �������� ���� Car.
        [Column("car_id")]
        public int CarId { get; set; }

        
        // ������������� �������.
        public virtual Customer Customer { get; set; }

        // ���� ����� ��������� �������� ��� �������� �� CarId, ����� ������������� ��������
        // ���������� ������������ ��������� [ForeignKey(nameof(CarId))].
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
    }
}
