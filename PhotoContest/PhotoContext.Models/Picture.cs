namespace PhotoContext.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        private ICollection<Contest> contests;
        private ICollection<Vote> votes;

        public Picture()
        {
            this.contests = new HashSet<Contest>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; } // Owner

        public virtual ICollection<Contest> Contests { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
