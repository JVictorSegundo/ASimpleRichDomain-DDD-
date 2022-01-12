using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using I_LeagueStore.Domain.Validation;

namespace I_LeagueStore.Domain.Entities
{
    public class Category : CommonAttributes
    {
        public IEnumerable<Item> Item { get; set; }
        //---

        public Category(string name)
        {
            Validate(name);
        }
        //---

        public void Update(string name)
        {
            Validate(name);
        }
        //---

        //-----------------------------------------------------------[ Validations ]-----------------------------------------------------------\\
        private void Validate(string name)
        {
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(name), "Invalid name. Name is required!");
            DomainValidation.DomainExceptions(string.IsNullOrWhiteSpace(name), "Invalid name. The category name can't be left blank!");
            DomainValidation.DomainExceptions(name.Length > 20, "Invalid name. The category name is too long! [over 20 characters]");
            DomainValidation.DomainExceptions(regx.IsMatch(name), "Invalid name. The category name can't contain special characters!");
            Name = name;
        }
    }
}
