namespace PhotoContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        public string Title { get; set; }

        public byte?[] Image { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
