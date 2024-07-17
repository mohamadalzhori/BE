﻿using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
