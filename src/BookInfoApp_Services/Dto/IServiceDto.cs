using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo_Services.Dto
{
    public interface IServiceDto
    {
    }

    public interface IServiceDto<TId> : IServiceDto where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
