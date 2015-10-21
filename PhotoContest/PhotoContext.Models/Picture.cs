namespace PhotoContext.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        public virtual int Id { get; set; }

        public virtual string OwnerId { get; set; }

        public virtual User Owner { get; set; } // Owner

        public virtual ICollection<Contest> Contests { get; set; }
    }
}
