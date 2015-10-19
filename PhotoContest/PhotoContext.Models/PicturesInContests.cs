namespace PhotoContext.Models
{
    using System.Collections.Generic;

    public class PicturesInContests
    {
        public int Id { get; set; }

        public ICollection<Contest> Contests { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
