using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Services.Contracts.AreaPublisher;
using BookInfoApp.Services.Dto.AreaPublisher;
using BookInfoApp.WebAPI.Models.AreaPublisher.Publisher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfoApp.WebAPI.Controllers.AreaPublisher
{
    /// <summary>
    /// Издательства
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService service;
        private readonly IMapper mapper;

        public PublisherController(IPublisherService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить все издательства
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PublisherModel>> GetRolesAsync()
        {
            var resultDtos = await service.GetAllDeteilsAsync();

            var result = mapper.Map<List<PublisherModel>>(resultDtos);
            return result;
        }

        /// <summary>
        /// Получить данные издательства по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PublisherModel>> GetEmployeeByIdAsync(Guid id)
        {
            var result = await service.GetByIdDeteilsAsync(id);

            if (result.IsSuccess)
            {
                var roleModel = mapper.Map<PublisherModel>(result.Entity);
                return roleModel;
            }
            else
            {
                return BadRequest(result.GetErrorString());
            }
        }

        /// <summary>
        /// Добавить новое издательство
        /// </summary>
        /// <param name="model">издательство</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<HttpResponseMessage> Add([FromBody] PublisherCreateModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<PublisherDto>(model);
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
        /// Обновить издательство
        /// </summary>
        /// <param name="model">издательство</param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> Edit([FromBody] PublisherEditModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<PublisherDto>(model);
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
        /// Удалить издательство
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
