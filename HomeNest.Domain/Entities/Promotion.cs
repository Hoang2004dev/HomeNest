using HomeNest.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class Promotion
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DiscountType DiscountType { get; set; }

    public decimal DiscountValue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public PromotionStatus Status { get; set; } = PromotionStatus.Active;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PromotionCategory> PromotionCategories { get; set; } = new List<PromotionCategory>();

    public virtual ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();
}
