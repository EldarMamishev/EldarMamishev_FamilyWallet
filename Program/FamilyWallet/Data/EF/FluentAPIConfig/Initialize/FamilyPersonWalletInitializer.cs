using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;

namespace Data.EF.FluentAPIConfig.Initialize
{
    public class FamilyPersonWalletInitializer
    {
        public void Initialize()
        {
            using (FamilyWalletContext context = new FamilyWalletContext())
            {
                Person person = new Person() { Name = "Bob", Surname = "Smith" };

                context.People.Add(person);

                List<Family> families = new List<Family>()
                {
                    new Family() { Name = "Parents" },
                    new Family() { Name = "Pair" },
                    new Family() { Name = "Friends" }
                };

                families.ForEach(f => context.Families.Add(f));

                List<PersonFamily> personFamilies = new List<PersonFamily>()
                {
                    new PersonFamily{ PersonID = person.ID, FamilyID = families[0].ID},
                    new PersonFamily{ PersonID = person.ID, FamilyID = families[1].ID},
                    new PersonFamily{ PersonID = person.ID, FamilyID = families[2].ID}
                };

                personFamilies.ForEach(pf => context.PersonFamilies.Add(pf));

                context.SaveChanges();
            }
        }
    }
}
