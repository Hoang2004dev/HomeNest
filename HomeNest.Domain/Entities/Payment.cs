using HomeNest.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public decimal Amount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    public DateTime? CreatedAt { get; set; }

    public virtual Order? Order { get; set; }
}
