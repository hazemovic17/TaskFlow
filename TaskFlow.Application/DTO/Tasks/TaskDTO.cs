using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Enums;
using TaskStatus = TaskFlow.Domain.Enums.TaskStatus;

namespace TaskFlow.Application.DTO.Tasks
{
    public class TaskDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid AssignedUserId { get; set; }
    }
}
