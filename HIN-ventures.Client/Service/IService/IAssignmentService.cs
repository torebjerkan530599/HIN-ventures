﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Client.Service.IService
{
    public interface IAssignmentService
    {
        public Task<IEnumerable<AssignmentDto>> GetAssignments();
        public Task<AssignmentDto> GetAssignment(int assignmentId);
    }
}