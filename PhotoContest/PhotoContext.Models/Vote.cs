namespace PhotoContext.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VoterId { get; set; } // Voter

        public virtual User Voter { get; set; } //Voter

        [Required]
        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        [Required]
        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }
    }
}
