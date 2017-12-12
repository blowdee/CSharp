using System;
using System.Collections.Generic;

namespace CSC.Models
{
    public partial class Business : IModel
    {
        public Business()
        {
        }

        public string Name { get; set; }
        public int? Country { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Family> Family { get; set; }
        public virtual Country CountryNavigation { get; set; }
    }
}
