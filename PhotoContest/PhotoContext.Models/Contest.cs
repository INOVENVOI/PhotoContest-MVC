namespace PhotoContext.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contest
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string UserId { get; set; }

        public virtual User Organizator { get; set; }

        public virtual ICollection<User> JoinedInUsers { get; set; }

        public virtual PicturesInContests PicturesInContests { get; set; }
    }
}
