using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoContest.Data.UnitOfWork
{
    using PhotoContext.Models;
    using Repositories;

    public interface IPhotoContestData
    {
        IRepository<User> Users { get; }

        IRepository<Picture> Pictures { get; }

        IRepository<Contest> Contests { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Prize> Prizes { get; }

        void SaveChanges();
    }
}
