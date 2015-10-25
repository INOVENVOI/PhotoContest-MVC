using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoContext.Models
{
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
