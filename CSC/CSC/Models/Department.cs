using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Department : IModel
    {
        public string Name { get; set; }
        public int? Offering { get; set; }
        public int Id { get; set; }

        public virtual Offering OfferingNavigation { get; set; }
    }
}
