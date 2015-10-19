namespace PhotoContext.Models
{
    public class Picture
    {
        public virtual int Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual User Owner { get; set; }

        public virtual PicturesInContests PicturesInContests { get; set; }
    }
}
