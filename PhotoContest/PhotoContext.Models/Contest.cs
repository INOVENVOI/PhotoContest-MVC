namespace PhotoContext.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contest
    {
        private ICollection<Picture> pictures;
        private ICollection<User> participants;

        public Contest()
        {
            this.pictures = new HashSet<Picture>();
            this.participants = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string OrganizerId { get; set; }

        public virtual User Organizer { get; set; } // Organizer

        public virtual RewardStrategy RewardStrategy { get; set; }

        public virtual VotingStrategy VotingStrategy { get; set; }

        public virtual ParticipationStrategy ParticipationStrategy { get; set; }

        public virtual DeadlineStrategy DeadlineStrategy { get; set; }

        public virtual ICollection<User> Participants { get; set; } // Users is Contest

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
