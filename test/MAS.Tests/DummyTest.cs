using Xunit;

namespace MAS.Tests
{
    [Trait("Category", "Unit")]
    public class DummyTest
    {
        [Fact(DisplayName = "Dummy test")]
        public void Any()
        {
            Assert.True(true);
        }
    }
}