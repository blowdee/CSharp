using CSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC
{
    public class ItemTree
    {
        private static ItemTree instance;

        private ItemTree() { }

        public static ItemTree Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemTree();
                    instance.Organizations = new Dictionary<int, Organization>();
                    instance.Countries = new Dictionary<int, Country>();
                    instance.Businesses = new Dictionary<int, Business>();
                    instance.Families = new Dictionary<int, Family>();
                    instance.Offerings = new Dictionary<int, Offering>();
                    instance.Departments = new Dictionary<int, Department>();
                }
                return instance;
            }
        }

        public Dictionary<int, Organization> Organizations { get; set; }
        public Dictionary<int, Country> Countries { get; set; }
        public Dictionary<int, Business> Businesses { get; set; }
        public Dictionary<int, Family> Families { get; set; }
        public Dictionary<int, Offering> Offerings { get; set; }
        public Dictionary<int, Department> Departments { get; set; }
    }
}
