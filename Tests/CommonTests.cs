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
        public void TestGetDisplayNameOrObjectName3() {
            var obj2 = new Connector();
            Assert.That(obj2.Name.GetDisplayNameOrObjectName(), Is.EqualTo("obj2.Name"));
        }

        [Test]
        public void TestCompare1() {
            var obj1 = new Connector { Id = 1, Name = "ali", Description = "salam" };
            var obj2 = new Connector { Id = 2, Name = "ali" };
            var result = obj1.Compare(obj2).Print();
            Assert.Pass(result); // for check output
        }

        [Test]
        public void TestCompare2() {
            var obj1 = new Family { Id = 10, Title = "تست", AddDate = DateTime.Now, ContactPersonName = "سینا", ConnectorId = 1 };
            var obj2 = new Family { };
            var result = obj1.Compare(obj2).PrintA();
            Assert.Pass(result); // for check output
        }

        [Test]
        public void TestGetPropertyDisplayNameOrName() {
            var obj2 = new Connector();
            Assert.That(obj2.GetPropertyDisplayNameOrName(x => x.Id), Is.EqualTo("کد"));
        }
    }
}