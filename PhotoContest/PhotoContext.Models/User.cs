namespace PhotoContext.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Contest> contests;
        private ICollection<Picture> pictures;
        private ICollection<Vote> votes;

        public User()
        {
            this.contests = new HashSet<Contest>();
            this.pictures = new HashSet<Picture>();
            this.votes = new HashSet<Vote>();
        }

        public string FullName { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
