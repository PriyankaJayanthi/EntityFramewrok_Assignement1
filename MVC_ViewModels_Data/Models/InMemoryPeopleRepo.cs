using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int _idCounter = 0;




        public Person Create(string Name, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(_idCounter, Name, PersonPhoneNumber, PersonCity);
            _idCounter++;
            _personList.Add(newPerson);
            return newPerson;
        }

        public bool Delete(Person person)
        {
            bool delete = _personList.Remove(person);
            
            return delete;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            Person findPersonById = _personList.Find(idNr => idNr.PersonId == id);

            return findPersonById;
        }

        public Person Update(Person person)
        {
            foreach(Person item in _personList)
            {
                if(item.PersonId == person.PersonId)
                {
                    item.Name = person.Name;
                    item.ContactNumber = person.ContactNumber;
                    item.City = person.City;
                }
            }
            return person;
        }
        public void CreateBasePersons()
          {
            InMemoryPeopleRepo pDataBase = new InMemoryPeopleRepo();
            pDataBase.Create("Keerthi", "0823675578", "Goteborg");
            pDataBase.Create("Priyanka", "02134578", "Goteborg");
            pDataBase.Create("John", "03589018", "USA");
            pDataBase.Create("Anna", "035890176", "USA");
            pDataBase.Create("Jonas", "00988888", "Goteborg");
            pDataBase.Create("Fredal", "766279373", "Goteborg");

        }
    }
}
