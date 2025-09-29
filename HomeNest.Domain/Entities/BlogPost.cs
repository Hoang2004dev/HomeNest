using HomeNest.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class BlogPost
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? ThumbnailUrl { get; set; }

    public int? AuthorId { get; set; }

    public string? Category { get; set; }

    public BlogStatus Status { get; set; } = BlogStatus.Draft;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User? Author { get; set; }
}
