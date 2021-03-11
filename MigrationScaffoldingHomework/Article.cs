using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationScaffoldingHomework
{
    public partial class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountOfPage { get; set; }

        public Guid? CategoryId { get; set; }
        public Guid? AuthorsId { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Category Category { get; set; }
    }
}
