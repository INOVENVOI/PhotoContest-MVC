namespace PhotoContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contest
    {
        private ICollection<Picture> pictures;
        private ICollection<User> participants;
        private ICollection<Vote> votes;
        private IList<Prize> prizes;

        public Contest()
        {
            this.pictures = new HashSet<Picture>();
            this.participants = new HashSet<User>();
            this.votes = new HashSet<Vote>();
            this.prizes = new List<Prize>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        public virtual User Organizer { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int? ParticipantsLimit { get; set; }

        [Required]
        public ContestStatus ContestStatus { get; set; }

        public virtual VotingStrategy VotingStrategy { get; set; }

        public virtual ParticipationStrategy ParticipationStrategy { get; set; }

        public virtual DeadlineStrategy DeadlineStrategy { get; set; }

        public virtual ICollection<User> Participants { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual IList<Prize> Prizes { get; set; }
    }
}
