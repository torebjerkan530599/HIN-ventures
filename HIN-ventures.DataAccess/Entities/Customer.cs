﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string Phone { get; set; }
        
        //Hvis privat person ingen ORG nr
        public string VAT_number { get; set; }

        public string CryptoAddress { get; set; }

        public int SubscriptionType { get; set; }

        public int TotalLinesOfCode { get; set; }

        public int TotalCost { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        [Required]
        public string IdentityId { get; set; }
    }
}
