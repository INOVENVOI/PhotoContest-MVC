namespace PhotoContext.Models
{
    using System.Collections.Generic;

    public class RewardStrategy
    {
        private ICollection<Prize> prizes;
        
        public RewardStrategy()
        {
            this.prizes = new HashSet<Prize>();
        }

        public int Id { get; set; }

        public string WinnerId { get; set; }

        public virtual User Winner { get; set; }

        public virtual ICollection<Prize> Prizes { get; set; }

    }
}
