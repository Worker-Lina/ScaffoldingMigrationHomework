using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationScaffoldingHomework
{
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
