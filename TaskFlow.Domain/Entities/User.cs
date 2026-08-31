using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } //ID is a globaly unique identifier for the user that lowers the chance of conflict and ID duplication

        public string Name { get; set; } = string.Empty; //Name of the user is not null but will be empty text 

        public string Email { get; set; } = string.Empty;//email is not null but will be empty text 

        public string Password { get; set; } = string.Empty;//Password is not null but will be empty text 

        public UserRole Role { get; set; } // which role the user would be (Navigation Property)
    }
}
