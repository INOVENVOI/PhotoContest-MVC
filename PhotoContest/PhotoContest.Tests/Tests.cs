namespace PhotoContest.Tests
{
    using Xunit;

    public class Tests
    {
        [Fact]
        public void Init_Successful()
        {
            PhotoDbContext ctx = new PhotoDbContext();
            ctx.Database.Initialize(true);
        }
    }
}
