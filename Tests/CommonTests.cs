using Common.Utilities;
using Entities.ValiNematan;
using Assert = NUnit.Framework.Assert;

namespace Tests {
    public class CommonTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test1() {
            Assert.Pass();
        }

        [Test]
        public void TestGetDisplayNameOrObjectName1() {
            var obj1 = new object();
            Assert.That(obj1.GetDisplayNameOrObjectName(), Is.EqualTo("obj1"));
        }

        [Test]
        public void TestGetDisplayNameOrObjectName2() {
            var obj2 = new Connector();
            Assert.That(obj2.Id.GetDisplayNameOrObjectName(), Is.EqualTo("˜Ï"));
        }

        [Test]
        public void TestGetDisplayNameOrObjectName3() {
            var obj2 = new Connector();
            Assert.That(obj2.Name.GetDisplayNameOrObjectName(), Is.EqualTo("obj2.Name"));
        }
    }
}