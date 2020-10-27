using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Services.Contracts.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;
using BookInfoApp.WebAPI.Models.AreaPublisher.CoverType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfoApp.WebAPI.Controllers.AreaPublisher
{
    /// <summary>
    /// Типы обложек
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoverTypeController : ControllerBase
    {
        private readonly ICoverTypeService service;
        private readonly IMapper mapper;

        public CoverTypeController(ICoverTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить все типы обложек
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<CoverTypeModel>> GetRolesAsync()
        {
            var resultDtos = await service.GetAllDeteilsAsync();

            var result = mapper.Map<List<CoverTypeModel>>(resultDtos);
            return result;
        }

        /// <summary>
        /// Получить тип обложки по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CoverTypeModel>> GetEmployeeByIdAsync(Guid id)
        {
            var result = await service.GetByIdDeteilsAsync(id);

            if (result.IsSuccess)
            {
                var roleModel = mapper.Map<CoverTypeModel>(result.Entity);
                return roleModel;
            }
            else
            {
                return BadRequest(result.GetErrorString());
            }
        }

        /// <summary>
        /// Добавить тип обложки
        /// </summary>
        /// <param name="model">тип обложки</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<HttpResponseMessage> Add([FromBody] CoverTypeCreateModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<CoverTypeDto>(model);
            var result = await service.CreateAsync(role);
            if (result.IsSuccess)
            {

                string message = ($"Student Created - {result.Entity.Id}");
                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            else
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, result.GetErrorString());
            }

            return returnMessage;
        }

        /// <summary>
        /// Обновить тип обложки
        /// </summary>
        /// <param name="model">тип обложки</param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> Edit([FromBody] CoverTypeEditModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<CoverTypeDto>(model);
            var result = await service.EditAsync(role);
            if (result.IsSuccess)
            {

                string message = ($"Student Created - {result.Entity.Id}");
                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            else
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, result.GetErrorString());
            }


            return returnMessage;
        }

        /// <summary>
        /// Удалить тип обложки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>

        [HttpPost("Delete{id:guid}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var result = await service.DeleteItemAsync(id);
            if (result.IsSuccess)
            {

                string message = ($"Student Created - {result.Entity.Id}");
                returnMessage = new HttpResponseMessage(HttpStatusCode.Created);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, message);
            }
            else
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, result.GetErrorString());
            }


            return returnMessage;
        }
    }
}
