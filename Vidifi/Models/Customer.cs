﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidifi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //You can override a validation error by using syntax below
        [Required(ErrorMessage = "Please enter customer name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        //Membership type is implicitly required
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //Adds custom validation from the Min18YearIfAMember class
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }   
}