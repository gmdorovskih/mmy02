using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Models;

namespace UniversityApp.Storage
{
    public static class PeopleRegistry
    {
        private static readonly List<Person> _people = new List<Person>();

        public static void RegisterPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _people.Add(person);
        }

        public static Person? GetPersonById(int personalId)
        {
            return _people.FirstOrDefault(p => p.PersonalId == personalId);
        }

        public static List<Person> GetAllPeople()
        {
            return new List<Person>(_people);
        }
    }
}