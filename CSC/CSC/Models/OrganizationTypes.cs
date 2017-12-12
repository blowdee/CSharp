using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class OrganizationTypes
    {
        public OrganizationTypes()
        {
            Organization = new HashSet<Organization>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
