namespace PhotoContext.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Prize
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }
    }
}
