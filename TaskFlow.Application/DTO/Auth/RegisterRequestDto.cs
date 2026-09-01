using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.DTO.Auth
{
    public class RegisterRequestDto
    {
        public string Name { get; set; } //Name of the registering user

        public string Email { get; set; }// registering user's email

        public string Password { get; set; }// registering user's password
    }
}
