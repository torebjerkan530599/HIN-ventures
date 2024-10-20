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
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

//https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-6.0&pivots=webassembly


namespace HIN_ventures_Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class FileSaveController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<FileSaveController> logger;

        public FileSaveController(IWebHostEnvironment env,
            ILogger<FileSaveController> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<IList<CodeFileDto>>> PostFile([FromForm] IEnumerable<IFormFile> files)
        {
            var maxAllowedFiles = 1;
            long maxFileSize = 1024 * 1024 * 15;
            var filesProcessed = 0;
            var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
            List<CodeFileDto> uploadResults = new();

            foreach (var file in files)
            {
                var uploadResultCodeFileDto = new CodeFileDto();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResultCodeFileDto.FileName = untrustedFileName;
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                if (filesProcessed < maxAllowedFiles)
                {
                    if (file.Length == 0)
                    {
                        logger.LogInformation("{FileName} length is 0 (Err: 1)", trustedFileNameForDisplay);
                        uploadResultCodeFileDto.ErrorCode = 1;
                    }
                    else if (file.Length > maxFileSize)
                    {
                        logger.LogInformation("{FileName} of {Length} bytes is " +
                                              "larger than the limit of {Limit} bytes (Err: 2)",
                            trustedFileNameForDisplay, file.Length, maxFileSize);
                        uploadResultCodeFileDto.ErrorCode = 2;
                    }
                    else
                    {
                        try
                        {
                            trustedFileNameForFileStorage = Path.GetRandomFileName();
                            var v = env.ContentRootPath; //"C:\\Users\\Ny\\source\\repos\\HIN-ventures\\HIN-ventures_Api"
                            var bv = env.EnvironmentName; //"Development"
                            var path = Path.Combine(env.ContentRootPath, env.EnvironmentName, "unsafe_uploads", trustedFileNameForFileStorage);
                            uploadResultCodeFileDto.CodeFileUrl = path;


                            await using FileStream fs = new(path, FileMode.Create);
                            await file.CopyToAsync(fs);

                            logger.LogInformation("{FileName} saved at {Path}", trustedFileNameForDisplay, path);
                            uploadResultCodeFileDto.Uploaded = true;
                            uploadResultCodeFileDto.StoredFileName = trustedFileNameForFileStorage;
                        }
                        catch (IOException ex)
                        {
                            logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                                trustedFileNameForDisplay, ex.Message);
                            uploadResultCodeFileDto.ErrorCode = 3;
                        }
                    }

                    filesProcessed++;
                }
                else
                {
                    logger.LogInformation("{FileName} not uploaded because the " +
                                          "request exceeded the allowed {Count} of files (Err: 4)",
                        trustedFileNameForDisplay, maxAllowedFiles);
                    uploadResultCodeFileDto.ErrorCode = 4;
                }

                uploadResults.Add(uploadResultCodeFileDto);
            }

            return new CreatedResult(resourcePath, uploadResults);
        }
    }
}

////FOR TESTING, testing method in test file
////PowerShell
//$out = new- object byte[]
//{ SIZE}; (new- object Random).NextBytes($out);[IO.File]::WriteAllBytes('{PATH}', $out)