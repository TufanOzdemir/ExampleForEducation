using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
    }
}
