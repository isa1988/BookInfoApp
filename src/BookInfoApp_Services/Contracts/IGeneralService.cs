using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookInfo_Core.Entities;
using BookInfo_Services.Dto;

namespace BookInfo_Services.Contracts
{
    public interface IGeneralService<TEntity, TDto>
        where TEntity : IEntity
        where TDto : IServiceDto
    {
        /// <summary>
        /// Добавить запись в базу
        /// </summary>
        /// <param name="createDto">Объект добавление</param>
        /// <returns></returns>
        Task<EntityOperationResult<TEntity>> CreateAsync(TDto createDto);
        
        /// <summary>
        /// Вернуть все записи
        /// </summary>
        /// <returns></returns>
        Task<List<TDto>> GetAllAsync();


        /// <summary>
        /// Вернуть все записи со всеми зависимостями
        /// </summary>
        /// <returns></returns>
        Task<List<TDto>> GetAllDeteilsAsync();

        /// <summary>
        /// Вернуть по странично
        /// </summary>
        /// <param name="numPage">Номер страницы</param>
        /// <param name="pageSize">Записей на странице</param>
        /// <returns></returns>
        Task<List<TDto>> GetPageAsync(int numPage, int pageSize);
        /// <summary>
        /// Вернуть по странично со всеми зависимостями
        /// </summary>
        /// <param name="numPage">Номер страницы</param>
        /// <param name="pageSize">Записей на странице</param>
        /// <returns></returns>
        Task<List<TDto>> GetPageDeteilsAsync(int numPage, int pageSize);
    }

    public interface IGeneralService<TEntity, TDto, TId> : IGeneralService<TEntity, TDto>
        where TEntity : IEntity<TId>
        where TDto : IServiceDto<TId>
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Вернуть конкретный объект из базы
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        Task<EntityOperationResult<TDto>> GetByIdAsync(TId id);
        /// <summary>
        /// Вернуть конкретный объект из базы со всеми зависимостями
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        Task<EntityOperationResult<TDto>> GetByIdDeteilsAsync(TId id);


        /// <summary>
        /// Удалить объект из БД
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        Task<EntityOperationResult<TEntity>> DeleteItemAsync(TId id);
    }
}
