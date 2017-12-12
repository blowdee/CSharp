using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Family : IModel
    {
        public Family()
        {
        }

        public string Name { get; set; }
        public int? Business { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Offering> Offering { get; set; }
        public virtual Business BusinessNavigation { get; set; }
    }
}
