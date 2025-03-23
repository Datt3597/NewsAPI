using System;
using System.Collections.Generic;

namespace NewsPortalAPI.Models;

public partial class NewsArticle
{
    public int Id { get; set; }

    public string Section { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Byline { get; set; }

    public DateTime PublishedDate { get; set; }
}
