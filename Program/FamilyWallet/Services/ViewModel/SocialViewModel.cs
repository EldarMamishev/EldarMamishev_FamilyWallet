using Services.Authentification.Enum;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class SocialViewModel : EntityViewModelBase
    {
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}