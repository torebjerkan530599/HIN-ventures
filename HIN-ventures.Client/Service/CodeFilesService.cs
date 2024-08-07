﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures;
using HIN_ventures.Models;
using HIN_ventures_Client.Service.IService;
using Newtonsoft.Json;

namespace HIN_ventures_Client.Service
{
    public class CodeFilesService : ICodeFileService
    {
        private readonly HttpClient _client;

        public CodeFilesService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CodeFileDto> CreateCodeFile(CodeFileDto codeFile)
        {
            var content = JsonConvert.SerializeObject(codeFile);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/codeFile/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CodeFileDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
        public async Task<int> CreateCodeFileReturnInt(CodeFileDto codeFile)
        {
            var content = JsonConvert.SerializeObject(codeFile);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/codeFile/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public async Task<CodeFileDto> UpdateCodeFile(int codeFileId, CodeFileDto codeFile)
        {
            var content = JsonConvert.SerializeObject(codeFile);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"api/codeFile/update/{codeFileId}", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CodeFileDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFilesFromAssignment(int Id)
        {
            var response = await _client.GetAsync($"api/codeFile/GetCodeFilesFromAssignment/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var codeFiles = JsonConvert.DeserializeObject<IEnumerable<CodeFileDto>>(content);
                return codeFiles;
            }
            else
            {
                return null;
            }
        }

        public async Task<CodeFileDto> GetCodeFile(int Id)
        {
            var response = await _client.GetAsync($"api/codeFile/getCodeFile/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var codeFile = JsonConvert.DeserializeObject<CodeFileDto>(content);
                return codeFile;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

        public async Task<IEnumerable<CodeFileDto>> GetCodeFiles()
        {
            var response = await _client.GetAsync("api/codeFile/getCodeFiles");
            var content = await response.Content.ReadAsStringAsync();
            var codeFiles = JsonConvert.DeserializeObject<IEnumerable<CodeFileDto>>(content);
            return codeFiles;
        }

      
    }
}