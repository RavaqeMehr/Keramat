using Common.Utilities;
using Assert = NUnit.Framework.Assert;

namespace Tests {
    public class DateTimeTests {
        [SetUp]
        public void Setup() {

        }

        [Test]
        public void Test1() {
            var now = DateTime.Now;
            var faNow = now.ToPersianDateTime();
            Assert.Pass(new {
                now,
                faNow,
                now.Year,
                faYear = faNow.Year,
                faStr = now.ToPersianDateString()
            }.ToJSON()
            );
        }
    }
}
