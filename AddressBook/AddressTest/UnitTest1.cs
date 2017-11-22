using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AddressTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAmountOfContacts()
        {
            Person p1 = new Person(0, "Wolfgang", "Bauer", "wolfi.b1502@gmx.at");
            Person p2 = new Person(1, "Lukas", "Juster", "lukas.juster@gmail.com");
            Person p3 = new Person(2, "Philipp", "Gusenleitner", "philipp.gusenleitner@gmx.at");

            List<Person> persons = new List<Person> { p1, p2, p3 };

            ContactController cc = new ContactController();

            var result = (cc.Get() as OkObjectResult).Value as List<Person>;
            Assert.AreEqual(persons.Count, result.Count);

        }

        [TestMethod]
        public void TestDeleteContact()
        {
            Person p1 = new Person(0, "Wolfgang", "Bauer", "wolfi.b1502@gmx.at");
            Person p2 = new Person(1, "Lukas", "Juster", "lukas.juster@gmail.com");
            Person p3 = new Person(2, "Philipp", "Gusenleitner", "philipp.gusenleitner@gmx.at");

            List<Person> persons = new List<Person> { p1, p2, p3 };

            ContactController cc = new ContactController();

            var result = (cc.Delete(1) as ObjectResult).Value;
            Assert.AreEqual("Successful operation", result);

        }

    }
}
