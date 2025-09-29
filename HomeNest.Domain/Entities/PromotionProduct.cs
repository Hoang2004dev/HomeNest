using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class PromotionProduct
{
    public int Id { get; set; }

    public int? PromotionId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
