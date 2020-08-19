using System;
using System.Collections.Generic;

namespace JysanGarant
{
    public class Entity: Agent
    {
        public string name;
        public List<Person> contactList;
        public Entity(int _id, string _iinOrBin, DateTime _created_at,
            string _created_by, DateTime _changed_at, string _changed_by,
            string _name, List<Person> _contactList) : base(_id, _iinOrBin, _created_at, _created_by, _changed_at, _changed_by)
        { 
            name = _name;
            contactList = _contactList;
        }
        public Entity() { }
        
    }
}
