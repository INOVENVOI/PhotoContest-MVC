using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTests
{
    using Xunit;

    public class DbInitializer
    {
        [Fact]
        public void Init_Successful()
        {
            PhotoDbContext ctx = new PhotoDbContext();
            ctx.Database.Initialize(true);
        }
    }
}
