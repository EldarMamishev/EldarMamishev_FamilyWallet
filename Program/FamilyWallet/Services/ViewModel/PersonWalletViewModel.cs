using Domain.Enum;

namespace Services.ViewModel
{
    public class PersonWalletViewModel
    {
        public PersonViewModel Person { get; set; }
        public FamilyWithPeopleViewModel Family { get; set; }
        public AccessModifier AccessModifier { get; set; }
    }
}
