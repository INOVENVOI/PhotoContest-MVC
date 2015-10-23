using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoContext.Models
{
    public class DeadlineStrategy
    {
        public int Id { get; set; }

        public DateTime? DeadlineByTime { get; set; }

        public int? DeadlineByParticipantsNumber { get; set; }
    }
}
