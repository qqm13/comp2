using System;
using System.Collections.Generic;

namespace comp2;

public partial class KnowledgeArticle
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? Tags { get; set; }

    public bool IsPublished { get; set; }

    public int ViewCount { get; set; }

    public string? AuthorSid { get; set; }

    public DateTime PublishedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Client? AuthorS { get; set; }
}
