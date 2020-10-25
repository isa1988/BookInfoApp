using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfoApp.Services.Dto
{
    public interface IServiceDto
    {
    }

    public interface IServiceDto<TId> : IServiceDto where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
