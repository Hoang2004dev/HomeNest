using HomeNest.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class Voucher
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public DiscountType DiscountType { get; set; }

    public decimal DiscountValue { get; set; }

    public decimal? MinOrderValue { get; set; }

    public decimal? MaxDiscount { get; set; }

    public int? UsageLimit { get; set; }

    public int? UsedCount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public VoucherStatus Status { get; set; } = VoucherStatus.Active;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<VoucherUsage> VoucherUsages { get; set; } = new List<VoucherUsage>();
}
