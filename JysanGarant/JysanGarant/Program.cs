using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Json.Net;
using System.Linq;

namespace JysanGarant
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Person> listofperson = new List<Person>();
            Person test1 = new Person()
            {
                id = 1,
                iinOrBin = "981213350664",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                firstName = "Daniyar",
                middleName = "Daniyarov",
                lastName = "Daniyarov"
            };
            Person test2 = new Person()
            {
                id = 2,
                iinOrBin = "981213350664",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                firstName = "Rustam",
                middleName = "Daniyarov",
                lastName = "Bashenov"
            };
            Person test3 = new Person()
            {
                id = 3,
                iinOrBin = "9231230664",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                firstName = "Ramazan",
                middleName = "Daniyarov",
                lastName = "Abzhamel"
            };
            Person test4 = new Person()
            {
                id = 4,
                iinOrBin = "923213314",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                firstName = "Kuanysh",
                middleName = "Daniyarov",
                lastName = "Khamitov"
            };

            Person test5 = new Person()
            {
                id = 5,
                iinOrBin = "9231230664",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                firstName = "Ardak",
                middleName = "Daniyarov",
                lastName = "Kapar"
            };


            listofperson.Add(test1);
            listofperson.Add(test2);
            listofperson.Add(test3);
            listofperson.Add(test4);
            listofperson.Add(test5);

            List<Entity> entities = new List<Entity>();
            Entity etest1 = new Entity()
            {
                id = 1,
                iinOrBin = "1234567",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "Abdirov51",
                contactList = listofperson
            };
            Entity etest2 = new Entity()
            {
                id = 2,
                iinOrBin = "1321367",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "Congress",
                contactList = new List<Person>() { test1, test2, test5, test3}
            };
            Entity etest3 = new Entity()
            {
                id = 3,
                iinOrBin = "232131367",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "Mercedes",
                contactList = new List<Person>() { test1, test2, test5 }
            };
            Entity etest4 = new Entity()
            {
                id = 4,
                iinOrBin = "133123267",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "BMW",
                contactList = new List<Person>() { test1, test2, test4 }
            };
            Entity etest5 = new Entity()
            {
                id = 5,
                iinOrBin = "132453245",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "Audi",
                contactList = new List<Person>() { test1, test2 }
            };
            Entity etest6 = new Entity()
            {
                id = 6,
                iinOrBin = "2132453245",
                created_at = DateTime.Today,
                created_by = "self",
                changed_at = DateTime.Now,
                changed_by = "self",
                name = "Ferrari",
                contactList = new List<Person>() { test1 }
            };
            entities.Add(etest1);
            entities.Add(etest2);
            entities.Add(etest3);
            entities.Add(etest4);
            entities.Add(etest5);
            entities.Add(etest6);
            using (StreamWriter file = File.CreateText("person.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, listofperson);
            }
            using (StreamWriter file = File.CreateText("entity.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, entities);
                Console.WriteLine("Serialization is Done");
            }
            try
            {
                using (StreamReader file = File.OpenText("person.json"))
                {
                    Console.WriteLine("Вывод списка ФизЛиц по фамилии:");
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    List<Person> persons = (List<Person>)serializer.Deserialize(file, typeof(List<Person>));
                    List<Person> people = persons.OrderBy(o => o.lastName).ToList();
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine(people[i].lastName + ' ' + people[i].firstName + ' ' + people[i].middleName);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("{0}: The read " +
                    "operation could not be performed " +
                    "because the specified part of the " +
                    "file is locked.",
                    e.GetType().Name);
            }
            try
            {
                using (StreamReader file = File.OpenText("entity.json"))
                {
                    Console.WriteLine("Bывод 5 ЮрЛиц с наибольшим количеством контактных лиц");
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    List<Entity> entities1 = (List<Entity>)serializer.Deserialize(file, typeof(List<Entity>));
                    List<Entity> entities2 = entities1.OrderByDescending(o => o.contactList.Count).ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(entities2[i].name);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("{0}: The read " +
                    "operation could not be performed " +
                    "because the specified part of the " +
                    "file is locked.",
                    e.GetType().Name);
            }
            
            
        }

    }
}
