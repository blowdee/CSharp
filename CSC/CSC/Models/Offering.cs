using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Offering : IModel
    {
        public Offering()
        {
        }

        public string Name { get; set; }
        public int? Family { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Department> Department { get; set; }
        public virtual Family FamilyNavigation { get; set; }
    }
}
