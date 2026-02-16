using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
    }
}
