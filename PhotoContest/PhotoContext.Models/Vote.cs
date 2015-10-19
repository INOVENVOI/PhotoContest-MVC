namespace PhotoContext.Models
{
    using System.Collections.Generic;

    public class Vote
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string PicturesInContestsId { get; set; }

        public PicturesInContests PicturesInContests { get; set; }
    }
}
