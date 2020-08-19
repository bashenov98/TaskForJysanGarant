using System;
using System.Text.Json;
using System.IO;

namespace JysanGarant
{
    public class Person: Agent
    {
        public string firstName;
        public string middleName;
        public string lastName;

        public Person()
        {
        }

        public Person(int id, string iinOrBin, DateTime created_at,
            string created_by, DateTime changed_at, string changed_by,
            string _firstName, string _middleName, string _lastName) : base(id, iinOrBin, created_at, created_by, changed_at, changed_by)
        {
            firstName = _firstName;
            middleName = _middleName;
            lastName = _lastName;
        }

    }
}
