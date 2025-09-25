using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashBooking.Domain.Entities;

namespace WashBooking.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> IsTokenValid(string refreshToken);
        Task UpdateRefreshToken(RefreshToken refreshToken);
    }
}
