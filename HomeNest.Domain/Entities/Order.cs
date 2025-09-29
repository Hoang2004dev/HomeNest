using HomeNest.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cod;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public string? ShippingAddress { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }

    public virtual ICollection<VoucherUsage> VoucherUsages { get; set; } = new List<VoucherUsage>();
}
