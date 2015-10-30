namespace PhotoContest.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using PhotoContext.Models;

    public class DeadlineStrategyViewModel
    {
        public DateTime? DeadlineByTime { get; set; }

        public int? DeadlineByParticipantsNumber { get; set; }

        public static Expression<Func<DeadlineStrategy, DeadlineStrategyViewModel>> Create
        {
            get
            {
                return d => new DeadlineStrategyViewModel
                {
                    DeadlineByTime = d.DeadlineByTime,
                    DeadlineByParticipantsNumber = d.DeadlineByParticipantsNumber
                };
            }
        }
    }
}