namespace PhotoContext.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string VoterId { get; set; } // Voter

        public virtual User Voter { get; set; } //Voter

        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }
    }
}
