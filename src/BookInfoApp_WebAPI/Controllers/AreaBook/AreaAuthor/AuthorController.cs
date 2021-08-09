using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookInfo_Services.Contracts.AreaBook.AreaAuthor;
using BookInfo_Services.Dto.AreaBook.AreaAuthor;
using BookInfo_WebAPI.Models;
using BookInfo_WebAPI.Models.AreaBook.AreaAuthor.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo_WebAPI.Controllers.AreaBook.AreaAuthor
{
    /// <summary>
    /// Авторы
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService service;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить всех авторов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AuthorModel>> GetRolesAsync()
        {
            var resultDtos = await service.GetAllDeteilsAsync();

            var result = mapper.Map<List<AuthorModel>>(resultDtos);
            return result;
        }

        /// <summary>
        /// Получить автора по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorModel>> GetEmployeeByIdAsync(Guid id)
        {
            var result = await service.GetByIdDeteilsAsync(id);

            if (result.IsSuccess)
            {
                var roleModel = mapper.Map<AuthorModel>(result.Entity);
                return roleModel;
            }
            else
            {
                return BadRequest(result.GetErrorString());
            }
        }

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="model">автор</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<HttpResponseMessage> Add([FromBody] AuthorCreateModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<AuthorDto>(model);
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
        /// Обновить автора
        /// </summary>
        /// <param name="model">автор</param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> Edit([FromBody] AuthorEditModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<AuthorDto>(model);
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
        /// Удалить автора
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
