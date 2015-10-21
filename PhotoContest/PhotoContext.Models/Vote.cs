namespace PhotoContext.Models
{
    public class Vote
    {
        public virtual int Id { get; set; }

        public virtual string UserId { get; set; } // Voter

        public virtual User User { get; set; } //Voter

        public virtual int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual int ContestId { get; set; }

        public virtual Contest Contest { get; set; }
    }
}
