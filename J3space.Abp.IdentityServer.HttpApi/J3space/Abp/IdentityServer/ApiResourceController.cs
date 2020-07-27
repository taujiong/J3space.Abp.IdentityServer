﻿using System;
using System.Threading.Tasks;
using J3space.Abp.IdentityServer.ApiResources;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace J3space.Abp.IdentityServer
{
    [RemoteService(Name = IdentityServerRemoteServiceConstants.RemoteServiceName)]
    [Area("identityServer")]
    [Route("api/ids/api-resources")]
    public class ApiResourceController : IdentityServerControllerBase, IApiResourceAppService
    {
        private readonly IApiResourceAppService _appService;

        public ApiResourceController(IApiResourceAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public Task<PagedResultDto<ApiResourceDto>> GetListAsync(
            PagedAndSortedResultRequestDto input)
        {
            return _appService.GetListAsync(input);
        }

        [HttpGet]
        [Route("all")]
        public Task<ListResultDto<ApiResourceDto>> GetAllListAsync()
        {
            return _appService.GetAllListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ApiResourceDto> GetAsync(Guid id)
        {
            return _appService.GetAsync(id);
        }

        [HttpPost]
        public Task<ApiResourceDto> CreateAsync(ApiResourceCreateUpdateDto input)
        {
            return _appService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ApiResourceDto> UpdateAsync(Guid id, ApiResourceCreateUpdateDto input)
        {
            return _appService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<JsonResult> DeleteAsync(Guid id)
        {
            return _appService.DeleteAsync(id);
        }
    }
}