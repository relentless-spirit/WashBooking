using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashBooking.Application.DTOs.AuthDTO.LogoutDTO
{
    public class LogoutRequest
    {
        public string RefreshToken { get; set; }
    }
}
