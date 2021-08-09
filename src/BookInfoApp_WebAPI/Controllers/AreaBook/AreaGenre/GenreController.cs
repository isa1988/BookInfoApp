using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BookInfo_Services.Contracts.AreaBook.AreaGenre;
using BookInfo_Services.Dto.AreaBook.AreaGenre;
using BookInfo_WebAPI.Models.AreaBook.AreaGenre.Genre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo_WebAPI.Controllers.AreaBook.AreaGenre
{
    /// <summary>
    /// Жанры
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService service;
        private readonly IMapper mapper;

        public GenreController(IGenreService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить все жанры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GenreModel>> GetRolesAsync()
        {
            var resultDtos = await service.GetAllDeteilsAsync();

            var result = mapper.Map<List<GenreModel>>(resultDtos);
            return result;
        }

        /// <summary>
        /// Получить жанр по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GenreModel>> GetEmployeeByIdAsync(Guid id)
        {
            var result = await service.GetByIdDeteilsAsync(id);

            if (result.IsSuccess)
            {
                var roleModel = mapper.Map<GenreModel>(result.Entity);
                return roleModel;
            }
            else
            {
                return BadRequest(result.GetErrorString());
            }
        }

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="model">жанр</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<HttpResponseMessage> Add([FromBody] GenreCreateModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<GenreDto>(model);
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
        /// Обновить жанр
        /// </summary>
        /// <param name="model">жанр</param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> Edit([FromBody] GenreEditModel model)
        {

            HttpResponseMessage returnMessage = new HttpResponseMessage();

            var role = mapper.Map<GenreDto>(model);
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
        /// Удалить жанр
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
