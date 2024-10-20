﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.Models
{
    public class BookingDetailsDto
    {
        public int Id { get; set; } 

        //public int FreelancerId; //the freelancer the customer is hiring <------ utgår

        public FreelancerDto FreelancerDto { get; set; } //kan bare booke en frilanser om gangen

        public AssignmentDto AssignmentDto { get; set; } //assignment som frilanseren skal bookes til

        public CustomerDto CustomerDto { get; set; }

        //additional info on the customer who is booking
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string OrderStatus { get; set; }
    }
}
