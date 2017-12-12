using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Country : IModel
    {
        public Country()
        {
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Business> Business { get; set; }
        public virtual ICollection<OrganizationCountry> Organizations { get; set; }
    }
}
