﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Common;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CodeFileController : Controller
    {
        private readonly ICodeFileRepository _codeFileRepository;

        public CodeFileController(ICodeFileRepository codeFileRepository)
        {
            _codeFileRepository = codeFileRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CodeFileDto codeFileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _codeFileRepository.CreateCodeFile(codeFileDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating new codeFile"
                });
            }
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCodeFilesFromAssignment(int Id)
        {
            var codeFileDtoDetails = await _codeFileRepository.GetCodeFilesFromAssignment(Id);
            if (codeFileDtoDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "No data",
                    ErrorMessage = "Invalid CodeFile Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(codeFileDtoDetails);

        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCodeFile(int Id)
        {
            var codeFileDtoDetails = await _codeFileRepository.GetCodeFilesFromAssignment(Id);
            if (codeFileDtoDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid CodeFile Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(codeFileDtoDetails);

        }

        //[HttpGet]
        //public async Task<IActionResult> GetCodeFiles()
        //{
        //    var freelancers = await _codeFileRepository.GetCodeFiles();
        //    return Ok(freelancers);
        //}

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CodeFileDto codeFileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _codeFileRepository.UpdateCodeFile(id, codeFileDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while Updating Code File"
                });
            }
        }
    }
}
