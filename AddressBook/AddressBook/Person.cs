using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Person
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Person(int id, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public override string ToString() {
            return "ID: " + this.Id + ", Name: " + this.FirstName + " " + this.LastName + ", E-Mail: " + this.Email;
        }

    }
}
