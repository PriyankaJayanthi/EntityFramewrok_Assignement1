using Microsoft.EntityFrameworkCore; 
using MVC_ViewModels_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private readonly ExDbContext _context;
        private static int idCounter = 0;

        public DatabasePeopleRepo(ExDbContext context)
        {
            _context = context;
            if (_personList.Count == 0)
                _personList = _context.Person.ToList();
        }

        public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(PersonName, PersonPhoneNumber, PersonCity);

            _personList.Add(newPerson);
            _context.Person.Add(newPerson);
            _context.SaveChanges();
            /*foreach (Person item in _personList)
            {
                if (item.PersonId == newPerson.PersonId)
                {
                    item.Name = newPerson.Name;
                    item.ContactNumber = newPerson.ContactNumber;
                    item.City = newPerson.City;
                    _context.Person.Update(item);
                    _personList = _context.Person.ToList();
                }
                else 
                {
                    _context.Person.Add(item);
                }
                _context.SaveChanges();
            }*/
            return newPerson;
        }

        public bool Delete(Person person)
        {
            bool deleted = _personList.Remove(person);
            if (deleted)
            {
                _context.Person.Remove(person);
                _context.SaveChanges();
            }

            return deleted;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            //LINQ expression
            // Define the query expression
            IEnumerable<Person> personQuery =
                from person in _personList
                where person.PersonId == id
                select person;

            return personQuery.First();
        }

        public Person Update(Person person)
        {
            foreach (Person item in _personList)
            {
                if (item.PersonId == person.PersonId)
                {
                    item.Name = person.Name;
                    item.ContactNumber = person.ContactNumber;
                    item.City = person.City;

                    _context.Person.Update(item);
                    _context.SaveChanges();

                    _personList = _context.Person.ToList();
                }
            }

            return person;
        }
    }
}
