using System.Collections.Generic;

namespace Services.ViewModel
{
    public class FamilyWithPeopleViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonViewModel> People { get; set; }
    }
}
