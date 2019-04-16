using Microsoft.AspNetCore.Identity;
using Services.Authentification.Enum;

namespace Services.Authentification.Entity
{
    public class Social : IdentityUser
    {
        public int PersonId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public int SocialId { get; set; }
    }
}
