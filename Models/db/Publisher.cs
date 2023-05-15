using System;
using System.Collections.Generic;

namespace WebAppBookShop.Models.db
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int PublishId { get; set; }
        public string? PublishName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
