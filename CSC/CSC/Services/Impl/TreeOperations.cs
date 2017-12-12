using CSC.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC
{
    public class TreeOperations : ITreeOperation
    {
        private CSCContext _dbcontext;
        private readonly ILogger _logger;

        public TreeOperations(ILoggerFactory logger, CSCContext context)
        {
            _logger = logger.CreateLogger("TreeOperations.Logger");
            _dbcontext = context;
        }

        public IEnumerable<string> BuildTree()
        {
            var organizations = from org in _dbcontext.Organization
                                join oc in _dbcontext.OrganizationCountry on org.Id equals oc.OrganizationId
                                join con in _dbcontext.Country on oc.CountryId equals con.Id
                                select new { org.Id, org.Name, org.Type, org.Code, oc.CountryId };

            try
            {
                foreach (var org in organizations)
                {
                    ItemTree.Instance.Organizations[org.Id] = new Organization
                    {
                        Id = org.Id,
                        Name = org.Name,
                        Type = org?.Type,
                        Code = org?.Code
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var countries = from country in _dbcontext.Country
                            join oc in _dbcontext.OrganizationCountry on country.Id equals oc.CountryId
                            join org in _dbcontext.Organization on oc.OrganizationId equals org.Id
                            select new { country.Id, country.Name, country.Code, oc.OrganizationId };

            try
            {
                foreach (var con in countries)
                {
                    ItemTree.Instance.Countries[con.Id] = new Country
                    {
                        Id = con.Id,
                        Name = con.Name,
                        Code = con.Code,
                        Organizations = new List<OrganizationCountry>()
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var businesses = from business in _dbcontext.Business
                             select new { business.Id, business.Name, business.Country };

            try
            {
                foreach (var bus in businesses)
                {
                    ItemTree.Instance.Businesses[bus.Id] = new Business
                    {
                        Id = bus.Id,
                        Name = bus.Name,
                        Country = bus.Country
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var families = from family in _dbcontext.Family
                           select new { family.Id, family.Name, family.Business };

            try
            {
                foreach (var fam in families)
                {
                    ItemTree.Instance.Families[fam.Id] = new Family
                    {
                        Id = fam.Id,
                        Name = fam.Name,
                        Business = fam.Business
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var offerings = from offer in _dbcontext.Offering
                            select new { offer.Id, offer.Name, offer.Family };

            try
            {
                foreach (var off in offerings)
                {
                    ItemTree.Instance.Offerings[off.Id] = new Offering
                    {
                        Id = off.Id,
                        Name = off.Name,
                        Family = off.Family
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var departments = from department in _dbcontext.Department
                              select new { department.Id, department.Name, department.Offering };

            try
            {
                foreach (var dep in departments)
                {
                    ItemTree.Instance.Departments[dep.Id] = new Department
                    {
                        Id = dep.Id,
                        Name = dep.Name,
                        Offering = dep.Offering
                    };
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            List<string> output = new List<string>();
            try
            {
                output.Add(JsonConvert.SerializeObject(organizations));
                output.Add(JsonConvert.SerializeObject(countries));
                output.Add(JsonConvert.SerializeObject(businesses));
                output.Add(JsonConvert.SerializeObject(families));
                output.Add(JsonConvert.SerializeObject(offerings));
                output.Add(JsonConvert.SerializeObject(departments));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return output;
        }

        public IModel GetItem(int level, int id)
        {
            if (level == 1)
                return ItemTree.Instance.Organizations[id];
            if (level == 2)
                return ItemTree.Instance.Countries[id];
            if (level == 3)
                return ItemTree.Instance.Businesses[id];
            if (level == 4)
                return ItemTree.Instance.Families[id];
            if (level == 5)
                return ItemTree.Instance.Offerings[id];
            if (level == 6)
                return ItemTree.Instance.Departments[id];
            _logger.LogError($"Item at level {level} with id {id} not found");
            return null;
        }

        public bool AddItem(int level, string value)
        {
            var item = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);

            if (Validate(level, item["Name"]) == false)
            {
                _logger.LogError($"Item with name {item["Name"]} already exists at level {level}");
                return false;
            }
            if (level == 1)
            {
                var newItem = new Organization
                {
                    Name = item["Name"],
                    Code = item["Code"],
                    Type = item["Type"].Length > 0 ? Int32.Parse(item["Type"]) : 0
                };

                _dbcontext.Organization.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Organizations[id] = newItem;
            }
            if (level == 2)
            {
                var newItem = new Country
                {
                    Name = item["Name"],
                    Code = item["Code"]
                };

                _dbcontext.Country.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Countries[id] = newItem;
            }
            if (level == 3)
            {
                var newItem = new Business
                {
                    Name = item["Name"],
                    Country = item["Country"].Length > 0 ? Int32.Parse(item["Country"]) : 0
                };

                _dbcontext.Business.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Businesses[id] = newItem;
            }
            if (level == 4)
            {
                var newItem = new Family
                {
                    Name = item["Name"],
                    Business = item["Business"].Length > 0 ? Int32.Parse(item["Business"]) : 0
                };

                _dbcontext.Family.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Families[id] = newItem;
            }
            if (level == 5)
            {
                var newItem = new Offering
                {
                    Name = item["Name"],
                    Family = item["Family"].Length > 0 ? Int32.Parse(item["Family"]) : 0
                };

                _dbcontext.Offering.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Offerings[id] = newItem;
            }
            if (level == 6)
            {
                var newItem = new Department
                {
                    Name = item["Name"],
                    Offering = item["Offering"].Length > 0 ? Int32.Parse(item["Offering"]) : 0
                };

                _dbcontext.Department.Add(newItem);
                _dbcontext.SaveChanges();

                var id = newItem.Id;

                ItemTree.Instance.Departments[id] = newItem;
            }
            _logger.LogInformation($"Item with name {item["Name"]} successfully added to level {level}");
            return true;
        }

        public bool EditItem(int level, int id, string newValue)
        {
            var item = JsonConvert.DeserializeObject<Dictionary<string, string>>(newValue);

            if (Validate(level, item["Name"]) == false)
            {
                _logger.LogError($"Item with name {item["Name"]} already exists at level {level}. Can't edit");
                return false;
            }

            if (level == 1)
            {
                var newItem = new Organization
                {
                    Name = item["Name"],
                    Code = item["Code"],
                    Type = item["Type"].Length > 0 ? Int32.Parse(item["Type"]) : 0
                };

                _dbcontext.Organization.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Organizations[itemId] = newItem;
            }
            if (level == 2)
            {
                var newItem = new Country
                {
                    Name = item["Name"],
                    Code = item["Code"]
                };

                _dbcontext.Country.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Countries[itemId] = newItem;
            }
            if (level == 3)
            {
                var newItem = new Business
                {
                    Name = item["Name"],
                    Country = item["Country"].Length > 0 ? Int32.Parse(item["Type"]) : 0
                };

                _dbcontext.Business.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Businesses[itemId] = newItem;
            }
            if (level == 4)
            {
                var newItem = new Family
                {
                    Name = item["Name"],
                    Business = item["Business"].Length > 0 ? Int32.Parse(item["Business"]) : 0
                };

                _dbcontext.Family.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Families[itemId] = newItem;
            }
            if (level == 5)
            {
                var newItem = new Offering
                {
                    Name = item["Name"],
                    Family = item["Family"].Length > 0 ? Int32.Parse(item["Family"]) : 0
                };

                _dbcontext.Offering.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Offerings[itemId] = newItem;
            }
            if (level == 6)
            {
                var newItem = new Department
                {
                    Name = item["Name"],
                    Offering = item["Offering"].Length > 0 ? Int32.Parse(item["Offering"]) : 0
                };

                _dbcontext.Department.Update(newItem);

                var itemId = newItem.Id;
                ItemTree.Instance.Departments[itemId] = newItem;
            }
            _logger.LogInformation($"Item successfully edited on level {level} with id {id}");
            return true;
        }

        public bool DeleteItem(int level, int id)
        {
            if (level == 1)
            {
                var item = (Organization)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Organization.Remove(item);
            }
            if (level == 2)
            {
                var item = (Country)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Country.Remove(item);
            }
            if (level == 3)
            {
                var item = (Business)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Business.Remove(item);
            }
            if (level == 4)
            {
                var item = (Family)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Family.Remove(item);
            }
            if (level == 5)
            {
                var item = (Offering)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Offering.Remove(item);
            }
            if (level == 6)
            {
                var item = (Department)GetItem(level, id);
                if (item == null)
                {
                    return false;
                }
                _dbcontext.Department.Remove(item);
            }
            _dbcontext.SaveChanges();
            _logger.LogInformation($"Item at level {level} with id {id} successfully deleted");
            return true;
        }

        private bool Validate(int level, string name)
        {
            if (level == 1)
            {
                foreach (var item in ItemTree.Instance.Organizations.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }
            }
            if (level == 2)
            {
                foreach (var item in ItemTree.Instance.Countries.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }
            }
            if (level == 3)
            {
                foreach (var item in ItemTree.Instance.Businesses.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }
            }
            if (level == 4)
            {
                foreach (var item in ItemTree.Instance.Families.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }
            }
            if (level == 5)
            {
                foreach (var item in ItemTree.Instance.Offerings.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }

            }
            if (level == 6)
            {
                foreach (var item in ItemTree.Instance.Departments.Values)
                {
                    if (item.Name.Equals(name))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
