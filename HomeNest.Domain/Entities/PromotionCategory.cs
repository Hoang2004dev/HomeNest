using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class PromotionCategory
{
    public int Id { get; set; }

    public int? PromotionId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
