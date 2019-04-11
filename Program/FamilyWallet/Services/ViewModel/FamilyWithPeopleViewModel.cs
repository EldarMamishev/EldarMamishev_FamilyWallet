using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class FamilyWithPeopleViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonViewModel> People { get; set; }
    }
}
