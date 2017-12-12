using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Organization : IModel
    {
        public Organization()
        {
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? Type { get; set; }
        public int Id { get; set; }

        public virtual ICollection<OrganizationCountry> Countries { get; set; }
        public virtual OrganizationTypes TypeNavigation { get; set; }
    }
}
