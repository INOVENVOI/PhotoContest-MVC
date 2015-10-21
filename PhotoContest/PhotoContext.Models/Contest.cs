namespace PhotoContext.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contest
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string OrganizerId { get; set; }

        public virtual User Organizer { get; set; } // Organizer

        public virtual ICollection<User> Users { get; set; } // Users is Contest

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
