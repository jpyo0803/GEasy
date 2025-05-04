using Xunit;
using Geasy;

namespace Geasy.Tests
{
    public class Class1Tests
    {
        [Fact]
        public void TestAdd()
        {
            int result = Class1.TestAdd(2, 3);
            Assert.Equal(5, result);
        }
    }
}