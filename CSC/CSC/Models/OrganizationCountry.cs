using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class OrganizationCountry
    {
        public int OrganizationId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
