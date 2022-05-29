using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ViewModels_Data.Models
{
    public class Person
    { 

        [Required]
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string Name { get; set; }
  

        [Required]
        [Range(10,12)]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string City { get; set; }

        public Person(int PersonId, string Name, string ContactNumber, string City)
        {
            this.PersonId = PersonId;
            this.Name = Name;
            this.ContactNumber = ContactNumber;
            this.City = City;
        }
        public Person(string Name, string ContactNumber, string City)
        { 
            this.Name = Name;
            this.ContactNumber = ContactNumber;
            this.City = City;
        }

        public Person()
        {
        }
    }
}
