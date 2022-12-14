using System;
using NhlSystem;
namespace NhlSystemTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McJeezuz")]
        [DataRow("Leon Draistal")]
        
        public void FullName_ValidName_FullNameSet(string fullName)//test for valid data
        {
            var validPerson = new Person(fullName);
            Assert.AreEqual(fullName, validPerson.FullName);
            //var validPerson = new Person("Connor McJeezuz");
            //Assert.AreEqual("Connor McJeezuz", validPerson.FullName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("         ")]

        public void FullName_InvalidName_ArgumentNullException(string fullName)//test for valid data
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new Person(fullName));
            Assert.AreEqual("FullName value is required.", ex.ParamName);
        }


        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow(" A ")]
        public void FullName_InvalidNameLength_ArgumenException(string fullName)//test for valid data
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new Person(fullName));
            Assert.AreEqual("FullName must contain 3 or more characters.", ex.Message);
        }
    }
}