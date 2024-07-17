﻿using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int? AuthorId { get; set; }

    public string Isbn { get; set; } = null!;

    public int PublishedYear { get; set; }

    public int Quantity { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
