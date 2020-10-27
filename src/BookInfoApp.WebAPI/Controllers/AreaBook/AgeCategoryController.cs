using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookInfoApp.Services.Contracts.AreaBook;
using BookInfoApp.Services.Dto.AreaBook;
using BookInfoApp.WebAPI.Models.AreaBook.AgeCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfoApp.WebAPI.Controllers.AreaBook
{
    /// <summary>
    /// Возрастная категория
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AgeCategoryController : ControllerBase
    {
        private readonly IAgeCategoryService service;
        private readonly IMapper mapper;

        public AgeCategoryController(IAgeCategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить все возрастные категории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AgeCategoryModel>> GetRolesAsync()
        {
            var resultDtos = await service.GetAllDeteilsAsync();

            var result = mapper.Map<List<AgeCategoryModel>>(resultDtos);
            return result;
        }

        /// <summary>
        /// Получить возрастную категорию по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AgeCategoryModel>> GetEmployeeByIdAsync(Guid id)
        {
            var result = await service.GetByIdDeteilsAsync(id);

            if (result.IsSuccess)
            {
                var roleModel = mapper.Map<AgeCategoryModel>(result.Entity);
                return roleModel;
            }
            else
            {
                return BadRequest(result.GetErrorString());
            }
        }

        /// <summary>
        /// Добавить возрастную категорию
        /// </summary>
        /// <param name="model">возрастная категория</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<HttpResponseMessage> Add([FromBody] AgeCategoryCreateModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<AgeCategoryDto>(model);
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
        /// Обновить возрастную категорию
        /// </summary>
        /// <param name="model">возрастная категория</param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> Edit([FromBody] AgeCategoryEditModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<AgeCategoryDto>(model);
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
        /// Удалить возрастную категорию
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
